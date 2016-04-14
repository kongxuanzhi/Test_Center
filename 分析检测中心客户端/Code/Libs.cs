using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Web.Security;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization.Formatters.Binary;

namespace Code
{
    static class Libs
    {
        /// <summary>
        /// 初始化一个datarow
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="key"></param>
        public static void initDataRow(DataRow dr,string key)
        {
            for (int i = 0; i < dr.ItemArray.Length;i++ )
            {
                try
                {
                    dr[i] = key;
                }
                catch (System.Exception)
                {
                    continue;
                }
            }
        }

        public static void initDataRowStart(DataRow dr, string key, int s)
        {
            for (int i = s; i < dr.ItemArray.Length; i++)
            {
                try
                {
                    dr[i] = key;
                }
                catch (System.Exception)
                {
                	continue;
                }

            }
        }

        /// <summary>
        /// 只填充空白格
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="key"></param>
        public static void initDataRowBlankCell(DataRow dr, string key)
        {
            for (int i = 0; i < dr.ItemArray.Length; i++)
            {
                if (dr[i].ToString() == "")
                {
                    try
                    {
                        dr[i] = key;
                    }
                    catch (System.Exception)
                    {
                    	continue;
                    }

                }

            }
        }

        public static List<string> getSelectIds(DataGridView dgv)  //获取选中的id名
        {
            List<string> ids = new List<string>();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Selected)    //如果勾选则添加进列表中
                {
                    ids.Add(dgv.Rows[i].Cells["Sno"].Value.ToString());
                }

            }
            return ids;
        }

        public static List<string> getSelectIds(DataGridView dgv, string ColumnName)
        {
            List<string> ids = new List<string>();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (dgv.Rows[i].Selected)    //如果勾选则添加进列表中
                {
                    ids.Add(dgv.Rows[i].Cells[ColumnName].Value.ToString());
                }

            }
            return ids;
        }

        public static string arrayToString(string[] strArray,string fgf,string bwf)  //字符串数组拼成字符串 分隔符，包围符
        {
             StringBuilder str = new StringBuilder();
            for (int i=0; i < strArray.Length; i++)
             { 
                 if (i > 0)
                 { 
              //分割符可根据需要自行修改
                  str.Append(fgf);
                  }
             str.Append(bwf+strArray[i]+bwf);
             }
            return str.ToString();
        }
               
        /// <summary>
        /// sha加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string sha(string s)
         {
             return FormsAuthentication.HashPasswordForStoringInConfigFile(s, "SHA1");
         }
        /// <summary>
        /// 获取年份
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string getShortYear(DateTime dt)
        {
            return dt.Year.ToString();  //改
            
        }



        /// <summary>
        /// 获取图片文件字节
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static byte[] getFileBytes(string path)    
        {
            string fullpath = Application.StartupPath + "/" + path;
            FileStream fs1 = new FileStream(fullpath, FileMode.Open, FileAccess.Read);
            BinaryReader br1 = new BinaryReader(fs1);
            byte[] bt1 = br1.ReadBytes((int)fs1.Length);
            br1.Close();
            return bt1;
        }

        /// <summary>
        /// 获取textbox的每一行字符串数组
        /// </summary>
        /// <param name="rtb"></param>
        /// <returns></returns>
        public static string[] getTextBoxLines(TextBox tb)
        {
            return tb.Text.Split((new string[3] { "\r", "\n", "\r\n" }), StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool checkControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox || c is ComboBox)
                {
                    if (c.Text.Trim() == "")
                    {
                        c.Focus();  //如果找到不全的则设置焦点
                        c.BackColor = Color.LightYellow;
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 获取某个控件的快照
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static byte[] getControlImage(Control ctrl)
        {
            MemoryStream ms = null;
            try
            {
                Bitmap bitmap = new Bitmap(ctrl.Size.Width, ctrl.Size.Height);
                Graphics g = Graphics.FromImage(bitmap);
                g.CopyFromScreen(ctrl.PointToScreen(Point.Empty), Point.Empty, ctrl.Size);
                ms = new MemoryStream();//用来保存的内存流
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] byteImage = ms.ToArray();
                return byteImage;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            finally
            {
                ms.Close();
            }


        }

        public static DataTable DataGridViewToDataTable(DataGridView dv)
        {
            DataTable dt = new DataTable();
            DataColumn dc;
            for (int i = 0; i < dv.Columns.Count; i++)
            {
                dc = new DataColumn();
                dc.ColumnName = dv.Columns[i].Name.ToString();
                dt.Columns.Add(dc);
            }
            for (int j = 0; j < dv.Rows.Count; j++)
            {
                try
                {
                    if(dv.Rows[j].Cells[0].Value.ToString()=="")    //遇到空值则直接下一行
                    {
                        continue;
                    }
                    DataRow dr = dt.NewRow();
                    for (int x = 0; x < dv.Columns.Count; x++)
                    {
                        dr[x] = dv.Rows[j].Cells[x].Value;
                    }
                    dt.Rows.Add(dr);
                }
                catch (Exception)
                {

                }
            }
            return dt;
        }

        /// <summary>
        /// 用控件填充datarow
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="control"></param>
        public static void fillDataRow(DataRow dr, Control control)
        {
            foreach (Control c in control.Controls)
            {
                try
                {
                    string tmpname = c.Name.Substring(0, c.Name.Length - 2);
                    if (dr[tmpname] != null)
                    {
                        dr[tmpname] = c.Text.Trim();
                        //MessageBox.Show(tmpname+" "+c.Text);
                    }
                }
                catch (System.Exception)
                {

                }
            }
        }




        /// <summary>
        /// 用datarow填充control
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="control"></param>
        public static void fillControl(DataRow dr, Control control)
        {
            foreach (Control c in control.Controls)
            {
                try
                {
                    string tmpname = c.Name.Substring(0, c.Name.Length - 2);
                    if (dr[tmpname] != null)
                    {
                        c.Text = dr[tmpname].ToString().Trim();
                    }
                }
                catch (System.Exception)
                {

                }
            }
        }


        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public static DateTime getServerDate()
        {
            if (User.grant.Contains("时间控制"))    //如果有时间控制权限，则使用本地时间
            {
                return DateTime.Now;
            }
            return Convert.ToDateTime(DB.ExecuteObject("select getdate()"));
        }

        /// <summary>
        /// 获取服务器时间字符串
        /// </summary>
        /// <returns></returns>
        public static string getServerDateStr()
        {
            if (User.grant.Contains("时间控制"))    //如果有时间控制权限，则使用本地时间
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }

            return DB.ExecuteScalar("Select CONVERT(varchar(100), GETDATE(), 120)");
        }


        public static void Serialize(object obj, string filePath)   //序列化到文件
        {
            BinaryFormatter transfer = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            transfer.Serialize(ms, obj);

            byte[] b = new byte[ms.Length];
            b = ms.GetBuffer();

            FileStream fs = File.Create(filePath);
            fs.Write(b, 0, b.Length);

            ms.Close();
            fs.Close();
        }

        public static object Deserialize(string filePath)   //读取出来
        {
            if (!File.Exists(filePath))
            {
                return null;
            }
            FileStream fs = File.OpenRead(filePath);
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, b.Length);
            fs.Close();

            BinaryFormatter transfer = new BinaryFormatter();
            MemoryStream ms = new MemoryStream(b);
            object t = transfer.Deserialize(ms);
            ms.Close();
            return t;
        }

        public static string AppPath()
        {
            return System.Windows.Forms.Application.StartupPath; 

        }

        public static bool checkDT(DataTable dt)    //检查datatable是否含有空数据
        {
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[i][0].ToString().Trim()))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool judgeData(string exp, string data)   //判断数据是否符合标准
        {
            double val;
            if (data.StartsWith(">") || data.StartsWith("≥")) 
            {
                val = Convert.ToDouble(data.Substring(1))+0.0000001;
            }
            else if (data.StartsWith("<") || data.StartsWith("≤"))
            {
                val = Convert.ToDouble(data.Substring(1)) - 0.0000001;
            }
            else
            {
                val = Convert.ToDouble(data);
            }


            if (exp.Contains("≥")) //需要大于等于
            {

                double e = Convert.ToDouble(exp.Split('≥')[1]);    //取拆分后的数据

                if (e > val)
                {
                    return false;
                }
            }
            else if (exp.Contains("≤"))    //需要小于等于
            {
                double e = Convert.ToDouble(exp.Split('≤')[1]);    //取拆分后的数据
                if (e < val)
                {
                    return false;
                }
            }
            else if (exp.Contains("±"))    //区间
            {
                string[] tmp = exp.Split('±');
                double e1 = Convert.ToDouble(tmp[0]);
                double e2 = Convert.ToDouble(tmp[1]);
                if (val < e1 - e2 || val > e1 + e2) //如果超出区间范围 判定为不合格
                {
                    return false;
                }
            }

            return true;
        }

    }

}
