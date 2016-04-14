using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;

namespace TRESystem2011.Manage
{
    public partial class PersonManage : Form
    {

        DataTable m_dt;

        public PersonManage()
        {
            InitializeComponent();

            
            bind();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            string[] arr=Libs.getTextBoxLines(textBox1);

            foreach(string str in arr)
            {
                string[] tmpstr=str.Split('\t',' '); //拆分换行符和空格
                string name = tmpstr[0].Trim();   //姓名   
                string section = tmpstr[1].Trim();    //部门
                string loginname = PinyinHelper.GetPinyin(name);    //获取拼音
                string pwd = Libs.sha("123456");   //初始密码123456
                string sql = string.Format("insert into LoginTable(UserName,PassWord,Name,SectionName) values('{0}','{1}','{2}','{3}')", loginname, pwd, name, section);
                n += DB.ExecuteNonQuery(sql);

            }
            MessageBox.Show("添加了" + n + "个人");
            textBox1.Text = "";
        }

        void bind()
        {
            m_dt = DB.getDataTable("select * from LoginTable");
            dataGridView1.DataSource = m_dt;
        }

        void update()
        {
            MessageBox.Show(DB.UpdateDataTable(m_dt, "LoginTable").ToString());
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            bind();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            update();
        }
    }
}
