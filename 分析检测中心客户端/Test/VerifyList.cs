using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;

namespace TRESystem2011.Test
{
    public partial class VerifyList : Form
    {
        public VerifyList()
        {
            InitializeComponent();
            searchGridView1.setTestMode(true);
            searchGridView1.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = SampleControl.getHasOutDS();   //查看已经完检，未审核的样品
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
            BatchVerify f = new BatchVerify();
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
            //foreach (string sno in snos)
            //{
            //   Testing t = new Testing();
            if (snos.Count > 0)
            {
                Verify t = new Verify(snos[0]);
                //t.MdiParent = this.MdiParent;
                t.Show();
            }
            //}
        }

        private void WriteinList_Shown(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }
    }
}
