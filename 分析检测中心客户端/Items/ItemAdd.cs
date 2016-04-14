using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
using System.Data.OleDb;


namespace TRESystem2011.Items
{
    public partial class ItemAdd : Form
    {  

        Dictionary<string, RichTextBox> rtbdic = new Dictionary<string, RichTextBox>();
        int m_x = 10;
        int m_y = 10;


        public ItemAdd()
        {
            InitializeComponent();
        }

        private void ItemAdd_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化检测项目条
        /// </summary>
        /// <param name="itemlist"></param>
        public void init(List<string> itemlist)
        {
            foreach (string item in itemlist)
            {
                if(addRichTextBox(m_x+70, m_y, item))
                {
                    addLabel(m_x, m_y, item);
                    m_y += 30;
                }
            }
        }

        /// <summary>
        /// 添加新框
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="itemtxt"></param>
        private bool addRichTextBox(int x,int y,string itemtxt)
        {
            //如果有重复的键，则只添加一次
            if (!rtbdic.ContainsKey(itemtxt))
            {
                RichTextBox rtb = new RichTextBox();
                rtb.SetBounds(x, y, 165, 20);
                rtb.Text = itemtxt;
                rtb.Font = new Font("宋体", 12);
                rtb.BackColor = Color.White;
                rtb.BorderStyle = BorderStyle.None;
                rtbdic.Add(itemtxt, rtb);
                this.Controls.Add(rtb);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 不做检查，强制增加
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="itemtxt"></param>
        /// <returns></returns>
//         private void addRichTextBoxEx(int x, int y)
//         {
//             //如果有重复的键，则只添加一次
// 
//                 RichTextBox rtb = new RichTextBox();
//                 rtb.SetBounds(x, y, 165, 20);
//                 rtb.Font = new Font("宋体", 12);
//                 rtb.BorderStyle = BorderStyle.None;
//                 rtbdic.Add(AutoIndex.ToString(), rtb);
//                 AutoIndex++;
//                 this.Controls.Add(rtb);
// 
//                 m_y += 30;
//         }

        private void removeRichTextBox()
        {
            this.Controls.RemoveAt(this.Controls.Count-1);
            m_y -= 30;
        }


        private void addLabel(int x, int y, string itemtxt)
        {
            Label l = new Label();
            l.SetBounds(x, y, 50, 20);
            l.Text = itemtxt;
            l.Font = new Font("宋体", 10);
            this.Controls.Add(l);
        }

        /// <summary>
        /// 添加图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt = DB.getDataTable("select top 1 * from itemtable");

                foreach (string item in rtbdic.Keys)
                {
                    DataRow dr = dt.NewRow();
                    dr["image"] = Libs.getControlImage(rtbdic[item]);
                    dr["Titem"] = item;
                    dt.Rows.Add(dr);
                }                                        
                OleDbDataAdapter oda = DB.getAdapterByTableName("Itemtable");
                if (oda.Update(dt) > 0)
                {
                    MessageBox.Show("对应项目图片添加成功！");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("无图片被添加~请检查！");
                };
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("添加过程出现错误！"+ex.Message, "警告！");
            }

//             DB.Open();
//             OleDbConnection conn = DB.getConn();
//             OleDbCommand cmd = new OleDbCommand();
//             cmd.Connection = conn;
//             int n = 0;
//             foreach (string item in rtbdic.Keys)
//             {
//                 cmd.CommandText = string.Format("insert into Itemtable(image,titem) values(?,'{0}')", item);
//                 byte[] buf = Libs.getControlImage(rtbdic[item]);
//                 cmd.Parameters.Add("?", OleDbType.VarBinary).Value = buf;
//                 n+=cmd.ExecuteNonQuery();
//             }
//             MessageBox.Show(n.ToString());
        }
        

    }
}
