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
    public partial class SampleProcess : Form
    {
        public SampleProcess()
        {
            InitializeComponent();
            searchBar1.Init();
            //searchGridView1.dataGridView1.MultiSelect = false;  //设置成只能单选
        }

        public void setTestMode()   //设置成检测部模式
        {
            searchGridView1.setTestMode(true);
            button2.Visible = false;    //样品详情
            button4.Visible = false;    //财务报表
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (searchBar1.search())
            {
                searchGridView1.setDataTable(searchBar1.getDataTable());
            }

        }

        /// <summary>
        /// 查看详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> snos = searchGridView1.getSelectIds();
            if (snos.Count>0)
            {
                SampleView sv = new SampleView();
                sv.initSno(snos[0]);
                sv.MdiParent = this.MdiParent;
                sv.Show();
            }

        }

        private void searchBar1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<string> snos = searchGridView1.getSelectIds();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "结果导出.xls";
            saveFileDialog1.Filter = "XLS|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;

            ExcelLib.ExportResults(snos,filename);

            MessageBox.Show("数据结果已成功导出！");

        }

        /// <summary>
        /// 导出财务报表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            List<string> snos = searchGridView1.getSelectIds();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "财务报表.xls";
            saveFileDialog1.Filter = "XLS|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;

            ExcelLib.ExportCaiWu(snos, filename);

            MessageBox.Show("财务报表已成功导出！");

        }

        public void PrintMission(string sno)
        {
            MissionReport mission = new MissionReport(sno);
            mission.ShowDialog();
        }
        private void printmission_Click(object sender, EventArgs e)
        {
            foreach (string sno in searchGridView1.getSelectIds())
            {
                PrintMission(sno);
            }
        }
    }
}
