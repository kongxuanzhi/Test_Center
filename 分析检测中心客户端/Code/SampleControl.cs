using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Code;
using TRESystem2011;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;

namespace Code
{
    class SampleControl
    {

        public SampleControl()
        {

        }


        /// <summary>
        /// 删除某个样品
        /// </summary>
        /// <param name="sno"></param>
        /// <returns></returns>
        public static int deleteSample(string sno)
        {
            if (MessageBox.Show("确定要删除" + sno + "的所有信息吗？", "警告！", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return 0;
            }
            string sql = string.Format("delete from sampletable where sno='{0}';", sno);
            sql += string.Format("delete from resulttable where sno='{0}'", sno);

            return DB.ExecuteNonQuery(sql);
        }



        /// <summary>
        /// 更新样品结果信息
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int updateSampleItems(string sno,DataTable dt)
        {
            DB.ExecuteNonQuery(string.Format("delete from resulttable where sno='{0}'", sno));           
            int i = 1;
            string sql = "";
            foreach (DataRow dr in dt.Rows)
            {
                sql += string.Format("insert into Resulttable(sno,Titem,Tunit,Tstandard,Tvalue,Tindex,Tdeterminant) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}');", sno, dr["Titem"], dr["Tunit"], dr["Tstandard"], dr["Tvalue"], i, dr["Tdeterminant"]);
                i++;
            }
            return DB.ExecuteNonQuery(sql);

        }



        /// <summary>
        ///  某个样品要检测那些元素的含量
        /// </summary>
        /// <param name="sno">样品编号</param>
        /// <param name="dt">元素含量表</param>
        /// <returns></returns>
        public static int addSampleItems(string sno, DataTable dt)
        {
            int i = 1;
            string sql = "";
            foreach (DataRow dr in dt.Rows)
            {
                sql += string.Format("insert into Resulttable(sno,Titem,Tunit,Tstandard,Tvalue,Tindex,Tdeterminant) values('{0}','{1}','{2}','{3}','{4}','{5}','/');", sno, dr["Titem"], dr["Tunit"], dr["Tstandard"], dr["Tvalue"], i);
                i++;
            }
            return DB.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 将一个样品批次的原样编号和试样编号单独存进一张表里，
        /// 并生成试样编号和原样编号一一对应，外键是任务单的主键sno
        /// </summary>
        /// <param name="sno">任务单编号 如2015N1029</param>
        /// <param name="SoriginalNo">原样编号 以换行隔开，对应多个原样编号</param>
        /// <returns></returns>
        public static int addSampleNO(string sno, string SoriginalNo)
        {
            string Sno = sno;
            for (int i = sno.Length-1; i>=0; i--)
            {
                if(!(sno[i]>='0' && sno[i] <= '9'))
                {   //2015W23
                    Sno = string.Format("{0}{1}{2}",sno.Substring(4,i-3),sno.Substring(2,2),sno.Substring(i+1,sno.Length-i-1));
                    break;
                }
            }
            string SoriginalNos =  Regex.Replace(SoriginalNo, "(\\r\\n)+", ",");
            string[] OrNos = SoriginalNos.Split(',');
            if (OrNos.Length == 0)
                return 0;  //出错了
            try
            {
                int k = 1;
                for (int i = 0; i < OrNos.Length; i++)
                {
                    if (!string.IsNullOrEmpty(OrNos[i]))
                    {
                        string sql = string.Format("insert into SampleSerialNO values('{0}','{1}','{2}')", OrNos[i], Sno + "-" + (k++), sno);
                        DB.ExecuteNonQuery(sql);
                    }
                }
            }
            catch (Exception e)
            {
                return 0;//出错了
            }
            return 1;  //成功插入
        }

        /// <summary>
        /// 更新样品信息
        /// </summary>
        /// <param name="dr"></param>
        public static int updateSampleInfo(DataRow dr)
        {
            DataTable dt = dr.Table;
            OleDbDataAdapter oda = DB.getAdapterByTableName("Sampletable");
            return oda.Update(dt);
        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="SampleTB"></param>
        /// <param name="Titemdt"></param>
        /// <returns></returns>
        public static List<string> addNewSamples(DataTable SampleTB, DataTable Titemdt)
        {
            Dictionary<string, string> lastSnoDic = new Dictionary<string, string>();

            List<string> snos = new List<string>();
            try
            {
                foreach (DataRow Sampledr in SampleTB.Rows)
                {
                    string skind=Sampledr["Skind"].ToString();
                    if(!lastSnoDic.ContainsKey(skind)) //如果没有增加过
                    {
                        Sampledr["Sno"] = getNewSampleNumber(Sampledr["Skind"].ToString()); //添加新样品ID
                    }
                    else
                    {
                        Sampledr["Sno"] = calNextSampleNumber(lastSnoDic[skind]); //已经存在则计算下一个ID
                    }
                    Sampledr["Rno"] = calReportNumber(Sampledr["Sno"].ToString());//Rno //计算报告名
                    lastSnoDic[skind] = Sampledr["Sno"].ToString(); //储存上一个ID

                    //一些默认设置
                    Sampledr["CanBaseInformation"] = "false";
                    Sampledr["CanSintime"] = "false";
                    Sampledr["CanScontracttime"] = "false";
                    Sampledr["CanCost"] = "false";
                    Sampledr["CanItems"] = "false";

                    snos.Add(Sampledr["Sno"].ToString());

                    addSampleItems(Sampledr["Sno"].ToString(), Titemdt);
                }
                OleDbDataAdapter oda = DB.getAdapterByTableName("Sampletable");
                oda.Update(SampleTB);
            }
            catch (System.Exception)
            {
                throw;	
            }
            return snos;
        }


        /// <summary>
        /// 根据dr和dt创建一个新的sample
        /// </summary>
        /// <param name="Sampledr">样品信息表</param>
        /// <param name="Titemdt">待测的样品包含的元素种类表</param>
        public static string addNewSample(DataRow Sampledr,DataTable Titemdt)
        {
            try
            {
                Sampledr["Sno"] = getNewSampleNumber(Sampledr["Skind"].ToString()); //根据样品的种类（内样，外样，专样等) 设置新样品编号
                Sampledr["Rno"] = calReportNumber(Sampledr["Sno"].ToString());//   理工检{0}字(20{1}){2:00000} //暂不清楚

                //一些默认设置f
                Sampledr["CanBaseInformation"] = "false";
                Sampledr["CanSintime"] = "false";
                Sampledr["CanScontracttime"] = "false";
                Sampledr["CanCost"] = "false";
                Sampledr["CanItems"] = "false";

                DataTable dt = Sampledr.Table;
                dt.Rows.Add(Sampledr);
                OleDbDataAdapter oda=DB.getAdapterByTableName("Sampletable");
                oda.Update(dt);

                addSampleItems(Sampledr["Sno"].ToString(), Titemdt);  //将检测元素加到一个表Resulttable里 ,共检测报告使用
                addSampleNO(Sampledr["Sno"].ToString(), Sampledr["SoriginalNo"].ToString());

            }
            catch (System.Exception e)
            {
                throw;
            }
            return Sampledr["Sno"].ToString(); //返回sampleId
        }



        /// <summary>
        /// 根据编号计算报告号
        /// </summary>
        /// <param name="sno"></param>
        /// <returns></returns>
        public static string calReportNumber(string sno)  // 改
        {
            string[] tmpstrs = sno.Split('(',')');  //根据括号拆分
            //string sampletype = tmpstrs[0];
            //string shortyear = tmpstrs[1];
            //int number = Convert.ToInt16(tmpstrs[2]);
            return null;// string.Format("理工检{0}字(20{1}){2:00000}", sampletype, shortyear, number);
        }


        /// <summary>
        /// 计算下一个编号
        /// </summary>
        /// <param name="sno"></param>
        /// <returns></returns>
        public static string calNextSampleNumber(string sno)   
        {
            string[] tmpstrs = sno.Split('(', ')');
            int newnumber = Convert.ToInt16(tmpstrs[2]) + 1;
            return string.Format("{0}({1}){2:00000}", tmpstrs[0],tmpstrs[1],newnumber);
        }

        /// <summary>
        /// 获取新样品名称，自动跨年
        /// </summary>
        /// <param name="sampletype">样品种类 N 内样，W外样 等</param>
        /// <author >孔龙飞改</author>
        /// <returns></returns>
        public static string getNewSampleNumber(string sampletype)
        {
            //任务单和报告单编号
            string newsno = "";
            ///当前年份 2016
            string shortyear = Libs.getShortYear(DateTime.Now);
           //  string sql = string.Format("select max(sno) from sampletable where sno like '%{0}%'", sampletype); //N
            string sql = string.Format("select top 1 sno from sampletable where sno like '____{0}%'  order by Sintime desc", sampletype); //N
            string maxsno = DB.ExecuteScalar(sql);
            if (!string.IsNullOrEmpty(maxsno))
            {
                for (int i = maxsno.Length - 1; i >= 0; i--)
                {
                    if (!(maxsno[i] >= '0' && maxsno[i] <= '9'))
                    {
                        string ms = maxsno.Substring(4,i-4+1);
                        if (!ms.Equals(sampletype))
                        {
                            maxsno = "";
                        }
                        break;
                    }
                }
            }
            if (maxsno == "")   //如果一个样都没有
            {
                newsno = string.Format("{0}{1}1", shortyear,sampletype);
            }
            else
            {
                string maxyear = maxsno.Substring(0,4); //数据库查找编号前四位年份
                if (maxyear != shortyear)   //没有本年度  2015 != 2016 
                {
                    newsno = string.Format("{0}{1}0001", shortyear, sampletype);  // 2016N1
                }
                else
                {
                    int newnumber = 1;  //样品批次  自动增加
                    for (int i = maxsno.Length-1; i >=0; i--)
                    {
                        if (!(maxsno[i] >= '0' && maxsno[i]<='9')) {
                            string pici =  maxsno.Substring(i + 1, maxsno.Length-i-1);
                            newnumber = Convert.ToInt32(pici);
                            break;
                        }
                    }
                    newsno = string.Format("{0}{1}{2}",shortyear, sampletype, Add0(newnumber + 1));  //2016N2
                }
            }
            return newsno;
        }


        private static string Add0(int number)
        {
            if (number > 9999)
            {

                return number.ToString();
            }
            else
            {
                return number.ToString().PadLeft(4, '0'); //一共4位,位数不够时从左边开始用0补
            }
        }

        /// <summary>
        /// 获取客户名
        /// </summary>
        /// <param name="sno"></param>
        /// <returns></returns>
        public static string getCustomerName(string sno)    
        {
            string sql = string.Format("select Customername from sampletable,customer where sno='{0}' and sampletable.cno=customer.cno", sno);
            return DB.ExecuteScalar(sql);
        }
        /// <summary>
        /// 获取样品当前状态
        /// </summary>
        /// <param name="sno"></param>
        /// <returns></returns>
        public static string getStatus(string sno)    
        {
            string sql = string.Format("select * from sampletable where sno='{0}'", sno);
            DataRow dr = DB.getDataRow(sql);
            string status="未知";
            if (dr["Sprooftime"].ToString()=="/")
            {
                status="待校对";
            }
            else if (dr["Ssignintime"].ToString() == "/")
            {
                status="待签收";
            }
            else if (dr["Souttime"].ToString() == "/")
            {
                status = "待填报";
            }
            else if (dr["Sverifytime"].ToString() == "/")
            {
                status = "待审核";
            }
            else if (dr["Sapprovetime"].ToString() == "/")
            {
                status = "待批准";
            }
            else if (dr["Rsendtime"].ToString() == "/")
            {
                status = "待发送";
            }
            else
            {
                status = "已发送";
            }
            return status;

        }

        /// <summary>
        /// 查看校对
        /// </summary>
        /// <returns></returns>
        public static DataSet getSproofDS()    
        {
            string sql = "select sampletable.*,customer.* from sampletable,customer where sampletable.cno=customer.Customerno and Sprooftime = '/' order by sno";
            return DB.getDataSet(sql,"a");
        }
        /// <summary>
        /// 查看签收
        /// </summary>
        /// <returns></returns>
        public static DataSet getSigninDS()    
        {
            string sql = "select sampletable.*,customer.* from sampletable,customer where sampletable.cno=customer.Customerno and Sprooftime!='/' and Ssignintime='/' order by sno";
            return DB.getDataSet(sql,"a");
        }
        /// <summary>
        /// 查看能够填写进度的数据集，已签收但未检测完
        /// </summary>
        /// <returns></returns>
        public static DataSet getTestDS()    
        {
            string sql = "select sampletable.*,customer.* from sampletable,customer where sampletable.cno=customer.Customerno and Ssignintime!='/' and Sverifytime='/' order by sno";
            return DB.getDataSet(sql,"a");
        }
        /// <summary>
        /// 查看能够审核的数据集，已签收未审核
        /// </summary>
        /// <returns></returns>
        public static DataSet getVerifyDS()    
        {
            string sql = "select sampletable.*,customer.* from sampletable,customer where sampletable.cno=customer.Customerno and  Ssignintime!='/' and Sverifytime='/' order by sno";
            return DB.getDataSet(sql,"a");
        }


        /// <summary>
        /// 查看已经完检，未审核的样品
        /// </summary>
        /// <returns></returns>
        public static DataSet getHasOutDS()
        {
            string sql = "select sampletable.*,customer.* from sampletable,customer where sampletable.cno=customer.Customerno and  Souttime!='/' and Sverifytime='/' order by sno";
            return DB.getDataSet(sql, "a");
        }


        /// <summary>
        /// 查看能够授权打印的数据集，已审核未授权
        /// </summary>
        /// <returns></returns>
        public static DataSet getApproveDS()    
        {
            string sql = "select sampletable.*,customer.* from sampletable,customer where sampletable.cno=customer.Customerno and Sverifytime!='/' and Sapprovetime='/' order by sno";
            return DB.getDataSet(sql,"a");
        }

        /// <summary>
        /// 查看能够打印、尚未发出的数据集，已授权未发出
        /// </summary>
        /// <returns></returns>
        public static DataSet getSendOutDS()    
        {
            string sql = "select sampletable.*,customer.* from sampletable,customer where sampletable.cno=customer.Customerno and  Sapprovetime!='/' and Rsendtime ='/' order by sno";
            return DB.getDataSet(sql,"a");
        }

        /// <summary>
        /// 获取所有未完成的数据集
        /// </summary>
        /// <returns></returns>
        public static DataSet getUnCompleteDS()
        {
            string sql = "select sampletable.*,customer.* from sampletable,customer where sampletable.cno=customer.Customerno and Rsendtime ='/' order by sno";
            return DB.getDataSet(sql, "a");
        }

        /// <summary>
        /// 获取报告名
        /// </summary>
        /// <param name="sno"></param>
        /// <returns></returns>
        public static string getReportName(string sno)
        {
            return DB.ExecuteScalar("select reportname from QStamp where samplenumber='" + sno + "'");
        }


        /// <summary>
        /// 1校对
        /// </summary>
        /// <param name="sno"></param>
        /// <returns></returns>
        public static bool sproof(string sno)  
        {
            try
            {
                
                string sqlstr = "update sampletable  set Sprooftime='" + Libs.getServerDateStr() + "',Sproofer='" + User.name + "'  where sno='" + sno + "'";

                DB.ExecuteNonQuery(sqlstr);
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        /// <summary>
        /// 2签收
        /// </summary>
        /// <param name="sno"></param>
        /// <returns></returns>
        public static bool signin(string sno)  
        {
            try
            {
                
                string sqlstr = "update sampletable set Ssignintime='" + Libs.getServerDateStr() + "',Ssigniner='" + User.name + "'  where sno='" + sno + "'"; 
                DB.ExecuteNonQuery(sqlstr);
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        /// <summary>
        /// 3完检
        /// </summary>
        /// <param name="sno"></param>
        /// <returns></returns>
        public static bool Sout(string sno) 
        {
            try
            {
                string sqlstr = "update sampletable set Souttime='" + Libs.getServerDateStr() + "' where sno='" + sno + "'";
                DB.ExecuteNonQuery(sqlstr);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 4审核
        /// </summary>
        /// <param name="sno"></param>
        /// <returns></returns>
        public static bool verify(string sno)  
        {
            try
            {
                string sqlstr = "update sampletable set Sverifier='" + User.name +
                      "',Sverifytime='" + Libs.getServerDateStr() +
                      "' where sno='" + sno + "'";
                DB.ExecuteNonQuery(sqlstr);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 5批准打印
        /// </summary>
        /// <param name="sno"></param>
        /// <param name="reportkind"></param>
        /// <returns></returns>
        public static bool approve(string sno, string reportkind) 
        {
            try
            {
                string sqlstr = "update sampletable set Sapprovetime='" + Libs.getServerDateStr() + "',Sapprover='" + User.name + "'  where sno='" + sno + "'";
                DB.ExecuteNonQuery(sqlstr);
                sqlstr = "delete from QStamp where SampleNumber='" + sno + "'";
                DB.ExecuteNonQuery(sqlstr);
                sqlstr = "insert into QStamp(SampleNumber,reportname) values('" + sno + "','" + reportkind + "')";
                DB.ExecuteNonQuery(sqlstr);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 6发出
        /// </summary>
        /// <param name="sno"></param>
        /// <returns></returns>
        public static bool sendOut(string sno)
        {
            try
            {
                string sqlstr = "update sampletable set Rsendtime='" + Libs.getServerDateStr() + "',Rsender='" + User.name + "'  where sno='" + sno + "'";
                DB.ExecuteNonQuery(sqlstr);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 清理样品各种状态
        /// </summary>
        /// <param name="sno"></param>
        /// <returns></returns>
        public static bool ClearSample(string sno)
        {
            try
            {
                string sqlstr = "update sampletable set Sprooftime='/',Ssignintime='/',Souttime='/',Sverifytime='/',Sapprovetime='/',"
                +"Rsendtime='/',Sfiller='/',Sverifier='/',Sprinter='/',Sapprover='/' where sno='" + sno + "'";

                DB.ExecuteNonQuery(sqlstr);
            }
            catch (Exception)
            {
                return false;
            }
            return true;

        }

        /// <summary>
        /// 批量设置是否允许修改
        /// </summary>
        /// <param name="sno"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static int SetCan(string sno, string flag)
        {
            string sqlstr = string.Format("update sampletable set CanBaseInformation='{0}',CanSintime='{0}',CanCost='{0}',CanScontracttime='{0}',CanItems='{0}'  where sno='{1}'",flag,sno);
            return DB.ExecuteNonQuery(sqlstr);
        }

        /// <summary>
        /// 修改进样时间（主要是批量用）
        /// </summary>
        /// <param name="sno"></param>
        /// <param name="dt"></param>
        /// <param name="CheckFlag"></param>
        /// <returns></returns>
        public static int SetSintime(string sno, string dt,bool CheckFlag)
        {
            string sqlstr="";
            if(CheckFlag)
            {
                sqlstr=string.Format("update sampletable set Sintime='{0}',Cansintime='false' where sno='{1}' and (Cansintime='true' or Ssignintime='/')",dt,sno); //可修改或未授权 
            }
            else
            {
                sqlstr=string.Format("update sampletable set Sintime='{0}' where sno='{1}'",dt,sno);
            }
            return DB.ExecuteNonQuery(sqlstr);
        }

        /// <summary>
        /// 修改合约时间（主要是批量用）
        /// </summary>
        /// <param name="sno"></param>
        /// <param name="dt"></param>
        /// <param name="CheckFlag"></param>
        /// <returns></returns>
        public static int SetScontracttime(string sno, string dt, bool CheckFlag)
        {
            string sqlstr = "";
            if (CheckFlag)
            {
                sqlstr = string.Format("update sampletable set Scontracttime='{0}',CanScontracttime='false' where sno='{1}' and (CanScontracttime='true' or Ssignintime='/')", dt, sno);
            }
            else
            {
                sqlstr = string.Format("update sampletable set Scontracttime='{0}' where sno='{1}'",dt,sno);
            }
            return DB.ExecuteNonQuery(sqlstr);
        }

    }
}
