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
    public partial class SampleSignin : Form
    {
        public SampleSignin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            init();
        }

        void init()
        {

            DataTable dt = SampleControl.getSigninDS().Tables[0];
            searchGridView1.setTestMode(true);
            searchGridView1.setDataTable(dt);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确定签收", "决定", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (string sno in searchGridView1.getSelectIds())
                {
                    SampleControl.signin(sno);
                }
                MessageBox.Show("签收成功！");
                init();
            }
        }

        private void SampleSignin_Shown(object sender, EventArgs e)
        {
            init();
        }
    }
}
