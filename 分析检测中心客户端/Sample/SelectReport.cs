using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Code;
using CrystalDecisions.CrystalReports.Engine;
using TRESystem2011.Code;
using System.Diagnostics;

namespace TRESystem2011.Sample
{
    public partial class SelectReport : Form
    {

        List<string> snolist;
        Dictionary<string, string> dic;
        Dictionary<string, ReportClass> rptdic;
        bool isFinish = false;

        public SelectReport(List<string> sons)
        {
            InitializeComponent();
            this.snolist = sons;
            dic = new Dictionary<string, string>();
            rptdic = new Dictionary<string, ReportClass>();
        }

        private void SelectReport_Load(object sender, EventArgs e)
        {
            foreach (string sno in snolist)
            {
                string rptname = SampleControl.getReportName(sno);// 不存在就对应没有授权
                dic.Add(sno, rptname);
            }
            listBox1.DataSource = snolist;
            Control.CheckForIllegalCrossThreadCalls = false;
        }
    

        private void button1_Click(object sender, EventArgs e)  //批量授权
        {
            foreach (string sno in listBox1.SelectedItems)
            {
                if (dic[sno] != "")
                {
                    SampleControl.approve(sno, dic[sno]);
                }
            }
            isFinish = true;
            MessageBox.Show("所有样品授权成功！"); 
            showInfo();
        }

        private void SelectReport_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (!isFinish)
            {
                DialogResult dr = MessageBox.Show("尚未确认授权！是否保存修改？", "提醒", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if(dr==DialogResult.Yes)
                {
                    button1_Click(null, null);
                }
            }
        }

        /// <summary>
        /// 显示选中信息
        /// </summary>
        private void showInfo()
        {
            string sno = listBox1.SelectedItem.ToString();
            snolabel.Text = sno;
            if (dic[sno] == "")
            {
                rptlabel.Text = "【尚未授权！】";
            }
            else
            {
                rptlabel.Text = dic[sno].Trim();
            }

            crystalReportViewer1.ReportSource = null;
            if (PreviewCheckBox.Checked && dic[sno] != "")  //如果已经设置了报告并且不为空
            {

                showReport(sno);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() != snolabel.Text)   //如果有变化才重新刷新
            {
                showInfo();
            }
        }


        private void showReport(object o)//显示报表
        {
            string sno = o.ToString();
            ReportClass rc = null;

            //if (rptdic.ContainsKey(sno))
            //{
            //    if (rptdic[sno] != null) //如果有报告，则直接使用
            //    {

            //        rc = rptdic[sno];
            //        crystalReportViewer1.ReportSource = rc;
            //        return;
            //    }
            //}

            //没有报告，则生成一个并存入
            ReportFactory rf = new ReportFactory();
            rc = rf.getReportClass(sno, dic[sno].Trim(),true);
            rptdic[sno] = rc;
            crystalReportViewer1.ReportSource = rc;
        }
         
        private void button2_Click(object sender, EventArgs e)  //预授权
        {
            string rptkind = GetSelectReportKind();
            foreach (string sno in listBox1.SelectedItems)
            {
                dic[sno] = rptkind;
                rptdic[sno] = null;
            }
            showInfo();
        }

        #region 要改的内容

        /// <summary>
        ///need  to  simplified
        /// </summary>
        /// <returns></returns>
        private string GetSelectReportKind()    //获取当前选择的格式
        {
            string reportkind = "";
            //if (radioButton1.Checked)
            //    reportkind = "jx";
            //else if (radioButton2.Checked)
            //    reportkind = "gj";
            //else if (radioButton3.Checked)
            //    reportkind = "gz";

            if (jyRadio.Checked)
            {
                reportkind += "简约格式";
            }
            else if (wzRadio.Checked)
            {
                reportkind += "完整格式";
            }

            if (cmaCB.Checked)
            {
                reportkind += "有CMA";
            }
            //if (calCB.Checked)
            //{
            //    reportkind += "有CAL";
            //}

            //if (cnasCB.Checked)
            //    reportkind += "有CNAS";

            //if (radioButton4.Checked)
            //    reportkind = "gc完整格式";
            //else if (radioButton5.Checked)
            //    reportkind = "sc完整格式";

            return reportkind;
        }



        ///// <summary>
        ///// 点击省
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void radioButton1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton1.Checked)
        //    {
        //        setEnable(true);
        //        cnasCB.Checked = false;
        //        cnasCB.Enabled = false;
        //    }
        //}
        /// <summary>
        /// 点击江西理工大学分析检测中心
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void radioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton2.Checked)
        //    {
        //        setCheck(true);
        //        setEnable(true);
        //    }
        //}

        //void setCheck(bool flag)    
        //{
        //    calCB.Checked = flag;
        //    cmaCB.Checked = flag;
        //    cnasCB.Checked = flag;
        //}

        //void setEnable(bool flag)
        //{
        //    calCB.Enabled = flag;
        //    cmaCB.Enabled = flag;
        //    cnasCB.Enabled = flag;
        //}

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {

            foreach (string sno in listBox1.SelectedItems)
            {
                if (dic[sno] != "")
                {
                    Word审核 审核 = new Word审核(sno);
                    审核.Show();
                }
            }
        }
    }
}