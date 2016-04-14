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
    public partial class JCTSSample : Form
    {
        public JCTSSample()
        {
            InitializeComponent();
            searchBar1.Init();
            //searchBar1.tabControl1.SelectedIndex = 2;
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (searchBar1.search())
            {
                searchGridView1.setDataTable(searchBar1.getDataTable());
            }
        }


        /// <summary>
        /// 结果填报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            List<string> snos = searchGridView1.getSelectIds();
            foreach (string sno in snos)
            {
                Test.Testing f = new Test.Testing();
                f.init(sno, true);
                f.MdiParent = this.MdiParent;
                f.Show();
            }
        }

        /// <summary>
        /// 批量填报
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            List<string> snolist = searchGridView1.getSelectIds();
            Test.BatchTesting bt = new Test.BatchTesting();
            bt.MdiParent = this.MdiParent;
            bt.Show();
            bt.init(snolist);
        }

        /// <summary>
        /// 结果审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> snos = searchGridView1.getSelectIds();
            foreach (string sno in snos)
            {
                Test.Testing f = new Test.Testing();
                f.init(sno, false);
                f.MdiParent = this.MdiParent;
                f.Show();
            }
            
        }

        /// <summary>
        /// 批量审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            List<string> snolist = searchGridView1.getSelectIds();
            Test.BatchVerify bv = new Test.BatchVerify();
            bv.MdiParent = this.MdiParent;
            bv.Show();
            bv.init(snolist);
        }
    }
}
