using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Data;



namespace ICPTOOLS_DONET
{
    /// <summary>
    /// 封装了EXCEL的基本操作
    /// </summary>
    class ExcelBase  
    {

        public string m_path;   //当前打开的文件名
        public IWorkbook workbook;
        public ISheet sheet;
 

        public ExcelBase()
        {

        }


        /// <summary>
        /// 强行返回double
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static double getForceCellDouble(ICell cell)
        {
            if (cell.CellType == CellType.NUMERIC)
            {
                return cell.NumericCellValue;
            }
            else if (cell.CellType == CellType.STRING)
            {
                try
                {
                    return Convert.ToDouble(cell.StringCellValue);  //尝试返回转换后的值
                }
                catch (System.Exception)
                {
                    return 0;//如果发生异常无法强制转换，直接return0
                }
                //.Split(' '))[0]); //去掉后面的东东
            }
            return 0;
        }

        /// <summary>
        /// 强行返回字符串
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static string getForceCellStr(ICell cell)
        {
            if (cell.CellType == CellType.NUMERIC)
            {
                return cell.NumericCellValue.ToString();
            }
            else if (cell.CellType == CellType.STRING)
            {
                return cell.StringCellValue;
            }
            return "";
        }

        public bool open(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            workbook = new HSSFWorkbook(fs);
            sheet = workbook.GetSheetAt(workbook.ActiveSheetIndex); //获取当前活动的sheet
            m_path = path;
            fs.Close();
            return true;
        }

        public void openFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "EXCEL文件|*.xls|所有文件|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                open(ofd.FileName);
            };

        }

        /// <summary>
        /// 保存
        /// </summary>
        public void save()
        {
            FileStream file = new FileStream(m_path, FileMode.Create);
            workbook.Write(file);
            file.Close();
        }

        /// <summary>
        /// 另存为
        /// </summary>
        /// <param name="path"></param>
        public void saveCopyAS(string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            workbook.Write(file);
            file.Close();
        }

        public void setCell(int x, int y, string str)
        {
            sheet.GetRow(x).GetCell(y).SetCellValue(str);
        }


        public ICell getCell(int x, int y)
        {
            return sheet.GetRow(x).GetCell(y);
        }

        public string getCellStr(int x,int y)
        {
            try
            {
                return sheet.GetRow(x).GetCell(y).StringCellValue;
            }
            catch (System.Exception)
            {
                return "";
            }

        }

        public double getCellDouble(int x, int y)
        {
            try
            {
                return sheet.GetRow(x).GetCell(y).NumericCellValue;
            }
            catch (System.Exception)
            {
                return 0;
            }
  
        }


        public bool CellTest(int x,int y,string str)	//测试某个cell是否存在某值
        {
	       string tmpstr;
            try
            {
                tmpstr = getCellStr(x, y);
            }
            catch (System.Exception) //发生异常则直接为否
            {
                return false;
            }

           if(tmpstr.Contains(str))
		   {
			   return true;
		   }	

	        return false;
        }

        public bool CellTestS(int x, int y, string str)  //测试某个cell是否以str开头
        {
	       string tmpstr;
            try
            {
                tmpstr = getCellStr(x, y);
            }
            catch (System.Exception)
            {
                return false;
            }

           if(tmpstr.StartsWith(str))
		   {
			   return true;
		   }	

	        return false;
        }

        /// <summary>
        /// 测试某个cell是否包含str
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public bool CellTestC(int x, int y, string str)  
        {
            string tmpstr;
            try
            {
                tmpstr = getCellStr(x, y);
            }
            catch (System.Exception)
            {
                return false;
            }

            if (tmpstr.Contains(str))
            {
                return true;
            }

            return false;
        }

        public ICell FindCell(string str, int maxi, int maxj)  //快速封装的全文匹配
        {
            return FindCellEx(str, 0, maxi, 0, maxj);
        }

        public ICell FindCellS(string str, int maxi, int maxj)  //快速封装的首字
        {
            return FindCellSEx(str, 0, maxi, 0, maxj);
        }

        public ICell FindCellC(string str, int maxi, int maxj)  //快速封装的首字
        {
            return FindCellCEx(str, 0, maxi, 0, maxj);
        }

        /// <summary>
        /// 包含的查找定位
        /// </summary>
        /// <param name="str"></param>
        /// <param name="starti"></param>
        /// <param name="maxi"></param>
        /// <param name="startj"></param>
        /// <param name="maxj"></param>
        /// <returns></returns>
        public ICell FindCellCEx(string str, int starti, int maxi, int startj, int maxj) 
        {
            for (int i = starti; i <= maxi; i++)
            {
                for (int j = startj; j <= maxj; j++)
                {
                    if (CellTestC(i, j, str))
                    {
                        return getCell(i, j);
                    }
                }
            }
            return null;
        }



        public ICell FindCellEx(string str, int starti, int maxi, int startj, int maxj) //查找定位
        {
	        for(int i=starti;i<=maxi;i++)
	        {
		        for (int j=startj;j<=maxj;j++)
		        {
                        if (CellTest(i,j,str))
			            {
                            return getCell(i, j);
			            }
		        }
	        }
            return null;
        }

        /// <summary>
        /// 开头查找定位
        /// </summary>
        /// <param name="str"></param>
        /// <param name="starti"></param>
        /// <param name="maxi"></param>
        /// <param name="startj"></param>
        /// <param name="maxj"></param>
        /// <returns></returns>
        public ICell FindCellSEx(string str, int starti, int maxi, int startj, int maxj)
        {
            for (int i = starti; i <= maxi; i++)
            {
                for (int j = startj; j <= maxj; j++)
                {
                    if (CellTestS(i, j, str))
                    {
                        return getCell( i, j);
                    }
                }
            }
            return null;
        }


        public void close()
        {
            sheet = null;
            workbook = null;
        }


//         public static void ClipToDVG(DataGridView dataGridView1)  //从剪切板复制到dvg
//         {
//             try
//             {
//                 int cRowIndex = dataGridView1.CurrentCell.RowIndex;
//                 int cColIndex = dataGridView1.CurrentCell.ColumnIndex;
//                 //最后一行为新行
//                 int rowCount = dataGridView1.Rows.Count - 1;
//                 int colCount = dataGridView1.ColumnCount;
//                 //获取剪贴板内容
//                 string pasteText = Clipboard.GetText();
//                 //判断是否有字符存在
//                 if (string.IsNullOrEmpty(pasteText))
//                     return;
//                 //以换行符分割的数组
//                 string[] lines = pasteText.Trim().Split('\n');
//                 int txtLength = lines.Length;
//                 DataRow row;
//                 //判断是修改还是添加,如果dgv中行数减当前行号大于要粘贴的行数，直接修改
//                 if (rowCount - cRowIndex > txtLength)
//                 {
//                     for (int j = cRowIndex; j < cRowIndex + txtLength; j++)
//                     {
//                         //以制表符分割的数组
//                         string[] vals = lines[j - cRowIndex].Split('\t');
//                         //判断要粘贴的列数与dgv中列数减当前列号的大小，取最小值
//                         int minColLength = vals.Length > colCount - cColIndex ? colCount -
// 
// cColIndex : vals.Length;
//                         row = dataGridView1.Rows[j];
//                         for (int i = 0; i < minColLength; i++)
//                         {
//                             row[i + cColIndex] = vals[i];
//                         }
//                     }
//                 }
//                 //否则先修改后添加
//                 else
//                 {
//                     //修改
//                     for (int j = cRowIndex; j < rowCount; j++)
//                     {
//                         string[] vals = lines[j - cRowIndex].Split('\t');
//                         int minColLength = vals.Length > colCount - cColIndex ? colCount -
// 
// cColIndex : vals.Length;
//                         row = dataGridView1.Rows[j];
//                         for (int i = 0; i < minColLength; i++)
//                         {
//                             row[i + cColIndex] = vals[i];
//                         }
//                     }
//                     //添加
//                     for (int j = rowCount; j < cRowIndex + txtLength; j++)
//                     {
//                         string[] vals = lines[j - cRowIndex].Split('\t');
//                         int minColLength = vals.Length > colCount - cColIndex ? colCount -
// 
// cColIndex : vals.Length;
//                         //新行
//                         row = dataGridView1.NewRow();
//                         for (int i = 0; i < minColLength; i++)
//                         {
//                             row[i + cColIndex] = vals[i];
//                         }
//                         //添加到dgv数据源中
//                         dataGridView1.Rows.Add(row);
//                     }
//                     if (cRowIndex == rowCount)
//                         dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count);
//                 }
//             }
//             catch (Exception MyEx)
//             {
//                 MessageBox.Show(MyEx.Message);
//             }
//         }



    }
}
