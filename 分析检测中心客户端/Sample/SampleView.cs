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
    public partial class SampleView : Form
    {


        string m_sno="";
        DataRow m_dr;
        DataTable m_dt;

        public SampleView()
        {
            InitializeComponent();
            sampleUC1.init();
            titemsUC1.init();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 根据需要修改的sno初始化
        /// </summary>
        /// <param name="sno"></param>
        public void initSno(string sno)
        {
            m_sno = sno;
            SnoLB.Text = sno;
            SstatusLB.Text = SampleControl.getStatus(sno);

            DataRow dr = DB.getDataRow(string.Format("select * from sampletable where sno='{0}'", sno));
            m_dr = dr;
            sampleUC1.fillControlsByDataRow(m_dr);

            sampleUC1.CnameTB.Text = DB.ExecuteScalar(string.Format("select Customername from sampletable,customer where sno='{0}' and sampletable.cno=customer.customerno", sno));


            DataTable dt = DB.getDataTable(string.Format("select * from resulttable where sno='{0}' order by [Tindex]", sno));
            m_dt = dt;
            titemsUC1.setDataGridView(m_dt);

  
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

       
            this.Dispose();

        }
    }
}
