using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Code;
using System.Text.RegularExpressions;

namespace TRESystem2011.UserControls
{
    public partial class SampleUC : UserControl
    {
        public SampleUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Customer.CustomerForm f = new Customer.CustomerForm();
            f.c1 = CnoTB;
            f.c2 = CnameTB;
            f.setSelectMode(true);
            f.ShowDialog();
        }

        /// <summary>
        /// 获取得到的row
        /// </summary>
        public DataRow getNewDataRow()
        {
            DataTable dt = DB.getEmptyTableByTableName("sampletable");
            DataRow dr = dt.NewRow();
            Libs.initDataRow(dr, "/");
             
            dr["Sintime"] = jyDatePicker.Value.ToString("yyyy-MM-dd HH:mm:ss"); //入样时间
            dr["Scontracttime"] = hyDatePicker.Value.ToString("yyyy-MM-dd"); // 协议时间

            Libs.fillDataRow(dr, infoGroupBox); //
            Libs.fillDataRow(dr, costGroupBox);

            if (extraCheckBox.Checked)//如果启用了扩展属性
            {
                Libs.fillDataRow(dr, extraGroupBox);
            }
            return dr;
        }

        /// <summary>
        /// 填充外面传入的dr
        /// </summary>
        /// <param name="dr"></param>
        public int  fillDataRowByControls(DataRow dr,bool info,bool jy,bool hy,bool cost)
        {
            int n = 0;  //需要更新的项目
            if (jy)
            {
                dr["Sintime"] = jyDatePicker.Value.ToString("yyyy-MM-dd HH:mm:ss");
                n++;
            }
            if (hy)
            {
                dr["Scontracttime"] = hyDatePicker.Value.ToString("yyyy-MM-dd");
                n++;
            }
            if (info)
            {
                Libs.fillDataRow(dr, infoGroupBox);
                Libs.fillDataRow(dr, extraGroupBox);
                n++;
            }
            if (cost)
            {
                Libs.fillDataRow(dr, costGroupBox);
                n++;
            }
            return n;
        }

        /// <summary>
        /// 根据外面传入的dr填充controls
        /// </summary>
        /// <param name="dr"></param>
        public void fillControlsByDataRow(DataRow dr)
        {
            try
            {
                jyDatePicker.Value = Convert.ToDateTime(dr["Sintime"]);
                hyDatePicker.Value = Convert.ToDateTime(dr["Scontracttime"]);
                Libs.fillControl(dr, infoGroupBox);
                Libs.fillControl(dr, costGroupBox);
                Libs.fillControl(dr, extraGroupBox);
            }
            catch (System.Exception)
            {
                MessageBox.Show("读取样品数据失败！");
            }
        }


        /// <summary>
        /// 预读datarow写入控件
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public void setDataRow(DataRow dr)
        {
            jyDatePicker.Value = Convert.ToDateTime(dr["Sintime"]);
            hyDatePicker.Value=Convert.ToDateTime(dr["Scontracttime"]);
            Libs.fillDataRow(dr, infoGroupBox);
            Libs.fillDataRow(dr, costGroupBox);
        }



//         /// <summary>
//         /// 通过控件名称将内容加载进datarow中
//         /// </summary>
//         /// <param name="dr"></param>
//         /// <param name="control"></param>
//         void fillDataRow(DataRow dr, Control control)
//         {
//             foreach (Control c in control.Controls)
//             {
//                 try
//                 {
//                     string tmpname = c.Name.Substring(0, c.Name.Length - 2);
//                     if (dr[tmpname] != null)
//                     {
//                         dr[tmpname] = c.Text.Trim();
//                         //MessageBox.Show(tmpname+" "+c.Text);
//                     }
//                 }
//                 catch (System.Exception)
//                 {
// 
//                 }
//             }
// 
//         }

//         /// <summary>
//         /// 通过控件名称将datarow内容加载进控件中
//         /// </summary>
//         /// <param name="dr"></param>
//         void fillControl(DataRow dr, Control control)
//         {
//             foreach (Control c in control.Controls)
//             {
//                 try
//                 {
//                     string tmpname = c.Name.Substring(0, c.Name.Length - 2);
//                     if (dr[tmpname] != null)
//                     {
//                         c.Text = dr[tmpname].ToString().Trim();
//                     }
//                 }
//                 catch (System.Exception)
//                 {
// 
//                 }
//             }
//         }

        /// <summary>
        /// 检查控件是否都已经填写完毕
        /// </summary>
        /// <returns></returns>
        public string getChecks()
        {
            if(!Libs.checkControls(infoGroupBox))
            {
                return "基本信息不全";
            }
            if (!Libs.checkControls(costGroupBox))
            {
                return "费用问题不全";
            }

            return null;
        }




        /// <summary>
        /// 初始化控件
        /// </summary>
        public void init()
        {
            TkindCB.DataSource = DB.getDataTable("select distinct(Tkind) from sampletable");
            TkindCB.Text = "委托检验";
            SkindCB.DataSource = DB.getDataTable("select ID from SampleKinds order by i");
           // SgradeCB.DataSource = DB.getDataTable("select distinct(sgrade) from sampletable");
           // SgradeCB.Text = "/";
            SstateCB.DataSource = DB.getDataTable("select distinct(Sstate) from sampletable");
            SstateCB.Text = "粉状";
           // ScanretestCB.SelectedIndex = 0;
            RgivemodeCB.SelectedIndex = 0;
            ShandleCB.SelectedIndex = 0;
            CostmodeCB.SelectedIndex = 0;

            initTime();

        }

        /// <summary>
        /// 刷新当前时间
        /// </summary>
        public void initTime()
        {
            jyDatePicker.Value = Libs.getServerDate();
            jyDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        /// <summary>
        /// 启用扩展
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void extraCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           if (extraCheckBox.Checked)
           {
               extraGroupBox.Enabled = true;
           } 
           else
           {
               extraGroupBox.Enabled = false;
           }
        }

        private void hyDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 自动获取客户名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CnoTB_Leave(object sender, EventArgs e)
        {
            string cno = CnoTB.Text;
            if (cno != "")  //如果不为空
            {
                try
                {
                    string cname = DB.ExecuteScalar("select customername from customer where CustomerNo='" + cno + "'");
                    CnameTB.Text = cname;
                    if (cname=="")
                    {
                        MessageBox.Show("无此客户！请检查客户编号！");
                        CnoTB.BackColor = Color.LightYellow;
                        //CnoTB.Focus();
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("获取客户数据失败！");
                }

            }

        }
        private void SOriginalNoTB_TextChanged(object sender, EventArgs e)
        {
            string SoriginalNos = Regex.Replace(SOriginalNoTB.Text, "(\\r\\n)+", ",");
            string[] OrNos = SoriginalNos.Split(',');
            SquantityTB.Text = string.IsNullOrEmpty(OrNos[OrNos.Length - 1])?(OrNos.Length - 1).ToString(): (OrNos.Length).ToString();
            if (OrNos.Length > 15)
            {
                MessageBox.Show("原样数量不要超过15，,否则会乱的");
            }
        }
    }
}
