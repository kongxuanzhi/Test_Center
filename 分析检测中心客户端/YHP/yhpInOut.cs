using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;

namespace TRESystem2011.YHP
{
    public partial class yhpInOut : Form
    {

        DataTable dt = new DataTable();

        string targetIid = "";
        string targetIname = "";
        int targetNum = 0;
        string lastsql = "";    //记录上一次查询语句
        public yhpInOut()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 清空panel1
        /// </summary>
        void clearPanel1()
        {
            countTB.Text = "";
            remarkTB.Text = "";
        }

        /// <summary>
        /// 清空panel2
        /// </summary>
        void clearPanel2()
        {
            gjTB.Text = "";
            remarkTB2.Text = "";
        }


        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = string.Format("select IId,IName,Spec,Price,TotalCount,Cname from yhp_items,yhp_customer where yhp_items.Cid=yhp_customer.Cid and IName like '%{0}%'", nameTB.Text);
            dt = DB.getDataTable(sql);
            dataGridView1.DataSource = dt;
            lastsql = sql;
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InBtn_Click(object sender, EventArgs e)
        {
            try
            {
                targetIid = dataGridView1.SelectedRows[0].Cells["IId"].Value.ToString();
                targetIname = dataGridView1.SelectedRows[0].Cells["IName"].Value.ToString();
                targetNum = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells["TotalCount"].Value);
                nameLB.Text = targetIname;
                modeLB.Text = "物品入库";
                personLB.Text = "入库人";
                personTB.Text = User.name;
                CountNowLB.Text = string.Format("【{0}】", targetNum);
                panel1.Visible = true;
                countTB.Focus();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("出错！请检查是否选中物品！"+ex.Message);
            }

        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutBtn_Click(object sender, EventArgs e)
        {
            try
            {
                targetIid = dataGridView1.SelectedRows[0].Cells["IId"].Value.ToString();
                targetIname = dataGridView1.SelectedRows[0].Cells["IName"].Value.ToString();
                targetNum = Convert.ToInt16(dataGridView1.SelectedRows[0].Cells["TotalCount"].Value);
                nameLB.Text = targetIname;
                modeLB.Text = "物品出库";
                personLB.Text = "领用人";
                personTB.Text = User.name;
                CountNowLB.Text = string.Format("【{0}】", targetNum);
                panel1.Visible = true;
                countTB.Focus();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("出错！请检查是否选中物品！"+ex.Message);
            }
        }


        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string Iid = targetIid;
            int num;
            int result=0;
            try
            {
                if (countTB.Text == "" || personTB.Text == "")
                {
                    MessageBox.Show("请输入完整！");
                    return;
                }
                num = Convert.ToInt16(countTB.Text);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("数量有误！请输入正整数！"+ex.Message);
                return;
            }
            string remarks = remarkTB.Text;
            string p = personTB.Text;

            if (modeLB.Text == "物品入库")
            {
                result=yhpControl.addNum(Iid,num,remarks,p);
            }
            else if(modeLB.Text == "物品出库")
            {
                if (num > Convert.ToInt16(targetNum))
                {
                    MessageBox.Show("出库数量不能大于库存数量！");
                    return;
                }
                result=yhpControl.reduceNum(Iid,num,remarks,p);
            }

            if(result>0)
            {
                MessageBox.Show("提交成功！");
                panel1.Visible=false;
                clearPanel1();
                button4_Click(null,null);//刷新
            }
            else
            {
                MessageBox.Show("提交失败！");
            }

        }


        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            clearPanel1();
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            dt = DB.getDataTable(lastsql);
            dataGridView1.DataSource = dt;
        }

        /// <summary>
        /// 价格修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PriceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                targetIid = dataGridView1.SelectedRows[0].Cells["IId"].Value.ToString();
                targetIname = dataGridView1.SelectedRows[0].Cells["IName"].Value.ToString();
                yjLB.Text = dataGridView1.SelectedRows[0].Cells["Price"].Value.ToString();
                nameLB2.Text = targetIname;
                panel2.Visible = true;
                gjTB.Focus();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("出错！请检查是否选中物品！"+ex.Message);
            }
        }

        private void yhpInOut_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            clearPanel2();
        }

        /// <summary>
        /// 价格修改_确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            string Iid = targetIid;
            int result = 0;

            if(gjTB.Text=="")
            {
                MessageBox.Show("请输入完整！");
                return;
            }

            double price = Convert.ToDouble(gjTB.Text);
            string remarks=remarkTB2.Text;
            result = yhpControl.changePrice(targetIid, price, remarks);

    
            if (result > 0)
            {
                MessageBox.Show("提交成功！");
                panel2.Visible = false;
                clearPanel2();
                button4_Click(null,null);    //刷新
            }
            else
            {
                MessageBox.Show("提交失败！");
            }
        }

        /// <summary>
        /// 查看样品历史记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                targetIid = dataGridView1.SelectedRows[0].Cells["IId"].Value.ToString();
                DataTable dt=yhpControl.getLogdt(targetIid,true);
                dataGridView2.DataSource = dt;
                panel3.Visible = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("出错！请检查是否选中物品！"+ex.Message);
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }


    }
}
