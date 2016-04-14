using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using Code;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Configuration;
using LuaInterface;

namespace TRESystem2011
{
    public partial class Login : Form
    {

        TREConfig config;
        LuaTable ConnTb = null;

        public Login()
        {
            InitializeComponent();

            try
            {
                Lualib.initLua();   //加载LUA
                ConnTb = Lualib.lua.GetTable("ConnTable"); //获取登录table
                for (int i = 0; i < ConnTb.Keys.Count;i++ ) //遍历
                {
                    LuaTable lt = (LuaTable)ConnTb[i];
                    fwqCB.Items.Add(lt["Name"]);
                }  //服务器列表
                if (Lualib.lua["AppMode"].ToString() == "TS")
                {
                    User.TSMODE = true;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message+"LUA脚本数据加载失败！请联系管理员！");
                Application.Exit();
            }

            try
            {
                if (User.TSMODE)
                {
                    this.Text = "特殊样品管理系统";
                    this.BackgroundImage = null;
                    label3.Visible = true;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                config = TREConfig.Load();
                comboBox1.DataSource = config.UserNameList;
                fwqCB.SelectedIndex = config.FWQindex;  //上次选择的服务器
            }
            catch (System.Exception)    //如果出错则创建新的
            {
            	config = new TREConfig();
            }


        }
        public bool login = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text ))
            {
                MessageBox.Show("请输入用户名");
                comboBox1.Focus();
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("请输入密码");
                textBox2.Focus();
                return;
            }

            int si = fwqCB.SelectedIndex;   
            LuaTable selTb=(LuaTable)ConnTb[si];    //选择的服务器
            string connstr = selTb["ConnStr"].ToString();   //获取链接字符串
            User.IsOfficial = Convert.ToBoolean(selTb["IsOfficial"]);   //设置是否正式服务器

            try{
                DB.init(connstr,User.IsOfficial);
                DB.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message+"服务器连接失败！请选择其他服务器登录~如果还有问题请检查网络或联系管理员！");
                return;
            }

           // 发布前要加密
             string sql = string.Format("select * from Logintable where username='{0}' and password='{1}'", comboBox1.Text.Trim(), Libs.sha(textBox2.Text.Trim()));

          //  string sql = string.Format("select * from Logintable where username='{0}' and password='{1}'", comboBox1.Text.Trim(), textBox2.Text.Trim());
            DataTable dt = DB.getDataTable(sql);

            if (dt.Rows.Count == 0)   //如果找不到数据
            {
                MessageBox.Show("登陆失败！请检查账号和密码！", "错误提示！", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
                return;
            }
            else //成功登陆后将登陆人员信息写入user类中
            {
                DataRow dr = dt.Rows[0];
                User.userName = dr["username"].ToString();
                User.name = dr["name"].ToString().Trim();
                User.section = dr["sectionname"].ToString().Trim();
                User.grant = dr["PersonalGrant"].ToString();
                login = true;   //设置为true之后，program.cs才能够继续执行。


                //设置执行顺序
                if (config.UserNameList.Contains(User.userName))
                {
                    config.UserNameList.Remove(User.userName);
                }
                config.UserNameList.Insert(0, User.userName);
                config.FWQindex = fwqCB.SelectedIndex;
                TREConfig.Save(config);

                this.Dispose();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
       

        /// <summary>
        /// 无用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) //将host写入
        {

            string hosts = "\r\n 192.168.1.131 Computer\r\n 192.168.1.132 Computer-2";
            string str = System.IO.File.ReadAllText(@"C:\WINDOWS\system32\drivers\etc\hosts");

            Regex reg = new Regex(hosts);
            Match mat = reg.Match(str);
            while (mat.Success)
            {
                MessageBox.Show("已经添加HOSTS，无需修复");
                return;
            } 

            FileStream fs = new FileStream(@"C:\WINDOWS\system32\drivers\etc\hosts", FileMode.Append
, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
 
            sw.WriteLine(hosts);
            sw.Close();
            fs.Close();
            MessageBox.Show("HOSTS添加成功！请重新尝试登陆~");
        }

        private void Login_Shown(object sender, EventArgs e)    //第一次显示时设置
        {
            if (comboBox1.Text != "")
            {
                textBox2.Focus();   //焦点设在密码框中
            }
        }




    }
}