using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using LuaInterface;
using System.Collections.Specialized;
using Code;
using NPOI.SS.UserModel;


namespace ICPTOOLS_DONET
{
    class ICPOperation
    {


        private static void WriteRPTTitle(ExcelBase excel,XT xt,string mode,int line)    //写报告标题
        {

            int n = Convert.ToInt32(excel.getCellStr(line, 0)); //第几个样品

            LuaTable y1lt=Lualib.getLuaTable("temp.y1");
            ListDictionary rptld = Lualib.getListDict("temp."+mode);
            excel.setCell(line, Convert.ToInt16(y1lt[2]), xt.id);
            excel.setCell(line, Convert.ToInt16(y1lt[3]), xt.name);
            excel.setCell(line, Convert.ToInt16(y1lt[4]), rptld["project"].ToString());

            if (mode == "rptpure")
            {
                string tmp = string.Format(rptld["gb"].ToString(), xt.flags[XT.PURE_INDEX] + 1);
                excel.setCell(line, Convert.ToInt16(y1lt[5]), tmp);
            }
            else
            {
                excel.setCell(line, Convert.ToInt16(y1lt[5]), rptld["gb"].ToString());
            }
           
            excel.setCell(line, Convert.ToInt16(y1lt[6]), rptld["weight"].ToString());
            excel.setCell(line + 1, Convert.ToInt16(y1lt[6]), rptld["weight"].ToString());
            excel.setCell(line, Convert.ToInt16(y1lt[7]), rptld["ming"].ToString()+(2*n-1));
            excel.setCell(line + 1, Convert.ToInt16(y1lt[7]), rptld["ming"].ToString()+(2*n));
            excel.setCell(line, Convert.ToInt16(y1lt[8]), rptld["v"].ToString());
            excel.setCell(line + 1, Convert.ToInt16(y1lt[8]), rptld["v"].ToString());
            excel.setCell(line, Convert.ToInt16(y1lt[9]), rptld["ping"].ToString()+(2*n-1));
            excel.setCell(line + 1, Convert.ToInt16(y1lt[9]), rptld["ping"].ToString()+(2*n));
            excel.setCell(line, Convert.ToInt16(y1lt[10]), rptld["rate"].ToString());
            excel.setCell(line + 1, Convert.ToInt16(y1lt[10]), rptld["rate"].ToString());
            if (xt.flags[XT.IS_O] == 1)
            {
                excel.setCell(line, Convert.ToInt16(y1lt[11]), xt.opjfzl.ToString());
            }
            else
            {
                excel.setCell(line, Convert.ToInt16(y1lt[11]), xt.pjfzl.ToString());
            }
        }

        public static bool WriteRPT(List<XT> xtlist,string savePath)  //写报告List版
        {
            ExcelBase excel = new ExcelBase();
            if (xtlist.Count>6)
            {
                MessageBox.Show("样品数量不能超过6个！");
                return false;
            }
            if (!excel.open(Application.StartupPath + "\\template\\ICPModel.xls"))//打开模板文件
            {
                MessageBox.Show("读取模板文件失败！");
                return false;
            }

            //读取配置文件
            int x1 = Convert.ToInt16(Lualib.getTempProp("x1"));
            int x2 = Convert.ToInt16(Lualib.getTempProp("x2"));
            int namex = Convert.ToInt16(Lualib.getTempProp("namex"));
            int datay = Convert.ToInt16(Lualib.getTempProp("datay"));


            int line=x1;
            int i=0;
            //YS只写一遍

            int ysindex = 0;
            XT xt1=xtlist[0];
            if (xt1.flags[XT.IS_O]==1)  //写元素列表
            {
                foreach (YS ys in xt1.xtyslist)
                {
                    excel.setCell(x2, datay + ysindex, Lualib.getYSProp(ys.name, "RPTOName").ToString());
                    ysindex++;
                }
                foreach (YS ys in xt1.qtyslist)
                {
                    excel.setCell(x2, datay + ysindex, Lualib.getYSProp(ys.name, "RPTOName").ToString());
                    ysindex++;
                }                
            } 
            else
            {
                foreach (YS ys in xt1.xtyslist)
                {
                    excel.setCell(x2, datay + ysindex, ys.name);
                    ysindex++;
                }
                foreach (YS ys in xt1.qtyslist)
                {
                    excel.setCell(x2, datay + ysindex, ys.name);
                    ysindex++;
                }    
            }

            for(int xtindex=0;xtindex<xtlist.Count;xtindex++)   //遍历XT 
            {
                XT xt=xtlist[xtindex];
                if (xt.flags[XT.MODE] == XT.MODE_PFAL)  //配分和AL
                {
                    if (xt.xtyslist.Count>0)    //如果有XT元素
                    {
                        excel.setCell(line, 0, (i + 1).ToString());
                        WriteRPTTitle(excel, xt, "rptpf", line);
                        line += 2;
                        i++;
                    }

                    if (xt.qtyslist.Count > 0) //如果有其他元素，则看是否需要写报告
                    {
                        foreach (YS ys in xt.qtyslist)
                        {
                            string rpt = Lualib.getYSProp(ys.name, "RPT").ToString();
                            if (rpt != "")
                            {
                                excel.setCell(line, 0, (i + 1).ToString());
                                WriteRPTTitle(excel, xt, rpt, line);
                                line += 2;
                                i++;
                            }
                        }
                    }
      
                }
                else if(xt.flags[XT.MODE]==XT.MODE_PURE)    //如果是纯度报告
                {
                    excel.setCell(line, 0, (i + 1).ToString());
                    WriteRPTTitle(excel, xt, "rptpure", line);
                    line += 2;
                    i++;
                }

                excel.setCell(namex + xtindex,0,xt.id); //写样品编号

                int ysindex2 = 0;
                foreach (YS ys in xt.xtyslist)  //写数据
                {
                    excel.setCell(namex + xtindex, datay + ysindex2, ys.limitval);
                    ysindex2++;
                }
                foreach (YS ys in xt.qtyslist)  //写数据
                {
                    excel.setCell(namex + xtindex, datay + ysindex2, ys.limitval);
                    ysindex2++;
                }

            }

            excel.saveCopyAS(savePath);
            excel.close();


            return true;
        }

         public static bool WriteRPT(Dictionary<string,XT> xtdic,string savePath)  //写报告Dictionary版
        {
            List<XT> xtlist = new List<XT>();
            foreach (XT xt in xtdic.Values)
            {
                xtlist.Add(xt);
            }
           return WriteRPT(xtlist, savePath);
        }


         public static void WriteRPTToDB(List<RPTXT> xtlist,bool smart) //写报告到数据库
         {

             TextForm dif = new TextForm();
             dif.Show();

             foreach (RPTXT xt in xtlist)
             {
                 string sql = string.Format("select Sverifytime from Sampletable where Sno='{0}'", xt.id);
                 string Sverifytime = DB.ExecuteScalar(sql);
                 dif.appendText(xt.id);
                 if (Sverifytime == "") //如果返回值为空，表示样品不存在
                 {
                     dif.appendText("样品不存在！");
                 }
                 else if (Sverifytime != "/")  //如果已经审核
                 {
                     dif.appendText("样品已审核，无法写入！");
                 }
                 else
                 {
                     dif.appendText("样品未审核，可写入！");

                     foreach (string ys in xt.YSDic.Keys)
                     {
                         if (smart) //智能添加
                         {
                             sql = string.Format("update Resulttable set Tvalue='{0}' where Sno='{1}' and Titem in ('{2}','{2}/TRE','{2}/TREO')", xt.YSDic[ys], xt.id, ys); //尝试写入3种格式
                         }
                         else
                         {
                             sql = string.Format("update Resulttable set Tvalue='{0}' where Sno='{1}' and Titem='{2}'", xt.YSDic[ys], xt.id, ys); //直接照着报告写入即可
                         }


                         //dif.appendText(sql);
                         if (DB.ExecuteNonQuery(sql) > 0)
                         {
                             dif.appendText(string.Format("{0} {1} 成功", ys,xt.YSDic[ys]));
                         }
                         else
                         {
                             dif.appendText(string.Format("{0} {1} 失败！", ys, xt.YSDic[ys]));
                         }
                     }

                 }
                 dif.appendText("-----------------------------------------------------------");
             }

         }



         public static void WriteDB(List<XT> xtlist) //写数据库
         {

             TextForm dif = new TextForm();
             dif.Show();

             foreach (XT xt in xtlist)
             {
                 string sql = string.Format("select Sverifytime from Sampletable where Sno='{0}'", xt.id);
                 string Sverifytime = DB.ExecuteScalar(sql);
                 dif.appendText(xt.id);
                 if (Sverifytime == "") //如果返回值为空，表示样品不存在
                 {
                     dif.appendText("样品不存在！");
                 }
                 else if (Sverifytime != "/")  //如果已经审核
                 {
                     dif.appendText("样品已审核，无法写入！");
                 }
                 else
                 {
                     dif.appendText("样品未审核，可写入！");
                     if (xt.flags[XT.IS_O] == 1)  //如果是氧化物
                     {
                         foreach (YS ys in xt.xtyslist)
                         {
                             string sqlys = Lualib.getYSProp(ys.name, "SQLOName").ToString();
                             sql = string.Format("update Resulttable set Tvalue='{0}' where Sno='{1}' and Titem ='{2}'"
                                 , ys.limitval, xt.id, sqlys);

                             if (DB.ExecuteNonQuery(sql) > 0)
                             {
                                 dif.appendText(string.Format("{0} {1} 成功", sqlys, ys.limitval));
                             }
                             else
                             {
                                 dif.appendText(string.Format("{0} {1} 失败！", sqlys, ys.limitval));
                             }
                         }
                         foreach (YS ys in xt.qtyslist)
                         {
                             string sqlys = Lualib.getYSProp(ys.name, "SQLOName").ToString();
                             sql = string.Format("update Resulttable set Tvalue='{0}' where Sno='{1}' and Titem in ({2})"
                                 , ys.limitval, xt.id, sqlys);

                             if (DB.ExecuteNonQuery(sql) > 0)
                             {
                                 dif.appendText(string.Format("{0} {1} 成功", sqlys, ys.limitval));
                             }
                             else
                             {
                                 dif.appendText(string.Format("{0} {1} 失败！", sqlys, ys.limitval));
                             }
                         }

                     }
                     else
                     {
                         foreach (YS ys in xt.xtyslist)
                         {
                             string sqlys = Lualib.getYSProp(ys.name, "SQLName").ToString();
                             sql = string.Format("update Resulttable set Tvalue='{0}' where Sno='{1}' and Titem ='{2}'"
                                 , ys.limitval, xt.id, sqlys);
                             if (DB.ExecuteNonQuery(sql) > 0)
                             {
                                 dif.appendText(string.Format("{0} {1} 成功", sqlys, ys.limitval));
                             }
                             else
                             {
                                 dif.appendText(string.Format("{0} {1} 失败！", sqlys, ys.limitval));
                             }
                         }
                         foreach (YS ys in xt.qtyslist)
                         {
                             string sqlys = Lualib.getYSProp(ys.name, "SQLName").ToString();
                             sql = string.Format("update Resulttable set Tvalue='{0}' where Sno='{1}' and Titem in ({2})"
                                 , ys.limitval, xt.id, sqlys);
                             if (DB.ExecuteNonQuery(sql) > 0)
                             {
                                 dif.appendText(string.Format("{0} {1} 成功", sqlys, ys.limitval));
                             }
                             else
                             {
                                 dif.appendText(string.Format("{0} {1} 失败！", sqlys, ys.limitval));
                             }

                         }


                     }

                 }
                 dif.appendText("-----------------------------------------------------------");
             }

         }

        public static void saveToTotal(Dictionary<string,XT> XTDic,bool showMsg)    //全局保存
        {
          int n = 0;
            foreach (XT xt in XTDic.Values)
            {
                if (!XT.TotalDic.ContainsKey(xt.id))
                {
                    XT.TotalDic.Add(xt.id, xt);
                }
                else
                {
                    XT.TotalDic[xt.id] = xt;
                    n++;
                }
            }
            if(showMsg)
            {
             MessageBox.Show("共保存样品" + XTDic.Count + "个！其中有" + n + "个样品由于重名被覆盖！");
            }

        }


        /// <summary>
        /// 获取EXCEL中元素行
        /// </summary>
        /// <param name="YSList"></param>
        /// <param name="row"></param>
        /// <param name="starti"></param>
        public static void fillYSList(List<string>YSList,IRow row, int starti)
        {

            for (int i=starti; i< row.LastCellNum; i++)  //横向遍历元素列表
            {
                YSList.Add(row.GetCell(i).StringCellValue.Substring(0, 2).TrimEnd());//直接取元素名，写入ys列表
            }

        }


        /// <summary>
        /// 填充稀土元素数据
        /// </summary>
        /// <param name="xt"></param>
        /// <param name="?"></param>
        public static void fillXTYSData(XT xt,List<string>YSList,IRow row,int startj)
        {
            int j = startj;
            foreach (string ysname in YSList) //创建元素列表
            {
                YS tmpys = null;
                if (xt.xtyslist.Find(ys =>   //如果找不到某元素则添加
                {
                    if (ys.name == ysname)
                    {
                        tmpys = ys;
                        return true;
                    }
                    return false;
                }) == null)
                {
                    tmpys = new YS(ysname);
                    xt.xtyslist.Add(tmpys);
                }


                double tmpdata = ExcelBase.getForceCellDouble(row.GetCell(j));
                if (tmpdata < 0)	//对负数进行判断
                {
                    tmpdata = 0;
                }
                tmpys.originalval.Add(tmpdata);

                j++;
            }
        }



        /// <summary>
        /// 填充其他元素数据
        /// </summary>
        /// <param name="xt"></param>
        /// <param name="YSList"></param>
        /// <param name="row"></param>
        /// <param name="startj"></param>
        public static void fillQTYSData(XT xt, List<string> YSList, IRow row,double[] blankdata, int startj)
        {
            int i = 0;  //用来空白计数
            int j = startj;
            foreach (string ysname in YSList) //创建元素列表
            {
                YS tmpys = null;
                if (xt.qtyslist.Find(ys =>   //如果找不到某元素则添加
                {
                    if (ys.name == ysname)
                    {
                        tmpys = ys;
                        return true;
                    }
                    return false;
                }) == null)
                {
                    tmpys = new YS(ysname);
                    tmpys.blank = blankdata[i]; //写入空白
                    xt.qtyslist.Add(tmpys);
                }
                double tmpdata = ExcelBase.getForceCellDouble(row.GetCell(j));
                if (tmpdata < 0)	//对负数进行判断
                {
                    tmpdata = 0;
                }
                tmpys.originalval.Add(tmpdata);
                i++;
                j++;
            }
        }


    }
}
