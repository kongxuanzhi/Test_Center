//liyang 20120908
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using Code;
using System.Data.OleDb;
using TRESystem2011;
using System.Drawing;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace Code
{
    class ReportFactory      //读取数据库并返回dataset供报表使用
    {
       
        public ReportFactory()
        {

        }


            
        public DataSet GetSampleMoveDS(List<string> snolist)       //获取流转卡
        {
            int sum = snolist.Count;    //总数
            string[] TempTable = new string[sum];
            DataSet1 dataset = new DataSet1();
            string sql = "select * from sampletable where sno in (";
            sql += Libs.arrayToString(snolist.ToArray(), ",","'");
            sql += ") order by sno";

            DB.fillDataSet(dataset, "sampletable", sql);

            OleDbDataReader myreader;
            for (int i = 0; i < sum; i++)
            {
                myreader = DB.ExecuteReader("select titem from resulttable where  sno='" + snolist[i] + "' and titem!='/' order by Tindex");
                while (myreader.Read())
                {
                    TempTable[i] += myreader["titem"].ToString().Trim() + ",";
                }
                myreader.Close();
                TempTable[i] = TempTable[i].Substring(0, TempTable[i].Length - 1);
                TempTable[i] += "。";
                dataset.Tables["TempTable"].Rows.Add(snolist[i], TempTable[i]);

            }
            return dataset;
        }

//         public DataSet GetSprooferDS(string sno)  //获取校对卡数据集
//         {
//             DataSet1 dataset = new DataSet1();
//             DB.fillDataSet(dataset, "sampletable", "SELECT * FROM sampletable where  sno='" + sno + "' ");
// 
//             DB.fillDataSet(dataset, "customer", "select * from customer,sampletable where customer.customerNo=sampletable.cno and sno='" + sno + "' ");
//             string TempTable = "";
//             OleDbDataReader myreader = DB.ExecuteReader("select titem from resulttable where  sno='" + sno + "' and titem!='/'  order by Tindex");
//             while (myreader.Read())
//             {
//                 TempTable += myreader.GetString(0).Trim() + ",";
//             }
//             myreader.Close();
//             TempTable = TempTable.Substring(0, TempTable.Length - 1);
//             TempTable += "。";
// 
//             DataTable dt = new DataTable();
//            
// 
// 
//             dataset.Tables["TempTable"].Rows.Add(sno, TempTable);
//             return dataset;
//         }


        private MidDBReport FIllMidDB(string sno,string reportkind, bool stamp)
        {
            MidDBReport ds = new MidDBReport();
            DataRow dr = ds.MittionReport.NewRow();
            string sql = "select Sno,Cno,Sname,Sstate,Squantity,Sintime,chargestd,WhoTake,customerNo,customername,relation,tel, Costtotal as totalMoney,Ssignintime,Taccording,Tkind,MainDevice,TestResult,Sremark from Sampletable S,Customer C where S.Cno = C.customerNo and Sno = '" + sno + "'";
            DataTable tempdr = DB.getDataTable(sql);
            for (int i = 0; i < tempdr.Columns.Count; i++)
            {
                string colName = tempdr.Columns[i].ColumnName;
                dr[colName] = tempdr.Rows[0][colName];
            }
            #region 试样编号
            List<object> SampleNOs = DB.getList("select SampleNO from SampleSerialNO where Sno = '" + sno + "'");
            string SampleNO = "";
            for (int i = 0; i < SampleNOs.Count; i++)
            {
                SampleNO += SampleNOs[i].ToString();
                if (i != SampleNOs.Count - 1)
                {
                    SampleNO += ",";
                }
            }
            dr["SampleNOs"] = SampleNO;
            #endregion
            #region 检测项目字符串用逗号隔开
            List<object> Titem = DB.getList("select Titem from Resulttable where Sno = '" + sno + "'");
            string Titems = "";
            for (int i = 0; i < Titem.Count; i++)
            {
                Titems += Titem[i].ToString();
                if (i != Titem.Count - 1)
                {
                    Titems += ",";
                }
            }
            dr["Titem"] = Titems;
            #endregion
            #region 主检检测时间
            string sqltime = "select Souttime from Sampletable where sno='" + sno + "'";
            DateTime dt = Convert.ToDateTime(DB.ExecuteObject(sqltime));
            dr["Year"] = dt.Year;
            dr["Month"] = dt.Month;
            dr["Day"] = dt.Day;
            #endregion

            dr["mainTest"] = (Byte[])DB.ExecuteObject("select underwrite from users,sampletable where Smastertest=username and  sno='" + sno + "'");
            dr["Checked"] = (Byte[])DB.ExecuteObject("select underwrite from users,sampletable where Sverifier=username and  sno='" + sno + "'");
            dr["approve"] = (Byte[])DB.ExecuteObject("select underwrite from users,sampletable where Sapprover=username and  sno='" + sno + "'");

            if (reportkind.Contains("有CMA"))
            {
                //将图片加上去
                dr["CAM"] = Res.cma;
            }
            if (stamp)
            {
                dr["CenterZhang"] = Res.test;
            }
            ds.MittionReport.Rows.Add(dr);
            DB.fillDataSet(ds, "SampleSerialNO", "SELECT Id,SoriginalNo, SampleNO,sno FROM SampleSerialNO where sno='" + sno + "' ");
            //将数据填充到dt，
            //将dt绑定到view
            //ReportFactory rf = new ReportFactory();
            //rf.PrintResult(crystal_result_main, sno, ds);
            return ds;
        }

        public ReportClass getReportClass(string sno, string reportkind, bool stamp)
        {
            MidDBReport ds = FIllMidDB(sno,reportkind, stamp);
            ReportClass report;

            if (reportkind.Contains("简约格式"))
            {
                report = new TRESystem2011.Report.Brief();
            }
            else
            {
                report = new TRESystem2011.Report.All();
            }
            report.SetDataSource(ds);
            return report;
        }


        public DataSet1 GetReportDS(string sno,string reportkind,bool stamp)  //获取检测报告所需数据
        {
            DataSet1 dataset = new DataSet1();
            DataRow dr = dataset.ReportTemp.NewRow();
            dr["Smastertest"] = (Byte[])DB.ExecuteObject("select underwrite from users,sampletable where Smastertest=username and  sno='" + sno + "'");
            dr["Sverifier"] = (Byte[])DB.ExecuteObject("select underwrite from users,sampletable where Sverifier=username and  sno='" + sno + "'");
            dr["Sapprover"] = (Byte[])DB.ExecuteObject("select underwrite from users,sampletable where Sapprover=username and  sno='" + sno + "'");

            DateTime Sintime = Convert.ToDateTime(DB.ExecuteObject("select Sintime from sampletable where sno='" + sno + "'"));
            //进样时间

          //  dr["Stamp"] = Res.blank; //空白
            dr["Cma"] = Res.blank;
            dr["Cal"] = Res.blank;
            dr["Cnas"] = Res.blank;



            if (sno.StartsWith("CW") || sno.StartsWith("CX"))   //省抽
            {
                dr["Title"] = "江西理工大学分析测试中心";
                dr["EnTitle"] = "JIANGXI CENTER FOR QUALITY SUPERVISION AND INSPECTION OF TUNGSTEN AND RARE-EARTH";
                if (DateTime.Compare(Sintime, Convert.ToDateTime("2013-7-19")) >= 0)  //2013年7月19日开始使用新国CMA
                {
                    dr["Cma"] = Res.jxcma2013;
                    dr["Cal"] = Res.jxcal2013;
                }
                else
                {
                    dr["Cma"] = Res.jxcma;
                    dr["Cal"] = Res.jxcal;
                }

//                 dr["Cnas"] = Res.cnas;
                //省抽不给CNAS
            }
            else if (sno.StartsWith("GC"))   //江西理工大学分析测试中心
            {
                dr["Title"] = "江西理工大学分析测试中心";
                dr["EnTitle"] = "CHINA CENTER FOR QUALITY SUPERVISION AND INSPECTION OF TUNGSTEN AND RARE-EARTH";
                if (DateTime.Compare(Sintime, Convert.ToDateTime("2013-3-1")) >= 0)  //2013年3月1日开始使用新国CMA
                {
                    dr["Cma"] = Res.gjcma2013;
                    dr["Cal"] = Res.gjcal2013;
                }
                else
                {
                    dr["Cma"] = Res.gjcma;
                    dr["Cal"] = Res.gjcal;
                }
                dr["Cnas"] = Res.cnas;
            }
            else   //普通样品
            {
                if (reportkind.Contains("有CNAS"))
                {
                    dr["Cnas"] = Res.cnas;
                }
                if (reportkind.Contains("jx"))  //江西省
                {
                    dr["Title"] = "江西省钨与稀土产品质量监督检验中心";
                    dr["EnTitle"] = "JIANGXI CENTER FOR QUALITY SUPERVISION AND INSPECTION OF TUNGSTEN AND RARE-EARTH";
                    if (reportkind.Contains("有计量认证"))  //为了兼容原来的数据，有计量认证则2个章都有
                    {
                        dr["Cma"] = Res.jxcma;
                        dr["Cal"] = Res.jxcal;
                    }
                    if (reportkind.Contains("有CMA"))
                    {

                        if (DateTime.Compare(Sintime, Convert.ToDateTime("2013-7-19")) >= 0)  
                        {
                            dr["Cma"] = Res.jxcma2013;
                        }
                        else
                        {
                            dr["Cma"] = Res.jxcma;
                        }
                    }
                    if (reportkind.Contains("有CAL"))
                    {
                        if (DateTime.Compare(Sintime, Convert.ToDateTime("2013-7-19")) >= 0)  
                        {
                            dr["Cal"] = Res.jxcal2013;
                        }
                        else
                        {
                            dr["Cal"] = Res.jxcal;
                        }
                    }
                    if (stamp)
                    {
                        dr["Stamp"] = Res.jxstamp;
                    }
                }
                else if (reportkind.Contains("gj"))  //国家
                {
                    dr["Title"] = "江西理工大学分析测试中心";
                    dr["EnTitle"] = "CHINA CENTER FOR QUALITY SUPERVISION AND INSPECTION OF TUNGSTEN AND RARE-EARTH";

                    if (reportkind.Contains("有计量认证"))
                    {
                        dr["Cma"] = Res.gjcma;
                        dr["Cal"] = Res.gjcal;
                    }
                    if (reportkind.Contains("有CMA"))
                    {
                        if (DateTime.Compare(Sintime, Convert.ToDateTime("2013-3-1")) >= 0)  //2013年3月1日开始使用新国CMA
                        {
                            dr["Cma"] = Res.gjcma2013;
                        }
                        else
                        {
                            dr["Cma"] = Res.gjcma;
                        }
                    }
                    if (reportkind.Contains("有CAL"))
                    {
                        if (DateTime.Compare(Sintime, Convert.ToDateTime("2013-3-1")) >= 0)  //2013年3月1日开始使用新章
                        {
                            dr["Cal"] = Res.gjcal2013;
                        }
                        else
                        {
                            dr["Cal"] = Res.gjcal;
                        }

                    }
                    if (stamp)
                    {
                        dr["Stamp"] = Res.gjstamp;
                    }
                }
                else  //最简报告
                {
                    dr["Title"] = "";
                    dr["EnTitle"] = "";
                }
            }

            dataset.ReportTemp.Rows.Add(dr);
            
            //完整和简约格式现在合并公用一套数据库
            DB.fillDataSet(dataset, "sampletable", "SELECT * FROM sampletable where sno='" + sno + "' ");
            //DB.fillDataSet(dataset, "resultimage", "select Sno,image,resulttable.titem,tunit,tstandard,tvalue,tindex,tdeterminant from resulttable,itemtable where sno='" + sno + "'  and resulttable.titem=itemtable.titem order by Tindex");
            DB.fillDataSet(dataset, "customer", "select * from customer,sampletable where customer.customerNo=sampletable.cno and sno='" + sno + "' ");

            return dataset;
        }

        public ReportClass getReport(string sno, string reportkind, bool stamp ,int type) //直接获取报告
        {
            DataSet1 dataSet = GetReportDS(sno, reportkind, stamp);
            ReportClass myreport;
            if (type == 0)
            {
                if (sno.StartsWith("GC") || sno.StartsWith("CX") || sno.StartsWith("CW")) //抽查样品
                {
                    myreport = new TRESystem2011.Report.CCEX();
                }
                else if (reportkind.Contains("简约格式"))//简约格式
                {
                    myreport = new TRESystem2011.Report.ShortReport();

                    //给简约格式添加“以下空白”
                        DataSet1.ResultImageRow BlankRow = dataSet.ResultImage.NewResultImageRow();
                        BlankRow.Sno = sno; //主键，必须有
                        BlankRow.image = Res.yxkb;
                        dataSet.ResultImage.Rows.Add(BlankRow);
                }
                else if (reportkind.Contains("完整格式"))
                {
                    myreport = new TRESystem2011.Report.LongReport();

                }
                else  //最终使用特殊格式
                {
                    myreport = new TRESystem2011.Report.TSReport();
                }
            }
            else if (type == 1)
            {
                myreport = new TRESystem2011.Report.ShortReport();
                //给简约格式添加“以下空白”

                DataSet1.ResultImageRow BlankRow = dataSet.ResultImage.NewResultImageRow();
                BlankRow.Sno = sno; //主键，必须有
                BlankRow.image = Res.yxkb;
                dataSet.ResultImage.Rows.Add(BlankRow);

            }
            else if(type==2)
            {
                myreport = new TRESystem2011.Report.LongReport();
            }
            else  //最终使用特殊格式(包含3)
            {
                myreport = new TRESystem2011.Report.TSReport();
            }
          
            myreport.SetDataSource(dataSet);
            return myreport;
        }

        /// <summary>
        /// 打印任务单 孔龙飞新添
        /// </summary>
        /// <param name="crystalReport_Mission">任务单报表</param>
        /// <param name="sno">任务序号</param>
        public void PrintMission(CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReport_Mission, string sno,MidDBReport ds)
        {
            ReportClass rc = new TRESystem2011.Report.Mission();
            rc.SetDataSource(ds);
            crystalReport_Mission.ReportSource = rc;
        }
        /// <summary>
        /// 打印检验报告 孔龙飞新添
        /// </summary>
        /// <param name="crystalReport_Mission">任务单报表</param>
        /// <param name="sno">任务序号</param>
        public void PrintResult(CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReport_Mission, string sno, MidDBReport ds)
        {
            ReportClass rc = new TRESystem2011.Report.Brief();
            rc.SetDataSource(ds);
            crystalReport_Mission.ReportSource = rc;
        }

        //指定格式填充viewer
        public void FillReportViewer(CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1, string sno, string reportkind,bool stamp)
        {
            ReportClass rc = getReportClass(sno, reportkind, stamp);
            crystalReportViewer1.ReportSource = rc;
        }

        //从数据库中读取格式填充
        public void FillReportViewer(CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1, string sno, bool stamp ,int type)
        {
            string sqlstr = "select reportname from QStamp where samplenumber='" + sno + "'";
            string reportkind = DB.ExecuteScalar(sqlstr);  //获取报告形式
            ReportClass rc = getReportClass(sno, reportkind,true);
            crystalReportViewer1.ReportSource = rc;
        }


        public ReportClass getReportByName(string ReportName) //获取某种格式报表
        {
            ReportClass rc = new ReportClass();
            rc.Load(ReportName);
            return rc;
        }
        public void printReport(string sno, bool stamp, int n, int type)   //强制打印某种格式
        {
            string reportkind = "";
            string sqlstr = "select reportname from QStamp where samplenumber='" + sno + "'";
            reportkind = DB.ExecuteScalar(sqlstr);  //获取报告形式
            //ReportClass rc = getReport(sno, reportkind, stamp, type);   //获取报告格式
            string geshi = GetPrintType(type);
            //if (!reportkind.Contains(geshi))
            //{
            //    if (geshi.Equals("简约格式"))
            //    {
            //        reportkind = reportkind.Replace("简约格式","完整格式");
            //    }
            //    else if (geshi.Equals("完整格式"))
            //    {
            //        reportkind = reportkind.Replace("完整格式", "简约格式");
            //    }
            //}
            ReportClass rc = getReportClass(sno, reportkind, stamp);   //获取报告格式
            rc.PrintToPrinter(n, true, 0, 0);  //进行打印
            sqlstr = "update sampletable set Sprinter='" + User.name + "' where sno='" + sno + "'";
            DB.ExecuteNonQuery(sqlstr); //更新打印人
        }
        private string GetPrintType(int type)
        {
            if (type == 0) return "简约格式";
            else return "完整格式";
        }


        private struct ItemInfo //样品映射表
        {
            public string id;
            public string Tvalue;
        };


        /// <summary>
        /// 返回样品列表的结果数据
        /// </summary>
        /// <param name="snolist"></param>
        public DataTable getResultsTable(List<string> snolist)
        {

            string snoArrayStr;
            DataTable sampledt; //样品table
            Dictionary<string, Dictionary<string, ItemInfo>> sampleDic = new Dictionary<string, Dictionary<string, ItemInfo>>();


            foreach (string sno in snolist) //先把所有样品存储内容初始化
            {
                sampleDic.Add(sno, new Dictionary<string, ItemInfo>());
            }

            snoArrayStr = "('" + string.Join("','", snolist.ToArray()) + "')";
            string sql = "select sno,soriginalNo as 原编号,sname as 样品名称 from sampletable where sno in " + snoArrayStr;
            sampledt = DB.getDataTable(sql);
            sql = "select id,Sno,Titem,Tvalue from resulttable where sno in " + snoArrayStr + "order by sno,Tindex";
            DataTable dt2 = DB.getDataTable(sql);   //读取所有数据并存入临时结构体中

            foreach (DataRow dr in dt2.Rows)    //循环将表中内容写入dic中
            {
                if (!sampledt.Columns.Contains(dr["Titem"].ToString())) //如果不包含则添加
                {
                    sampledt.Columns.Add(dr["Titem"].ToString());
                }

                ItemInfo ii = new ItemInfo();
                ii.id = dr["id"].ToString();
                ii.Tvalue = dr["Tvalue"].ToString();
                sampleDic[dr["Sno"].ToString()].Add(dr["Titem"].ToString(), ii);
            }

            for (int i = 0; i < sampledt.Rows.Count; i++)   //全部写入
            {
                DataRow dr = sampledt.Rows[i];
                string sno = dr["Sno"].ToString();
                Dictionary<string, ItemInfo> dic = sampleDic[sno];  //获取映射
                foreach (string ItemName in dic.Keys)
                {
                    dr[ItemName] = dic[ItemName].Tvalue;
                }
            }
            return sampledt;

        }

    }
}
