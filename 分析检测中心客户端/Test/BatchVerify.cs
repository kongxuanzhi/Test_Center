using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using Code;



namespace TRESystem2011.Test
{

    public partial class BatchVerify : Form
    {


        List<string> snolist;   //传递进来的样品列表
        string snoArrayStr;
        DataTable sampledt; //样品table
        Dictionary<string, Dictionary<string, ItemInfo>> sampleDic = new Dictionary<string, Dictionary<string, ItemInfo>>();



        public void init(List<string> snolist)  //根据需要批量填报的样品编号进行初始化操作
        {
            //获取样品基本信息
            this.snolist = snolist;

            foreach (string sno in snolist) //先把所有样品存储内容初始化
            {
                sampleDic.Add(sno,new Dictionary<string,ItemInfo>());
            }


            snoArrayStr="('" + string.Join("','", snolist.ToArray()) + "')";
            string sql = "select sno,sname,Taccording,smastertest from sampletable where sno in "+snoArrayStr;
            sampledt = DB.getDataTable(sql);


            sql = "select id,Sno,Titem,Tvalue from resulttable where sno in " + snoArrayStr +"order by sno,Tindex";
            DataTable dt2 = DB.getDataTable(sql);   //读取所有数据并存入临时结构体中

            foreach (DataRow dr in dt2.Rows)    //循环将表中内容写入dic中
            {

                if (!sampledt.Columns.Contains(dr["Titem"].ToString())) //如果不包含则添加
                {
                    sampledt.Columns.Add(dr["Titem"].ToString());
                }

                ItemInfo ii = new ItemInfo();
                ii.id = dr["id"].ToString();
                ii.Tvalue = dr["Tvalue"].ToString();
                sampleDic[dr["Sno"].ToString()].Add(dr["Titem"].ToString(), ii);
            }

            for (int i = 0; i < sampledt.Rows.Count;i++ )   //全部写入
            {
                DataRow dr = sampledt.Rows[i];
            
                string sno = dr["Sno"].ToString();
                Dictionary<string, ItemInfo> dic = sampleDic[sno];  //获取映射
                foreach (string ItemName in dic.Keys)
                {
                    dr[ItemName] = dic[ItemName].Tvalue;
                }
            }


            dataGridView1.DataSource = sampledt;    //绑定
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            //设置只读
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].ReadOnly = true;
                dataGridView1.Rows[i].HeaderCell.Value = dataGridView1.Rows[i].Cells[0].Value;  //标头行
                for (int j = 4; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString() == "")
                    {
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                    }
                }
            }

            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)  //禁止排序
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }




        public BatchVerify()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string msg = string.Format("确定结果无误，并以【{0}】名义审核？", User.name);
            DialogResult dialogresult = MessageBox.Show(msg, "提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogresult == DialogResult.No)
                return;

            try
            {
                foreach (string sno in snolist)
                {
                    SampleControl.verify(sno);
                }
                MessageBox.Show("所有样品审核成功！");
                this.Dispose();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("提交审核出错！"+ex.Message);
                return;
            }





        }

        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "导出.xls";
            saveFileDialog1.Filter = "XLS|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;
            ExcelLib.DGVtoXLs(dataGridView1, filename);
            MessageBox.Show("EXCEL已成功导出！");
        }


 

    }
}