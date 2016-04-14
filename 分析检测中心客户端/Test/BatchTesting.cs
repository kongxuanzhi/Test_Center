using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.OleDb;
using Code;



namespace TRESystem2011.Test
{

    struct ItemInfo //样品映射表
    {
        public string id;
        public string Tvalue;
    }


    public partial class BatchTesting : Form
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
                sampleDic.Add(sno, new Dictionary<string, ItemInfo>(StringComparer.OrdinalIgnoreCase)); //此处表示不区分大小写
            }


            snoArrayStr="('" + string.Join("','", snolist.ToArray()) + "')";
            string sql = "select sno,sname,Taccording,smastertest,Sremark from sampletable where sno in "+snoArrayStr;
            sampledt = DB.getDataTable(sql);


//             //以下是获取所有需要测定的元素
//             sql="select distinct Titem from resulttable where sno in "+snoArrayStr;
//             DataTable tempItemsDT = DB.getDataTable(sql);
//             foreach (DataRow dr in tempItemsDT.Rows)
//             {
//                 sampledt.Columns.Add(dr[0].ToString());
//             }


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
                dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                dataGridView1.Rows[i].Cells[0].Style.BackColor = Color.Gray;
                dataGridView1.Rows[i].Cells[1].ReadOnly = true;
                dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Gray;
                dataGridView1.Rows[i].HeaderCell.Value = dataGridView1.Rows[i].Cells[0].Value;  //标头行
                for (int j = 4; j < dataGridView1.ColumnCount; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString() == "")
                    {
                       
                        dataGridView1.Rows[i].Cells[j].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                    }
                }
            }

            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)  //禁止排序
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

        }




        public BatchTesting()
        {
            InitializeComponent();
        }

  

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(dataGridView1.SelectedCells[0].Value.ToString());
            }
            catch
            { }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                for (int i = 0; i < dataGridView1.SelectedCells.Count; i++)
                {
                    if (dataGridView1.SelectedCells[i].ColumnIndex != 0 && dataGridView1.SelectedCells[i].ColumnIndex != 1)
                        dataGridView1.SelectedCells[i].Value = Clipboard.GetText();
                }

            }
        }

        private void BatchTesting_Load(object sender, EventArgs e)
        {
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
//             if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
//                 return;
//             string filename = saveFileDialog1.FileName;
//             if (filename.Length < 1)
//                 return;
//             //调用类库：操作WORD及EXCEL文档
//             Code.ExcelAndWord myexcelclass = new Code.ExcelAndWord();
//             //dataGridView1的行数
//             int i = dataGridView1.Rows.Count+1;
//             //dataGridView1的列数
//             int j = dataGridView1.Columns.Count;
//             //dataGridView1的表头（列名）
//             object[] myheader = new object[j];
//             for (int k = 0; k < j; k++)
//             {
//                 myheader[k] = dataGridView1.Columns[k].HeaderText;
//             }
//             object[,] mydata = new object[i, j];
//             for (int k = 0; k < i-1; k++)
//             {
//                 for (int m = 0; m < j; m++)
//                 {
//                     //把dataGridView1的第k行第m列写入mydata数组
//                     mydata[k, m] = dataGridView1.Rows[k].Cells[m].Value;
//                 }
//             }
//             mydata[i-1,0]= DateTime.Now.ToShortDateString();
//             //取到Excel里面的最后一列的符号，如“AD1”
//             int x = j % 26;
//             int y = j / 26;
//             string shouzifu = "";
//             if (y != 0)
//                 shouzifu = ((char)(y + 64)).ToString();
//             string mozifu = ((char)(x + 64)).ToString();
//             string liefu = shouzifu + mozifu + "1";
// 
//             //调用类库（操作WORD及EXCEL文档） 里面的函数
//             string xinxi = myexcelclass.get_excel(i, j, liefu, myheader, mydata, filename);
//             MessageBox.Show(xinxi, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        /// <summary>
        /// 染色功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightBlue;
                //Application.DoEvents();
            }
        }


        /// <summary>
        /// 导出EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName="导出.xls";
            saveFileDialog1.Filter = "XLS|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = saveFileDialog1.FileName;
            ExcelLib.DGVtoXLs(dataGridView1, filename);
            MessageBox.Show("EXCEL已成功导出！");
        }

        /// <summary>
        /// 结果提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = MessageBox.Show("是否提交结果？", "提示！", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogresult == DialogResult.No)
                return;

            string sql = "";

            try
            {
                //所有样品基础信息全部提交
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    DataGridViewRow dgvr = dataGridView1.Rows[i];
                    string sno = dgvr.Cells["Sno"].Value.ToString();
                    string taccording = dgvr.Cells["Taccording"].Value.ToString();
                    string smastertest = dgvr.Cells["smastertest"].Value.ToString();
                    string Sremark = dgvr.Cells["Sremark"].Value.ToString();
                    sql += string.Format("update sampletable set Taccording='{0}',smastertest='{1}',Sremark='{2}' where sno='{3}';", taccording, smastertest,Sremark,sno);
                }

                if (DB.ExecuteNonQuery(sql) != dataGridView1.RowCount)
                {
                    MessageBox.Show("提交基础信息数量有误！请检查数据！");
                    return;
                }
                MessageBox.Show("基础信息改动提交成功！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("提交基础信息出错！"+ex.Message);
                return;
            }



            sql = "";
            try
            {
                //提交数据

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 5; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Style.BackColor == Color.LightBlue )//如果变了颜色说明修改过
                        {
                            //新版本导入EXCEL的时候已经对只读做出判断了，所以无需在写入数据库的时候判断空数据
//                             if (dataGridView1.Rows[i].Cells[j].Value.ToString() == "")
//                             {
//                                 //如果是空数据，则不进行修改
//                                 continue;
//                             }

                            string sno = dataGridView1.Rows[i].Cells["Sno"].Value.ToString();
                            string itemname = dataGridView1.Columns[j].HeaderText;
                            string id = sampleDic[sno][itemname].id;
                            sql += string.Format("update resulttable set Tvalue='{0}' where id='{1}';", dataGridView1.Rows[i].Cells[j].Value.ToString(), id);
                        }
                    }
                }

                if (sql == "")
                {
                    MessageBox.Show("无检测数据改动！");
                    return;
                }
                DB.ExecuteNonQuery(sql);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("检测结果提交失败！【"+ex.Message+"】");
                return;
            }


            //添加写入时间
            string sqlstr = "update sampletable set Souttime='" + Libs.getServerDateStr() + "' where sno in " + snoArrayStr;
            DB.ExecuteNonQuery(sqlstr);


            MessageBox.Show("检测结果提交成功！");
        }

        /// <summary>
        /// 导入EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "导入.xls";
            ofd.Filter = "XLS|*.xls";
            if (ofd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = ofd.FileName;

            ExcelLib.XLStoDVG(dataGridView1, filename);
            MessageBox.Show("导入成功！如需确认输入请点击确定按钮");
        }

    }
}