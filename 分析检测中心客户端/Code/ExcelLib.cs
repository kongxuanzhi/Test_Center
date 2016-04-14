using System;
using System.Collections.Generic;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;
using System.Windows.Forms;
using NPOI.SS.Util;
using NPOI.HSSF;
using NPOI.HSSF.Util;

namespace Code
{
    class ExcelLib
    {

        /// <summary>
        /// 从XLS文件中获取datatable
        /// </summary>
        /// <param name="filename"></param>
        public static DataTable getDataTableFromXLS(string filename)
        {
            FileStream fs=new FileStream(filename,FileMode.Open);
            IWorkbook workbook = new HSSFWorkbook(fs);
            //获取excel的第一个sheet
            ISheet sheet =  workbook.GetSheetAt(0);

            DataTable table = new DataTable();
            //获取sheet的首行
            IRow headerRow = sheet.GetRow(0);
            //一行最后一个方格的编号 即总的列数
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                DataColumn column = new DataColumn(headerRow.GetCell(i).StringCellValue);
                table.Columns.Add(column);
            }
            //最后一列的标号  即总的行数
            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                DataRow dataRow = table.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        dataRow[j] = row.GetCell(j).ToString().Trim();  //此处读取数据后进行去空格处理
                }

                table.Rows.Add(dataRow);
            }

            workbook = null;
            sheet = null;
            return table;
        }

        /// <summary>
        /// 讲XLS导入到DATAGRIDVIEW
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static void fillDGVFromXLS(DataGridView dgv,string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            IWorkbook workbook = new HSSFWorkbook(fs);
            //获取excel的第一个sheet
            ISheet sheet = workbook.GetSheetAt(0);


            //获取sheet的首行
            IRow headerRow = sheet.GetRow(0);
            IRow secondRow= sheet.GetRow(1);
            //一行最后一个方格的编号 即总的列数
            int cellCount = headerRow.LastCellNum;

            for (int i = headerRow.FirstCellNum; i < cellCount; i++)
            {
                dgv.Columns.Add(headerRow.Cells[i].StringCellValue, secondRow.Cells[i].StringCellValue);
            }
            //最后一列的标号  即总的行数
            int rowCount = sheet.LastRowNum;

            for (int i = (sheet.FirstRowNum + 2); i < sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i);
                dgv.Rows.Add();
                int num = dgv.Rows.Count - 1;
                DataGridViewRow dgvr = dgv.Rows[num];
                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {   
                        dgvr.Cells[j].Value = row.Cells[j].StringCellValue;
                    }
                }
            }

            workbook = null;
            sheet = null;
        }

        /// <summary>
        /// datagridview转为excel
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filename"></param>
        public static void DGVtoXLs(DataGridView dgv, string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create);
            HSSFWorkbook workbook = new HSSFWorkbook();
            //获取excel的第一个sheet
            ISheet sheet = workbook.CreateSheet("Sheet1");

            IRow firstrow = sheet.CreateRow(0);
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                IRow row = sheet.CreateRow(i+1);
                for (int j = 0; j < dgv.Rows[i].Cells.Count;j++ )
                {
                    row.CreateCell(j).SetCellValue(dgv.Rows[i].Cells[j].Value.ToString());
                }
            }
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                firstrow.CreateCell(i).SetCellValue(dgv.Columns[i].HeaderText); //设置标题
                sheet.AutoSizeColumn(i);
            }

            workbook.Write(fs);
            fs.Close();
            workbook = null;
            sheet = null;
        }


        /// <summary>
        /// 与上面相对应的导入功能
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="filename"></param>
        public static void XLStoDVG(DataGridView dgv, string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            IWorkbook workbook = new HSSFWorkbook(fs);
            //获取excel的第一个sheet
            ISheet sheet = workbook.GetSheetAt(0);
            //获取sheet的首行
            IRow headerRow = sheet.GetRow(0);
            //一行最后一个方格的编号 即总的列数
            int cellCount = headerRow.LastCellNum;
            //最后一列的标号  即总的行数
            int rowCount = sheet.LastRowNum;

            for (int i = 0; i < sheet.LastRowNum; i++)
            {
                IRow row = sheet.GetRow(i+1);
                DataGridViewRow dgvr = dgv.Rows[i];
                for (int j = 0; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                    {
                        if (!dgvr.Cells[j].ReadOnly)    //如果不是只读
                        {
                            row.GetCell(j).SetCellType(CellType.STRING);  //强制设置为string
                            if (dgvr.Cells[j].Value!=row.Cells[j].StringCellValue)  //不等于才写入
                            {
                                dgvr.Cells[j].Value = row.Cells[j].StringCellValue;
                            }

                        }
                    }
                }
            }

            workbook = null;
            sheet = null;
        }


        /// <summary>
        /// 根据样品编号导出台帐
        /// </summary>
        /// <param name="snos"></param>
        public static void ExportTaiZhang(List<string> snos,string modelPath,string path)
        {
            FileStream rfs = new FileStream(modelPath, FileMode.Open);
            FileStream wfs = new FileStream(path,FileMode.Create);
            HSSFWorkbook workbook = new HSSFWorkbook(rfs);
            //获取excel的第一个sheet
            ISheet sheet = workbook.GetSheetAt(0);
            int i = 3;
            string snoliststr = Libs.arrayToString(snos.ToArray(), ",", "'");
            string sql = "select Sintime,sno,sname,customername,soriginalno from sampletable,customer where sampletable.cno=customer.customerno and sno in (" + snoliststr + ")";
            DataTable dt = DB.getDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                IRow r = sheet.CreateRow(i);
                r.Height = 30*20;
                r.CreateCell(0).SetCellValue(Convert.ToDateTime(dr["Sintime"]).Date.ToShortDateString());
                r.CreateCell(1).SetCellValue(dr["customername"].ToString());
                r.CreateCell(2).SetCellValue(dr["sname"].ToString());
                r.CreateCell(3).SetCellValue(dr["soriginalno"].ToString());
                r.CreateCell(4).SetCellValue(dr["sno"].ToString());
                i++;
            }
            workbook.Write(wfs);
            wfs.Close();
            rfs.Close();
            workbook = null;
            sheet = null;
        }


        public static void DataTable2Excel(DataTable dt,string filename)
        {

            int EXCEL03_MaxRow = 65535;
            FileStream fs = new FileStream(filename, FileMode.Create);
            IWorkbook book = new HSSFWorkbook();
            ISheet sheet = book.CreateSheet();
            if (dt.Rows.Count < EXCEL03_MaxRow)
                DataWrite2Sheet(dt, 0, sheet);
            else
            {
                int page = dt.Rows.Count / EXCEL03_MaxRow;
                for (int i = 0; i < page; i++)
                {
                    int start = i * EXCEL03_MaxRow;
                    int end = (i * EXCEL03_MaxRow) + EXCEL03_MaxRow - 1;
                    DataWrite2Sheet(dt, start, sheet);
                }
                int lastPageItemCount = dt.Rows.Count % EXCEL03_MaxRow;
                DataWrite2Sheet(dt, dt.Rows.Count - lastPageItemCount, sheet);
            }

            book.Write(fs);
            fs.Close();
            book = null;
        }


        /// <summary>
        /// 将table数据写入一个表中
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="startRow"></param>
        /// <param name="endRow"></param>
        /// <param name="book"></param>
        public static void DataWrite2Sheet(DataTable dt, int startRow, ISheet sheet)
        {
                IRow header = sheet.CreateRow(startRow);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = header.CreateCell(i);
                    string val = dt.Columns[i].Caption ?? dt.Columns[i].ColumnName;
                    cell.SetCellValue(val);
                }
            int rowIndex = startRow+1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dtRow = dt.Rows[i];
                IRow excelRow = sheet.CreateRow(rowIndex++);
                for (int j = 0; j < dtRow.ItemArray.Length; j++)
                {
                    excelRow.CreateCell(j).SetCellValue(dtRow[j].ToString());
                }
            }
        }

        /// <summary>
        /// 导出批量报告
        /// </summary>
        /// <param name="snolist"></param>
        /// <param name="filename"></param>
        public static void ExportMuiltyReport(List<string> snolist, string filename)
        {
            string title = "";

            ReportFactory rf = new ReportFactory();

            DataTable dt = rf.getResultsTable(snolist);//结果数据
            dt.Columns.Add("index");    //添加序号列
            dt.Columns["index"].SetOrdinal(0);  //设置到第一个
            int index=1;
            foreach (DataRow dr in dt.Rows)
            {
                dr["index"] = index;
                index++;
            }

            int YSNum = dt.Columns.Count - 3;   //检测项目数量。减去样品名称、原编号、样品编号
            int SampleNum=snolist.Count;    //样品数量

            IWorkbook workbook = new HSSFWorkbook();
            //获取excel的第一个sheet
            ISheet sheet = workbook.CreateSheet();
            sheet.DefaultColumnWidth = 12;  //列宽
            sheet.DefaultRowHeightInPoints = 16.5f;

            ICell Pcell = null;
            ICellStyle Pstyle=null;
            ICellStyle DefaultStyle = null;
            IFont Pfont = null;

            string firstsno = snolist[0];   //第一个样品编号
            string rptName = SampleControl.getReportName(firstsno);

            if (rptName.Contains("jx"))
            {
                title = "江西理工大学分析测试中心";
            }
            else if (rptName.Contains("gj"))
            {
                title = "江西理工大学分析测试中心";
            }

            Pcell = sheet.CreateRow(0).CreateCell(0);
            Pcell.SetCellValue(title);   //写入标题
            DefaultStyle = Pcell.CellStyle; //全局style

            DefaultStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;   
            DefaultStyle.VerticalAlignment = VerticalAlignment.CENTER;              
            Pfont = workbook.CreateFont();
            Pfont.FontName = "宋体";
            Pfont.FontHeightInPoints = 11;
            DefaultStyle.SetFont(Pfont);

            
            Pstyle = workbook.CreateCellStyle();    //写入两个标题的style
            Pstyle.CloneStyleFrom(DefaultStyle);
            Pfont = workbook.CreateFont();
            Pfont.FontName = "宋体";
            Pfont.FontHeightInPoints = 14;
            Pfont.Boldweight = 12 * 240;
            Pstyle.SetFont(Pfont);
            Pcell.CellStyle = Pstyle;

            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 3 + YSNum));

            sheet.CreateRow(1).CreateCell(0).SetCellValue("检 验 报 告");
            sheet.GetRow(1).GetCell(0).CellStyle = Pstyle;
            sheet.AddMergedRegion(new CellRangeAddress(1, 1, 0, 3 + YSNum));
            
            sheet.CreateRow(2).CreateCell(0).SetCellValue("检验批号：");
            Pstyle = workbook.CreateCellStyle();
            Pstyle.CloneStyleFrom(DefaultStyle);    //克隆全局style
            Pstyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;
            sheet.GetRow(2).GetCell(0).CellStyle = Pstyle;

            sheet.AddMergedRegion(new CellRangeAddress(2, 2, 0, 3 + YSNum));
            IRow row3 = sheet.CreateRow(3);
            row3.CreateCell(0).SetCellValue("序号");
            sheet.AddMergedRegion(new CellRangeAddress(3, 4, 0, 0));
            row3.CreateCell(1).SetCellValue("样品编号");
            sheet.AddMergedRegion(new CellRangeAddress(3, 4, 1, 1));
            row3.CreateCell(2).SetCellValue("原编号");
            sheet.AddMergedRegion(new CellRangeAddress(3, 4, 2, 2));
            row3.CreateCell(3).SetCellValue("样品名称");
            sheet.AddMergedRegion(new CellRangeAddress(3, 4, 3, 3));
            row3.CreateCell(4).SetCellValue("分析项目");
            sheet.AddMergedRegion(new CellRangeAddress(3, 3, 4, 2 + YSNum));
            row3.CreateCell(3 + YSNum).SetCellValue("备注");
            sheet.AddMergedRegion(new CellRangeAddress(3, 4, 3 + YSNum, 3 + YSNum));

            DataWrite2Sheet(dt, 4, sheet);

            //以下添加边框
            Pstyle = workbook.CreateCellStyle();
            Pstyle.CloneStyleFrom(DefaultStyle);
            Pstyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            Pstyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            Pstyle.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            Pstyle.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            
            for (int i = 3; i <= 4 + SampleNum; i++)
            {
                for (int j = 0; j <= 3 + YSNum; j++)
                {
                    ICell c = sheet.GetRow(i).GetCell(j) ?? sheet.GetRow(i).CreateCell(j);//检测是否存在，不存在则创建
                    c.CellStyle = Pstyle;
                }
            }


           sheet.CreateRow(5 + SampleNum).CreateCell(0).SetCellValue("以下空白");

           sheet.PrintSetup.PaperSize = 9;  //设置A4纸

            FileStream fs = new FileStream(filename, FileMode.Create);
            workbook.Write(fs);
            fs.Close();
            workbook = null;
        }




        /// <summary>
        /// 批量导出结果数据
        /// </summary>
        /// <param name="snos"></param>
        /// <param name="path"></param>
        public static void ExportResults(List<string> snolist, string filename)
        {
            ReportFactory rf = new ReportFactory();
            DataTable dt=rf.getResultsTable(snolist);
            DataTable2Excel(dt, filename);
        }


        /// <summary>
        /// 导出财务数据
        /// </summary>
        /// <param name="snolist"></param>
        /// <param name="filename"></param>
        public static void ExportCaiWu(List<string> snolist, string filename)
        {
            string snoArrayStr = "('" + string.Join("','", snolist.ToArray()) + "')";
            string sql = "select customername as 客户名,Sno as 样品名称,Soriginalno as 原编号,Sintime as 进样时间,Costtotal as 检测费,Costexpress as 加急费,CostSpreparation as 制样费 from sampletable,customer where customer.customerno=sampletable.cno and sno in " + snoArrayStr + " order by customername";
            DataTable dt = DB.getDataTable(sql);
            DataTable2Excel(dt, filename);
        }


    }
}
