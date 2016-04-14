//liyang 20120818
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
    public partial class Testing : Form
    {

        string m_sno;
        DataTable m_dt;
        bool m_isTest;
        bool isUpdate = false;

        public Testing()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 初始化控件模式，填报还是审核
        /// </summary>
        /// <param name="sno"></param>
        /// <param name="isAdd"></param>
        public void init(string sno, bool isTest)
        {
            m_sno = sno;
            m_isTest = isTest;

            if(isTest)
            {
                button1.Text = "提交结果";
                this.Text = "检测结果填报";

            }
            else
            {
                button1.Text = "审核";
                this.Text = "检测结果审核";
                jyyjTB.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                comboBox1.Enabled = false;
                button2.Enabled = false;
                dataGridView1.ReadOnly = true;
            }

            string sql = string.Format("select * from resulttable where sno='{0}' order by Tindex", sno);
            m_dt = DB.getDataTable(sql);
            dataGridView1.DataSource = m_dt;//获取原始数据加载到dadataGridView中

            sql = string.Format("select Sno,Sname,Taccording,Resultlabel,Resultquality,Resultsynthetical,Sremark,Smastertest from sampletable where Sno='{0}'", sno);
            DataRow dr = DB.getDataRow(sql);    //获取其他信息
            textBox1.Text = dr[0].ToString().Trim();
            textBox2.Text = dr[1].ToString().Trim();
            jyyjTB.Text = dr[2].ToString().Trim();
            textBox3.Text = dr[3].ToString().Trim();
            textBox4.Text = dr[4].ToString().Trim();
            textBox5.Text = dr[5].ToString().Trim();
            textBox6.Text = dr[6].ToString().Trim();
            comboBox1.Text = dr[7].ToString().Trim();
        }



        /// <summary>
        /// 提交结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string Sno = textBox1.Text.Trim();
            string Sname = textBox2.Text.Trim();
            if (m_isTest)
            {
                DialogResult dialogresult = MessageBox.Show("提交结果？", "提示！", MessageBoxButtons.YesNo);
                if (dialogresult == DialogResult.No)
                    return;
                string Sfiller = User.name;
                string Taccording = jyyjTB.Text.Trim();
                string Resultlabel = textBox3.Text.Trim();
                string Resultquality = textBox4.Text.Trim();
                string Resultsynthetical = textBox5.Text.Trim();
                string Sremark = textBox6.Text.Trim();
                string Smastertest = comboBox1.Text.Trim();

                if (Sno == "" || Sname == "" || Taccording == "" || Resultlabel == "" || Resultquality == "" || Resultsynthetical == "" || Sremark == "" || Smastertest == "" || Smastertest == "/")
                {
                    MessageBox.Show("输入有误！");
                    return;
                }

               
                string sqlstr = "";
               

                if (isUpdate)   //如果有更新，才提交修改
                {

                    //m_dt.AcceptChanges();
                    foreach (DataRow dr in m_dt.Rows)
                    {
                        for (int i = 0; i < dr.ItemArray.Length;i++ )
                        {
                            if (dr[i].ToString().Trim() == "")
                            {
                                MessageBox.Show("有尚未填写的空白数据，请检查！");
                                return;
                            }
                        }
                        //sqlstr += string.Format("update resulttable set Tvalue='{0}',Tstandard='{1}',Tunit='{2}',Tdeterminant='{3}' where sno='{4}' and Titem='{5}';", dr["Tvalue"], dr["Tstandard"], dr["Tunit"], dr["Tdeterminant"], m_sno, dr["Titem"]);
                    }
                    //SampleControl.updateSampleItems(m_sno, m_dt);
                   DB.UpdateDataTable(m_dt, "Resulttable");
                }
               
                sqlstr = "update sampletable set Sfiller='" + Sfiller +
                    "',Taccording='" + Taccording +
                    "',Resultlabel='" + Resultlabel +
                    "',Resultquality='" + Resultquality +
                    "',Resultsynthetical='" + Resultsynthetical +
                    "',Sremark='" + Sremark +
                    "',Smastertest='" + Smastertest +"' where sno='" + Sno + "'";
                DB.ExecuteNonQuery(sqlstr);
                SampleControl.Sout(Sno);  //填写完检时间


                sqlstr = string.Format("update users set Uindex=(select max(uindex) from users)+1 where username='{0}'", Smastertest);
                try
                {
                    DB.ExecuteNonQuery(sqlstr);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("此主检人员在数据库中无签名，请联系管理员添加！"+ex.Message);
                }
                MessageBox.Show("提交成功！");
                this.Close();
            }
            else 
            {
                DialogResult dialogresult = MessageBox.Show("结果无误？", "提示！", MessageBoxButtons.YesNo);
                if (dialogresult == DialogResult.Yes)
                {
                    if (SampleControl.verify(Sno))
                    {
                        MessageBox.Show("提交审核成功！");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("提交审核失败！");
                    };
                }
                else if (dialogresult == DialogResult.No)
                {
                    return;
                }
            }
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
                    if (dataGridView1.SelectedCells[i].ColumnIndex != 0)
                        dataGridView1.SelectedCells[i].Value = Clipboard.GetText();
                }

            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)    
        {
            isUpdate = true;
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightBlue;
            }
        }

        /// <summary>
        /// 查看已存在
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.DataSource = DB.getList("select username from users where underwrite is not null and alive=1 order by Uindex desc");
        }

        private void button3_Click(object sender, EventArgs e)//自动检验依据
        {
            List<string> items = new List<string>();
            foreach(DataRow dr in m_dt.Rows)
            {
                items.Add(dr["Titem"].ToString());
            }

            if (items.Find(delegate(string a) { return a.Contains("TREO"); }) != null)
            {
                jyyjTB.Text="GB/T 14635-2008 稀土金属及其化合物化学分析方法 稀土总量的测定等。";
                return;
            }
            
            for(int i=items.Count-1;i>=0;i--)
            {
                string info = getItemInfo(items[i]);
                if (info != "")
                {
                    jyyjTB.Text = info;
                    return;
                }
            }

        }

        string getItemInfo(string item)
        {
            string sql = string.Format("select * from parameter,method where parameter.methodnumber=method.methodnumber and parameter.parameter='{0}'", item);
            DataTable dt = DB.getDataTable(sql);
            string info = "";
            foreach(DataRow dr in dt.Rows)
            {
                info += string.Format("{0} {1};\r\n", dr["methodnumber"].ToString().Trim(), dr["methodname"].ToString().Trim());
            }
            return info;

        }

    }
}