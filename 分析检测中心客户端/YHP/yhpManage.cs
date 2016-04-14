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
    public partial class yhpManage : Form
    {
        DataTable m_customerdt = null;

        DataTable m_itemsdt = null;

        public yhpManage()
        {
            InitializeComponent();
        }

        private void yhp_Manage_Load(object sender, EventArgs e)
        {
            button2_Click(null, null);  //初始化1
            button3_Click_1(null, null);  //初始化2
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int result = DB.UpdateDataTable(m_customerdt, "yhp_customer");
            if (result > 0)
            {
                MessageBox.Show(string.Format("成功修改{0}处！", result));
            }
            else
            {
                MessageBox.Show("修改出错或无需修改！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select * from yhp_customer";
            m_customerdt = DB.getDataTable(sql);
            dataGridView1.DataSource = m_customerdt;
        }




        private void yhpCustomerList_DoubleClick(object sender, EventArgs e)
        {

            string sql = "select * from yhp_Items where Cid=" + yhpCustomerList.SelectedValue.ToString();
            m_itemsdt = DB.getDataTable(sql);
            ItemsDGV.DataSource = m_itemsdt;
        }

        /// <summary>
        /// tab2_刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            string sql = "select Cid,CName from yhp_Customer";
            DataTable dt = DB.getDataTable(sql);
            yhpCustomerList.DataSource = dt;
        }

        /// <summary>
        /// tab2_添加新物品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            string cname = yhpCustomerList.Text;
            string cid = yhpCustomerList.SelectedValue.ToString();
            yhpItemAdd f = new yhpItemAdd();
            f.init(cid, cname);
            f.ShowDialog();
        }
    }
}
