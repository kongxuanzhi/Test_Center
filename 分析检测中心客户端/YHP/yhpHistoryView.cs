using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;

namespace TRESystem2011.YHP
{
    public partial class yhpHistoryView : Form
    {
        public yhpHistoryView()
        {
            InitializeComponent();
        }

        private void yhpView_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string key = "";
            if (cjRB.Checked)
            {
                key = "创建";
            }
            else if(gjRB.Checked)
            {
                key="价格修改";
            }
            else if(rkRB.Checked)
            {
                key="入库";
            }
            else if(ckRB.Checked)
            {
                key="出库";
            }

            string Iname=InameTB.Text;


            DataTable dt = yhpControl.getLogdtByName(Iname,key,false);
            dataGridView1.DataSource = dt;
        }
    }
}
