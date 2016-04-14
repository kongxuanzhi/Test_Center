using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
using System.IO;
using System.Data.OleDb;

namespace TRESystem2011.Manage
{
    public partial class UploadMark : Form
    {

        DataTable dt;

        public UploadMark()
        {
            InitializeComponent();
        }

        private void UploadMark_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“dataSet1.Users”中。您可以根据需要移动或移除它。

            init();
        }


        private void init()
        {
            dt = DB.getDataTable("select * from [Users]");
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.ImageLocation == "")
            {
                MessageBox.Show("请选择上传图片文件！");
                return;
            }

            string username = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)    //如果勾选则添加进列表中
                {
                    username=dataGridView1.Rows[i].Cells["username"].Value.ToString();
                    break;
                }

            }

            if(username=="")
            {
                MessageBox.Show("请选择上传对象用户名！");
                return;
            }
            FileStream fs = new FileStream(pictureBox1.ImageLocation, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            byte[] buf = br.ReadBytes((int)fs.Length);//全部读入bytes中

            OleDbConnection conn = DB.getConn();
            OleDbCommand cmd = new OleDbCommand("update [Users] set underwrite=? where username='" + username + "'",conn);
            cmd.Parameters.Add("?uw", OleDbType.Binary).Value = buf;
            int n=cmd.ExecuteNonQuery();
            if (n>0)
            {
                MessageBox.Show("修改图片成功！");
                init();
            }
            else
            {
                MessageBox.Show("修改图片失败！");
            }
            
        }


        private void button4_Click(object sender, EventArgs e)
        {
            init();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(pictureBox1.ImageLocation, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            byte[] buf = br.ReadBytes((int)fs.Length);//全部读入bytes中

            OleDbConnection conn = DB.getConn();
            OleDbCommand cmd = new OleDbCommand("insert into [Users](username,underwrite,alive,uindex) values('"+NameBox.Text+"',?,1,0)",conn);
            cmd.Parameters.Add("?", OleDbType.VarBinary).Value = buf;
            int n = cmd.ExecuteNonQuery();
            if (n > 0)
            {
                MessageBox.Show("添加成功！");
                init();
            }
            else
            {

                MessageBox.Show("添加失败！");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)  //更新
        {
            OleDbDataAdapter oda = DB.getAdapterByTableName("Users");
            MessageBox.Show(oda.Update(dt).ToString());
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            byte[] bytImg=null;
            string username = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)    //如果勾选则添加进列表中
                {
                    username = dataGridView1.Rows[i].Cells["username"].Value.ToString();
                    bytImg = (byte[])dt.Rows[i]["Underwrite"];
                    break;
                }
            }
            if (username == "")
            {
                MessageBox.Show("尚未选择!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = username + ".bmp";
            if (sfd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string path = sfd.FileName;

            if (bytImg != null)
            {
                MemoryStream ms = new MemoryStream(bytImg);
                Image img = Image.FromStream(ms);
                img.Save(path);
                MessageBox.Show("导出成功！" + path);
            }
        }
    }
}
