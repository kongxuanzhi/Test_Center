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
    public partial class yhpItemAdd : Form
    {

        string cid = "";

        public yhpItemAdd()
        {
            InitializeComponent();
        }

        private void yhpItemAdd_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 设置对应cid cname
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="cname"></param>
        public void init(string cid, string cname)
        {
            this.cid = cid;
            CNameLB.Text = cname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = InameTB.Text;
            string price = IPriceTB.Text;
            string spec = ISpecTB.Text;
            int totalcount = Convert.ToInt16(TotalCountTB.Text);
            string sql = string.Format("insert into yhp_items(CId,IName,Price,TotalCount,Spec) values({0},'{1}',{2},{3},'{4}')", cid,name, price,totalcount, spec);
            int n = DB.ExecuteNonQuery(sql);
            if (n>0)
            {
                string Iid = DB.ExecuteScalar("select max(Iid) from yhp_items");
                yhpControl.addLog(Iid, "创建", totalcount, "");
                MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
        }
    }
}
