using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;

namespace TRESystem2011.Person
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
            nameTB.Text = User.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (newpwdTB1.Text != newpwdTB2.Text)
            {
                MessageBox.Show("两次输入新密码不一样！");
                return;
            }

            string sql = string.Format("select count(*) from Logintable where username='{0}' and password='{1}'", User.userName, Libs.sha(oldpwdTB.Text));
            if (DB.ExecuteScalar(sql) == "0")
            {
                MessageBox.Show("原密码错误！");
                return;
            }

            sql = string.Format("update Logintable set password='{0}' where username='{1}'", Libs.sha(newpwdTB1.Text), User.userName);
            if (DB.ExecuteNonQuery(sql) > 0)
            {
                MessageBox.Show("密码修改成功！");
                this.Dispose();
            }
            else
            {
                MessageBox.Show("密码修改失败！");
            }
        }
    }
}
