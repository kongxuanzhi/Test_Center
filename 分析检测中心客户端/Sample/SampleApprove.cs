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
    public partial class SampleApprove : Form
    {
        public SampleApprove()
        {
            InitializeComponent();
            searchBar1.Init();
            searchBar1.IsverifyBox.Checked = true;
            searchBar1.IsverifyBox.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = SampleControl.getApproveDS().Tables[0];
            searchGridView1.setDataTable(dt);
            if (dt.Rows.Count==0)
            {
                MessageBox.Show("未找到可以授权的样品！");
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (searchBar1.search())
            {
                searchGridView1.setDataTable(searchBar1.getDataTable());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> snos = searchGridView1.getSelectIds();
            if (snos.Count == 0)
            {
                MessageBox.Show("未选中任何样品！");
                return;
            }
            SelectReport sr = new SelectReport(snos);
            sr.MdiParent = this.MdiParent;
            sr.Show();
        }

    }
}
