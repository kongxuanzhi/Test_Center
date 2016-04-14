using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
using System.Data.OleDb;

namespace TRESystem2011.Manage
{
    public partial class SQLManage : Form
    {

        DataTable m_dt;
        OleDbDataAdapter m_adapter;
        


        public SQLManage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select " + textBox1.Text;
            m_dt = DB.getDataTable(sql);
            m_adapter = DB.m_dataAdapter;   //保留适配器
            dataGridView1.DataSource = m_dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int n=m_adapter.Update(m_dt);
                MessageBox.Show(n.ToString());
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
