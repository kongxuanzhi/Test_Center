using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Code;

namespace TRESystem2011.UserControls
{
    public partial class SearchGridView : UserControl
    {

        bool isTestMode = false;
        DataTable m_dt;

        public SearchGridView()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }


        public void setTestMode(bool flag)  //设置成检测部模式
        {
            isTestMode = flag;
            if (isTestMode)
            {
                dataGridView1.Columns["customername"].Visible = false;
                dataGridView1.Columns["ybh"].Visible = false;
            }
            else
            {
                dataGridView1.Columns["customername"].Visible = true;
                dataGridView1.Columns["ybh"].Visible = true;
            }

        }

        public List<string> getSelectIds()  //获取选中的id名
        {
            List<string> ids = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)    //如果勾选则添加进列表中
                {
                    ids.Add(dataGridView1.Rows[i].Cells["Sno"].Value.ToString());
                }

            }
            return ids;
        }

        public void setDataTable(DataTable dt)  //设置数据表格
        {
            m_dt = dt;
            dataGridView1.DataSource = m_dt;
            showColor();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex + "");

            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex == 0) //编号
                {
                    string sqlstr = "select Titem,Tvalue,Tunit from resulttable where sno='" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' and Titem!='/'  order by Tindex";
                    DataTable dt = DB.getDataTable(sqlstr);
                    dataGridView3.DataSource = dt;
                    panel3.Visible = true;

                }
                else if (e.ColumnIndex == 1&&!isTestMode)    //样品名
                {
                    string sqlstr = string.Format("select Sno as [样品编号],Sname as [样品名称],SoriginalNo as [原编号],Sspecification as [样品规格] ,Sgrade as [样品等级],Squantity as [样品数量],customername as [客户名],Sintime as [进样时间],Costtotal as [检验费],Costexpress as [加急费],CostSpreparation as [制样费] from sampletable,customer where sname like '%{0}%' and customername='{1}' and sampletable.cno=customer.customerno order by Sno desc", dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value, dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value);
                    DataTable dt = DB.getDataTable(sqlstr);
                    dataGridView2.DataSource = dt;
                    panel2.Visible = true;
                }
                else if (e.ColumnIndex == 2&&!isTestMode)    //客户名
                {
                    //string sqlstr = "select Sno,Sname,SoriginalNo,Sspecification,Sgrade,Squantity,customername,Sintime,Costtotal from sampletable,customer where customername like '%" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "%' and sampletable.cno=customer.customerno order by Sno desc";
                    string sqlstr = "select CustomerNo as [客户编号],Customername as [客户名称],province as [省],city as [市],address as [地址],relation as [联系人],tel as [电话],fax as [传真],email,postcode as [邮编],net as [网址],introducer as [介绍人],Cintime as [创建时间] from customer where customername ='" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'";
                    DataTable dt = DB.getDataTable(sqlstr);
                    dataGridView2.DataSource = dt;

                    panel2.Visible = true;
                }
            }

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void toolStripSplitButton2_ButtonClick(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            showColor();
        }


        void showColor()
        {
            DateTime today = Libs.getServerDate().Date;
            DateTime Sverifytime;
            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {

                if (DateTime.TryParse(dgvr.Cells["Sverifytime"].Value.ToString(), out Sverifytime)) //如果可以转换成时间
                {
                    if (Sverifytime.Date > Convert.ToDateTime(dgvr.Cells["Scontracttime"].Value).Date)
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.LightPink;
                    }
                    else
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.SkyBlue;
                    }
                }
                else
                {
                    if (today > Convert.ToDateTime(dgvr.Cells["Scontracttime"].Value).Date)
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.DeepPink;
                    }
                    else if (today == Convert.ToDateTime(dgvr.Cells["Scontracttime"].Value).Date)
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                }
            }
        }

//             for (int i = 0; i < dataGridView1.Rows.Count; i++)
//             {
//                 DateTime Sverifytime;
//                 try
//                 {
//                     
//                     Sverifytime = (Convert.ToDateTime(dataGridView1.Rows[i].Cells["Sverifytime"].Value).Date);
//                     if (Sverifytime.Date > (Convert.ToDateTime(dataGridView1.Rows[i].Cells["Scontracttime"].Value).Date))
//                     {
//                         dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightPink; //浅粉色表示做完样，已经超时
//                     }
//                     else
//                     {
//                         dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.SkyBlue;   //天蓝色表示正常时间完成的样品
//                     }
//                 }
//                 catch (Exception)
//                 {
//                     if (today > (Convert.ToDateTime(dataGridView1.Rows[i].Cells["Scontracttime"].Value).Date))
//                     {
//                         dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.DeepPink ;//深粉色表示没做完样，已经超时
//                     }
//                     else if (today == (Convert.ToDateTime(dataGridView1.Rows[i].Cells["Scontracttime"].Value).Date))
//                     {
//                         dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;    //黄色表示今天需出样品
//                     }
//                 }
//             }
//             
//         }



        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exportExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "导出.xls";
            saveFileDialog1.Filter = "Excel文件|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string file = saveFileDialog1.FileName;
            ExcelLib.DGVtoXLs(dataGridView1, file);
            MessageBox.Show("导出完毕！");
        }

        /// <summary>
        /// 自动调整大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 调整窗口大小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void 适合窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


    }
}
