using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;

namespace TRESystem2011.Sample
{
    public partial class SampleTransfer : Form
    {
        public SampleTransfer()
        {
            InitializeComponent();
        }
            
        private void button1_Click(object sender, EventArgs e)  //搜索
        {
            if (searchBar1.search())
            {
                searchGridView1.setDataTable(searchBar1.getDataTable());
            }

        }

        private void SampleTransfer_Load(object sender, EventArgs e)
        {
            searchBar1.Init();
            searchBar1.IsprooferBox.Checked = true;
            searchBar1.IsprooferBox.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)  //查看新进样品（已校对）
        {
            DataTable dt = SampleControl.getSigninDS().Tables[0];
            searchGridView1.setDataTable(dt);
        }



        private void button2_Click(object sender, EventArgs e)  //流转所选
        {
            List<string> snolist = searchGridView1.getSelectIds();
            if (snolist.Count == 0)
            {
                MessageBox.Show("请先选择需要流转的样品！");
                return;
            }

            if (checkBox1.Checked)  //直接打印
            {
                ReportFactory rf = new ReportFactory();
                DataSet ds = rf.GetSampleMoveDS(snolist);
                Report.SampleMove rpt = new TRESystem2011.Report.SampleMove();
                rpt.SetDataSource(ds);
                rpt.PrintToPrinter(1, true, 0, 0);
                MessageBox.Show("已经处理完毕！请等待打印完成~");
            }
            else
            {
                ReportForm rf = new ReportForm();
                rf.initSampleMove(snolist);
                rf.Show();
            }


        }

        private void button3_Click(object sender, EventArgs e)  //智能分类流转所选中的样品
        {
            List<string> snolist = searchGridView1.getSelectIds();
            if (snolist.Count == 0)
            {
                MessageBox.Show("请先选择需要流转的样品！");
                return;
            }
            while (snolist.Count > 0)
            {
                List<string> tmplist = new List<string>();
                string sql = string.Format("select sno from sampletable where sno in({0}) and cno=(select cno from sampletable where sno='{1}')", Libs.arrayToString(snolist.ToArray(), ",", "'"), snolist[0]);
                DataTable dt = DB.getDataTable(sql);
                foreach (DataRow dr in dt.Rows) //遍历搜索出的数据，并从原有的移除，加入新的列表中
                {
                    tmplist.Add(dr["sno"].ToString());
                    snolist.Remove(dr["sno"].ToString());
                }
                if (checkBox1.Checked)  //直接打印
                {
                    ReportFactory rf = new ReportFactory();
                    DataSet ds = rf.GetSampleMoveDS(tmplist);
                    Report.SampleMove rpt = new TRESystem2011.Report.SampleMove();
                    rpt.SetDataSource(ds);
                    rpt.PrintToPrinter(1, true, 0, 0);
                }
                else
                {
                    ReportForm rf = new ReportForm();
                    rf.initSampleMove(tmplist);
                    rf.Show();
                }

            }

            if (checkBox1.Checked)  //直接打印
            {
                MessageBox.Show("已经处理完毕！请等待打印完成~");
            }



        }

        /// <summary>
        /// 导出台帐
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "保存台帐";
            sfd.FileName = "台帐.xls";
            sfd.Filter = "Excel文件|*.xls";
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string path = sfd.FileName;
            List<string> snos = searchGridView1.getSelectIds();
            ExcelLib.ExportTaiZhang(snos, Application.StartupPath + "/template/taizhang.xls", path);
            MessageBox.Show("导出的台帐保存在【"+path+"】");
        }
    }
}
