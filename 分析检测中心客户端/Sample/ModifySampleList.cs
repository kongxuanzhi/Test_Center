using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
using System.Data.OleDb;

namespace TRESystem2011.Sample
{
    public partial class ModifySampleList : Form
    {
        public ModifySampleList()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                SampleModify sm = new SampleModify();
                sm.initModifiedSno(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim());
                sm.MdiParent = this.MdiParent;
                sm.Show();
            }

        }


        private void ModifySample_Load(object sender, EventArgs e)
        {
            getUnApproveSamples();
            dateTimePicker1.Value = Libs.getServerDate();
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        /// <summary>
        /// 尚未校对和签收的样品
        /// </summary>
        void getUnApproveSamples()
        {
            dataGridView1.Rows.Clear();
            string sqlstr = "select sno,sname,CanBaseInformation,CanSintime,CanScontracttime,CanCost,CanItems from sampletable where Ssignintime='/'";

            OleDbDataReader myreader = DB.ExecuteReader(sqlstr);
            if (!myreader.HasRows)
            {
                myreader.Close();
                //MessageBox.Show("无可修改的样品！");
                return;
            }

            while (myreader.Read())
            {
                dataGridView1.Rows.Add(myreader.GetString(0).Trim(), myreader.GetString(1).Trim(), Convert.ToBoolean(myreader.GetString(2).Trim()), Convert.ToBoolean(myreader.GetString(3).Trim()), Convert.ToBoolean(myreader.GetString(4).Trim()), Convert.ToBoolean(myreader.GetString(5).Trim()), Convert.ToBoolean(myreader.GetString(6).Trim()), false , "修改");
            }
            myreader.Close();

        }

        /// <summary>
        /// 尚未校对样品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            getUnApproveSamples();
        }

        /// <summary>
        /// 已授权修改的样品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sqlstr = string.Format("select sno,sname,CanBaseInformation,CanSintime,CanScontracttime,CanCost,CanItems from sampletable where CanBaseInformation='true' or CanSintime='true' or CanScontracttime='true' or CanItems='true' or CanCost='true'");
            //MessageBox.Show(sqlstr);
            OleDbDataReader myreader = DB.ExecuteReader(sqlstr);
            if (!myreader.HasRows)
            {
                myreader.Close();
                //MessageBox.Show("无可修改的样品！");
                return;
            }

            while (myreader.Read())
            {
                dataGridView1.Rows.Add(myreader.GetString(0).Trim(), myreader.GetString(1).Trim(), Convert.ToBoolean(myreader.GetString(2).Trim()), Convert.ToBoolean(myreader.GetString(3).Trim()), Convert.ToBoolean(myreader.GetString(4).Trim()), Convert.ToBoolean(myreader.GetString(5).Trim()), Convert.ToBoolean(myreader.GetString(6).Trim()), false, "修改");
            }
            myreader.Close();

        }

        /// <summary>
        /// 选中样品放弃修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("选中的样品会重置并放弃修改，除了未签收样品外，其余样品将无法修改。\r\n（注：本功能主要针对取消检测项目的修改，可以无须重走流程！）", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            List<string> snos=Libs.getSelectIds(dataGridView1);
            foreach (string sno in snos)
            {
                SampleControl.SetCan(sno, "false");
                Log.AddLog(sno, "撤销修改", "");
            }
            MessageBox.Show("撤销完毕！");
        }

        /// <summary>
        /// 合约时间批量修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            List<string> snos = Libs.getSelectIds(dataGridView1);
            string dt = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string info = string.Format("选中的样品【合约时间】将会被统一修改为{0}（已授权情况，无授权自动忽略）！", dt);
            if (MessageBox.Show(info, "警告", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            int n = 0;  //统计数量
            string snostr = "";
            foreach (string sno in snos)
            {
                if (SampleControl.SetScontracttime(sno, dt, true) == 1)
                {
                    n++;
                    snostr += sno + "|";   
                }
                
            }
            string msg = string.Format("修改结束！共修改样品数：{0}个。列表：【{1}】", n,snostr);
            Log.AddLogEx(snostr, "批量修改合约时间", dt);
            MessageBox.Show(msg);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// 进样时间修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            List<string> snos = Libs.getSelectIds(dataGridView1);
            string dt = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string info = string.Format("选中的样品【进样时间】将会被统一修改为{0}（已授权情况，无授权自动忽略）！", dt);
            if (MessageBox.Show(info, "警告", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }
            int n = 0;  //统计数量
            string snostr = "";
            foreach (string sno in snos)
            {
                if (SampleControl.SetSintime(sno, dt, true) == 1)
                {
                    n++;
                    snostr += sno + "|";
                }
            }
            string msg = string.Format("修改结束！共修改样品数：{0}个。列表：【{1}】", n, snostr);
            Log.AddLogEx(snostr, "批量修改进样时间", dt);
            MessageBox.Show(msg);
        }

        /// <summary>
        /// 说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string msg = "1、选中样品列表\r\n2、选择好日期时间（合约时间自动只取日期）\r\n3、点击执行（执行成功后选中样品的时间修改功能自动取消）";
            MessageBox.Show(msg);
        }
    }
}