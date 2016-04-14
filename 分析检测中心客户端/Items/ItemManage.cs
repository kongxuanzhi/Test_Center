using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
using System.IO;
using System.Data.OleDb;

namespace TRESystem2011.Items
{
    public partial class ItemManage : Form
    {

        DataTable dt;

        public ItemManage()
        {
            InitializeComponent();
        }

        private void UploadMark_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dataSet1.Users”中。您可以根据需要移动或移除它。

            init();
        }


        private void init()
        {
            dt = DB.getDataTable("select * from [Itemtable]");
            dataGridView1.DataSource = dt;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter oda = DB.getAdapterByTableName("Itemtable");
            DataRow dr;
            try
            {
                string titem = dataGridView1.SelectedRows[0].Cells["Titem"].Value.ToString();    //选中的第一个样品
                string sql = "select * from itemtable where titem='" + titem + "'";
                dr= DB.getDataRow(sql);
                dr["image"] = Libs.getControlImage(richTextBox1);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show("出错！"+ex.Message);
                return;
            }

            if (oda.Update(dr.Table) > 0)
            {
                MessageBox.Show("更新成功！");
            }
            else
            {
                MessageBox.Show("更新失败！");
            } 
            
        }


        private void button4_Click(object sender, EventArgs e)
        {
            init();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataRow dr = dt.NewRow();
            dr["Titem"] = NameBox.Text;
            dr["image"] = Libs.getControlImage(richTextBox1);
            dt.Rows.Add(dr);
            OleDbDataAdapter oda = DB.getAdapterByTableName("Itemtable");
            if (oda.Update(dt) > 0)
            {
                MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
            
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string titem = NameBox.Text;
            string sql = "select * from itemtable where titem like '%" + titem + "%'";
            dt = DB.getDataTable(sql);
            dataGridView1.DataSource = dt;
        }

    }
}
