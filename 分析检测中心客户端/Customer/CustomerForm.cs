using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
using System.Data.OleDb;

namespace TRESystem2011.Customer
{
    public partial class CustomerForm : Form
    {
        private DataTable dt = new DataTable();
        private OleDbDataAdapter oda = new OleDbDataAdapter();
        private Boolean isUpdate = false;

        public Control c1;//传值用
        public Control c2;


        public void setSelectMode(bool flag)    //如果是选择模式，则开启按钮
        {
            if (flag)
            {
                button1.Visible = true;
            }
        }

        /// <summary>
        /// 获取授权码
        /// </summary>
        /// <param name="cno"></param>
        string getCnoKey(string cno)
        {
            //这里采用的加密为kehu+客户编号，用sha加密后取前6位，可防止破解

            return Libs.sha("kehu"+cno).Substring(0, 6);  //获取sha加密后的前6位
        }


        public CustomerForm()
        {
            InitializeComponent();
        }


        private void CustomerForm_Load(object sender, EventArgs e)
        {
            cb_kinds.DataSource = DB.getDataTable("select * from SampleKinds order by i");
            dataGridView1.AutoGenerateColumns = false;
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            dt.Clear();
            string sql = string.Format("select * from Customer where Customername like '%{0}%'", searchTB.Text);
            oda.SelectCommand = new OleDbCommand(sql, DB.getConn());
            oda.Fill(dt);
            dataGridView1.DataSource = dt;

        }


        /// <summary>
        /// 应用更改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                try
                {
                    OleDbCommandBuilder ocb = new OleDbCommandBuilder(oda);
                    oda.Update(dt);

                    isUpdate = false;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                MessageBox.Show("更新成功! ");
            }
            else
            {
                MessageBox.Show("没有更新内容! ");
            }

//             for (int i = 0; i < dt.Rows.Count; i++)
//                 for (int j = 0; j < dt.Columns.Count; j++)
//                 {
//                     try
//                     {
//                         dataGridView1[j, i].Style.BackColor = Color.White;
//                     }
//                     catch (System.Exception ex)
//                     {
//                     	
//                     }
// 
//                 }
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
        /// 新增客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否新增客户？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            if (tb_customername.Text == "" || tb_address.Text == "" || tb_relation.Text == "" || tb_email.Text == "" || tb_postcode.Text == "" || tb_tel.Text == "" || tb_fax.Text == "" || tb_net.Text == "" || cb_kinds.Text.Trim() == "")
            {
                MessageBox.Show("信息不全！");
                return;
            }
            string customerno = "";
            string ckinds=cb_kinds.SelectedValue.ToString().Trim();
            string sqlstr = "select max(customerNo) from customer where kinds='" + ckinds + "'";
            string maxNo = DB.ExecuteScalar(sqlstr);
            if (maxNo=="")
            {
                customerno=cb_kinds.SelectedValue.ToString().Trim() + "00001";
            }
            else
            {
                customerno = string.Format("{0}{1:00000}", ckinds, Convert.ToInt16(maxNo.Substring(maxNo.Length - 5, 5)) + 1);
            }
            DateTime cintime = Libs.getServerDate();
            sqlstr = "insert into customer(customerNo,customername,address,relation,email,postcode,tel,fax,net,kinds,introducer,cintime,province,city) values('"
                + customerno + "','" + tb_customername.Text + "','" + tb_address.Text + "','" + tb_relation.Text + "','" + tb_email.Text + "','" + tb_postcode.Text + "','" + tb_tel.Text + "','" + tb_fax.Text + "','" + tb_net.Text + "','" + cb_kinds.SelectedValue.ToString().Trim() + "','" + tb_introducer.Text + "','" + cintime + "','" + tb_province.Text + "','"+tb_city.Text+ "')";
            if(DB.ExecuteNonQuery(sqlstr)>0)
            {
                MessageBox.Show("新增客户成功！编号："+customerno);
                CnoTB.Text = customerno;
                CnameTB.Text = tb_customername.Text;
                KeyTB.Text = getCnoKey(customerno);
            }
            else
            {
                MessageBox.Show("新增客户失败！");
            }
            
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            int i=dataGridView1.CurrentCellAddress.Y;
            if (i >= 0)
            {
                try
                {
                    CnoTB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                    CnameTB.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    KeyTB.Text = getCnoKey(CnoTB.Text);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }
        }

        /// <summary>
        /// 确定选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                c1.Text = CnoTB.Text;
                c2.Text = CnameTB.Text;
            }
            catch (System.Exception)
            {

            }
            this.Dispose();
        }

                /// <summary>
        /// 如果是回车，则模拟搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void searchTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData==Keys.Enter)
            {
                button2_Click(null, null);
            }
        
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "客户列表.xls";
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
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XLS|*.xls";
            if (ofd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = ofd.FileName;

            ExcelLib.XLStoDVG(dataGridView1, filename);
            MessageBox.Show("导入成功！");
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


     


    }
}
