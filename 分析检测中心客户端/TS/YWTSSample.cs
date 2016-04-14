using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
using System.Threading;

namespace TRESystem2011.TS
{
    public partial class YWTSSample : Form
    {
        public YWTSSample()
        {
            InitializeComponent();
            searchBar1.Init();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (searchBar1.search())
            {
                searchGridView1.setDataTable(searchBar1.getDataTable());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<string> snos = searchGridView1.getSelectIds();
            foreach (string sno in snos)
            {
                Sample.SampleModify sm = new Sample.SampleModify();
                sm.initTSSno(sno);
                sm.MdiParent = this.MdiParent;
                sm.Show();
            }
        }

        /// <summary>
        /// 打印特殊报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(printRPT));
            t.Start();
        }

        void printRPT()
        {
 
            InfoForm f = new InfoForm("正在打印中……");
            f.Show();
            ReportFactory rf = new ReportFactory();
            foreach (string sno in searchGridView1.getSelectIds())  //带章打印
            {
                DataSet ds = rf.GetReportDS(sno,"",false);    //获取需要打印的所有数据
                Report.TSReport r = new Report.TSReport();
                r.SetDataSource(ds);
                r.PrintToPrinter(1, true, 0, 0);
            }
            f.Dispose();
        }




        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sno = listBox1.SelectedItem.ToString();
            ReportFactory rf = new ReportFactory();
            DataSet ds = rf.GetReportDS(sno, "", false);   
            Report.TSReport r = new Report.TSReport();
            r.SetDataSource(ds);
            crystalReportViewer1.ReportSource = r;


        }

        /// <summary>
        /// 开启预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreViewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PreViewCheckBox.Checked)
            {
                listBox1.DataSource = searchGridView1.getSelectIds();
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }

        /// <summary>
        /// 发送报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("将对选中样品进行确认发出操作，是否确定？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            string snolist = "";
            foreach (string sno in searchGridView1.getSelectIds())  //遍历所选择的数据
            {
                SampleControl.sendOut(sno);
                snolist += sno + " ";
            }
            MessageBox.Show("样品" + snolist + "已发出！");
        }

        /// <summary>
        /// 导出PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string path = fbd.SelectedPath;

            Thread t = new Thread(new ParameterizedThreadStart(toPDF));
            t.Start(path);

        }

        void toPDF(object path)
        {
            //InfoForm f = new InfoForm("正在导出中……");
            //f.Show();
            //List<string> snos = searchGridView1.getSelectIds();
            //ReportFactory rf = new ReportFactory();
            //foreach (string sno in snos)  //遍历所选择的数据
            //{
            //    string fullpath = string.Format("{0}\\{1}.pdf", path, sno);
            //    rf.getReport(sno, "", false, 3).ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fullpath);
            //}
            //f.Dispose();
            //MessageBox.Show("导出成功！");
        }
    }
}
