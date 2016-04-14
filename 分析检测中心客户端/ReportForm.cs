//liyang 20120818
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
namespace TRESystem2011
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        public string reportkind = "";
        public string sno = "";
        public bool stamp = false;


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public void initApprove(string sno, string reportkind) //批准打印
        {
            this.sno = sno;
            this.reportkind = reportkind;
            ReportFactory rf = new ReportFactory();
            rf.FillReportViewer(crystalReportViewer1, sno, reportkind,true);

        }

        public void initSampleMove(List<string> snolist)  //查看流转卡
        {
            ReportFactory rf = new ReportFactory();
            DataSet ds = rf.GetSampleMoveDS(snolist);
            Report.SampleMove rpt = new Report.SampleMove();
            rpt.SetDataSource(ds);
            crystalReportViewer1.ReportSource = rpt;
        }

        public void initAttention() //查看注意事项
        {
            Report.Attention rpt = new Report.Attention();
            crystalReportViewer1.ReportSource = rpt;
        }

        public void initReport(string sno,bool stamp)//查看最终报告
        {
            this.sno=sno;
            this.stamp=stamp;
            ReportFactory rf = new ReportFactory();
            rf.FillReportViewer(crystalReportViewer1, sno, stamp,0);
        }


        public void View(string sno) //单纯的查看
        {
            this.sno = sno;
            ReportFactory rf = new ReportFactory();
            rf.FillReportViewer(crystalReportViewer1, sno, "简约格式",true);
            crystalReportViewer1.ShowPrintButton = false;
        }

  
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}