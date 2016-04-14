using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
using System.Threading;

namespace TRESystem2011.Sample
{
    public partial class PrintReport : Form
    {

        int pint = 0;

        public PrintReport()
        {
            InitializeComponent();
        }

        private void PrintReport_Load(object sender, EventArgs e)
        {

            //Control.CheckForIllegalCrossThreadCalls = false;
            searchBar1.Init();
            searchBar1.IsapproveBox.Checked=true;
            searchBar1.IsapproveBox.Enabled = false;
            printTypeCB.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = SampleControl.getSendOutDS().Tables[0];
            searchGridView1.setDataTable(dt);
        }

        private void button3_Click(object sender, EventArgs e)  //批量打印
        {
            Thread t = new Thread(new ThreadStart(printRPT));
            t.Start();
          //  printRPT();
            
        }

        void printRPT()
        {
            InfoForm f = new InfoForm("正在打印中……");
            f.Show();
            int n = Convert.ToInt32(numericUpDown1.Value);
            ReportFactory rf = new ReportFactory();
            if (stampCB.Checked)
            {
                foreach (string sno in searchGridView1.getSelectIds())  //带章打印
                {
                    f.setMsg(string.Format("正在处理{0}……", sno));
                    Application.DoEvents();
                    rf.printReport(sno, true,n,pint);
                }
            }
            else
            {
                foreach (string sno in searchGridView1.getSelectIds())  //不带章打印
                {
                    f.setMsg(string.Format("正在处理{0}……", sno));
                    Application.DoEvents();
                    rf.printReport(sno, false,n,pint);
                }
            }
            f.Dispose();
        }

        public static string GetReportKind(int type)
        {
            string reportkind = "";
            //if(stampCB.Checked == true)
            //{
            //    if (type == 0)
            //        reportkind = "简约格式有CMA";
            //    else
            //    {
            //        reportkind = "完整格式有CMA";
            //    }
            //}
            //else
            //{
            //    if (type == 0)
            //        reportkind = "简约格式";
            //    else
            //    {
            //        reportkind = "完整格式";
            //    }
            //}
            return reportkind;
        }


        private void button4_Click(object sender, EventArgs e) //批量发出
        {
            if (MessageBox.Show("将对选中的样品进行确认发出操作，是否确定？","提示",MessageBoxButtons.OKCancel)==DialogResult.Cancel)
            {
                return;
            }
            string snolist="";
            foreach (string sno in searchGridView1.getSelectIds())  //遍历所选择的数据
            {
                if (SampleControl.getStatus(sno) == "待发送")   //只对未发送的数据做发送处理
                {
                    SampleControl.sendOut(sno);
                    snolist += sno + " ";
                }
            }
            MessageBox.Show("样品" + snolist + "已发出！");
        }

        private void button2_Click(object sender, EventArgs e)  //搜索
        {
            if (searchBar1.search())
            {
                searchGridView1.setDataTable(searchBar1.getDataTable());
            }

        }

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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sno = listBox1.SelectedItem.ToString();
            ReportFactory rf = new ReportFactory();
            if(stampCB.Checked)
            {
                rf.FillReportViewer(crystalReportViewer1, sno, true,pint);
            }
            else
            {
                rf.FillReportViewer(crystalReportViewer1, sno, false,pint);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)    //批量导出PDF
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string path = fbd.SelectedPath;

            Thread t = new Thread(new ParameterizedThreadStart(toPDF));
            t.Start(path);
            toPDF(path);
       
        }

        void toPDF(object path)
        {
            InfoForm f = new InfoForm("正在导出中……");
            f.Show();
            List<string> snos = searchGridView1.getSelectIds();
            ReportFactory rf = new ReportFactory();
            foreach (string sno in snos)  //遍历所选择的数据
            {
                f.setMsg(string.Format("正在处理{0}……", sno));
                Application.DoEvents();
                string sqlstr = "select reportname from QStamp where samplenumber='" + sno + "'";
                string reportkind = DB.ExecuteScalar(sqlstr);  //获取报告形式
                string fullpath = string.Format("{0}\\{1}.pdf", path, sno);
              // rf.getReport(sno, reportkind, stampCB.Checked, pint).ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fullpath);
                rf.getReportClass(sno, reportkind, stampCB.Checked).ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fullpath);
            }
            f.Dispose();
            MessageBox.Show("导出成功！");
        }

        private void printTypeCB_SelectedIndexChanged(object sender, EventArgs e)   //切换模式
        {
            pint = printTypeCB.SelectedIndex;
            //MessageBox.Show(pint.ToString());
        }

        /// <summary>
        /// 导出批量报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = "批量报告.xls";
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = sfd.FileName;
            List<string> snos = searchGridView1.getSelectIds();
            ExcelLib.ExportMuiltyReport(snos, filename);
            MessageBox.Show("导出成功！");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            foreach (string sno in searchGridView1.getSelectIds())  
            {
                Word审核 审核 = new Word审核(sno);
                审核.Show();
            }
        }
    }
}
