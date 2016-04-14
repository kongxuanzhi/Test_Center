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
    public partial class SampleMoney : Form
    {
        public SampleMoney()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (searchBar1.search())
            {
                searchGridView1.setDataTable(searchBar1.getDataTable());
            }
        }

        private void SampleMoney_Load(object sender, EventArgs e)
        {
            searchBar1.Init();
            searchBar1.wfBox.Checked = true;
            searchBar1.wfBox.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)//选中到账
        {
            List<string> snos = searchGridView1.getSelectIds();
            if (snos.Count == 0)
            {
                MessageBox.Show("未选中任何样品！");
                return;
            }

            string sql = "";
            foreach (string sno in snos)
            {
                sql += string.Format("update sampletable set Costnopay='0' where sno='{0}';",sno);
            }
            if (DB.ExecuteNonQuery(sql) > 0)
            {
                MessageBox.Show("执行成功！");
            }
            else
            {
                MessageBox.Show("执行失败！");
            }


        }
    }
}
