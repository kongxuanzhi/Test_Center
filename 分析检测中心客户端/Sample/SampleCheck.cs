using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
using System.Threading;

namespace TRESystem2011.Sample
{
    public partial class SampleCheck : Form
    {
        public SampleCheck()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            init();
        }


        void init()
        {
            string sql = "select Sno,Sname as [样品名称],customername as [客户名],SoriginalNo as [原编号],Sspecification as [样品规格] ,Sgrade as [样品等级],Squantity as [样品数量],Sstate as [样品状态],Sintime as [进样时间],Scontracttime as [合约时间],Costtotal as [检验费],Costexpress as [加急费],CostSpreparation as [制样费] from sampletable,customer where sampletable.cno=customer.Customerno and Sprooftime = '/' order by sno";
            DataTable dt = DB.getDataTable(sql);
            dataGridView1.DataSource = dt;
            showColor();
        }
        


        private void button2_Click_1(object sender, EventArgs e)    //批量校对
        {
            if (MessageBox.Show("是否确定校对所选样品？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            string str = "";
            foreach (string sno in Libs.getSelectIds(dataGridView1))
            {
                SampleControl.sproof(sno);
                str += sno + " ";
                if(checkBox1.Checked == true)
                {
                    PrintMission(sno);
                }
            }
            str += "已校对完毕！";
            MessageBox.Show(str);
            button1_Click(null, null);
        }

        public void PrintMission(string sno)
        {
            MissionReport mission = new MissionReport(sno);
            mission.ShowDialog();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            foreach (string sno in Libs.getSelectIds(dataGridView1))
            {
                SampleModify sm = new SampleModify();
                sm.initModifiedSno(sno);
                sm.MdiParent = this.MdiParent;
                sm.Show();
            }
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            showColor();
        }

        void showColor()
        {
            DateTime today = Libs.getServerDate().Date;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (today > (Convert.ToDateTime(dataGridView1.Rows[i].Cells["合约时间"].Value).Date))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                }
                else if (today == (Convert.ToDateTime(dataGridView1.Rows[i].Cells["合约时间"].Value).Date))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
            }
        }

        private void SampleCheck_Shown(object sender, EventArgs e)
        {
            init();
        }
        /// <summary>
        /// 新增 打印任务单 孔龙飞 2016-3-19
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (string sno in Libs.getSelectIds(dataGridView1))
            {
                PrintMission(sno);
            }
            //多线程不行
            // Thread t = new Thread(new ThreadStart(delegate { PrintMission("sno"); }));
            //t.Start();                          // Run WriteY on the new thread
        }
    }
}
