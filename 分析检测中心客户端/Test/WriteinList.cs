using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
using TRESystem2011.Sample;

namespace TRESystem2011.Test
{
    public partial class WriteinList : Form
    {
        public WriteinList()
        {
            InitializeComponent();
            searchGridView1.setTestMode(true);
            searchGridView1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = SampleControl.getVerifyDS();   //查看可以授权的DS
            searchGridView1.setDataTable(ds.Tables[0]);
        }

        /// <summary>
        /// 批量填报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> snos = searchGridView1.getSelectIds();
            BatchTesting f = new BatchTesting();
            f.MdiParent = this.MdiParent;
            f.Show();
            f.init(snos);
        }


        /// <summary>
        /// 单个填报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            List<string> snos = searchGridView1.getSelectIds();

            foreach (string sno in snos)
            {
                ResultSubmit f = new ResultSubmit(sno);
                //Testing t = new Testing();
                //t.init(sno, true);
               // f.MdiParent = this.MdiParent; //就是这一句错了
                f.Show();
            }
           
        }

        private void WriteinList_Shown(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }


    }
}
