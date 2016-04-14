using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TRESystem2011.Sample
{
    public partial class SampleCount : Form
    {
        public SampleCount()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 报告统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            searchBar1.countReportInfo();

            //textBox1.AppendText(searchBar1.searchInfo + "\r\n");
            textBox1.AppendText(searchBar1.reportInfo + "\r\n");

        }

        private void SampleCount_Load(object sender, EventArgs e)
        {
            searchBar1.Init();
        }

        /// <summary>
        /// 全效率统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            textBox1.Clear();
            SortedDictionary<int, int> countDic = new SortedDictionary<int, int>();
            int errorCount = 0; //错误数
            if (!searchBar1.search())
            {
                return;
            }
            DataTable dt = searchBar1.getDataTable();
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    DateTime dt1 = DateTime.Parse(dr["Sintime"].ToString());
                    DateTime dt2 = DateTime.Parse(dr["Rsendtime"].ToString());
                    int day = (dt2 - dt1).Days;
                    if (day < 0)    //天数小于0，记入错误并跳过
                    {
                        errorCount++;
                        continue;
                    }
                    if (countDic.ContainsKey(day))
                    {
                        countDic[day]++;
                    }
                    else
                    {
                        countDic[day] = 1;
                    }
                }
                catch (System.Exception)
                {
                    errorCount++;
                }
            }

            textBox1.AppendText("【全效率统计】：从进样到出报告\r\n");
            textBox1.AppendText(string.Format("共有{0}个样品，其中{1}个无效样品\r\n", dt.Rows.Count, errorCount));

                  
            foreach (int i in countDic.Keys)
            {
                textBox1.AppendText(string.Format("{0}天：{1}个\r\n", i, countDic[i]));
            }
            
            
        }

        /// <summary>
        /// 检测效率统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            SortedDictionary<int, int> countDic = new SortedDictionary<int, int>();
            int errorCount = 0; //错误数
            if (!searchBar1.search())
            {
                return;
            }
            DataTable dt = searchBar1.getDataTable();
            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    DateTime dt1 = DateTime.Parse(dr["Ssignintime"].ToString());
                    DateTime dt2 = DateTime.Parse(dr["Sapprovetime"].ToString());
                    int day = (dt2 - dt1).Days;
                    if (day < 0)    //天数小于0，记入错误并跳过
                    {
                        errorCount++;
                        continue;
                    }
                    if (countDic.ContainsKey(day))
                    {
                        countDic[day]++;
                    }
                    else
                    {
                        countDic[day] = 1;
                    }
                }
                catch (System.Exception)
                {
                    errorCount++;
                }
            }
            textBox1.AppendText("【检测效率统计】：从签收到授权完毕\r\n");
            textBox1.AppendText(string.Format("共有{0}个样品，其中{1}个无效样品\r\n", dt.Rows.Count, errorCount));


            foreach (int i in countDic.Keys)
            {
                textBox1.AppendText(string.Format("{0}天：{1}个\r\n", i, countDic[i]));
            }
            
        }
    }
}
