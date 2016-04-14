using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TRESystem2011.Code;

namespace TRESystem2011.Sample
{
    public partial class Word审核 : Form
    {
        string fileName;
        private string sno;

        public Word审核()
        {
            InitializeComponent();
        }
        public Word审核(string sno)
        {
            this.sno = sno;
            fileName = Application.StartupPath + "\\docs\\" + sno + ".docx";
            InitializeComponent();
            this.Text = sno;
        }

        private void Word审核_Load(object sender, EventArgs e)
        {
            ShowDetail();
        }

        private void ShowDetail()
        {
            try
            {
                new FileToDB().show(sno, fileName);
                this.axFramerControl1.Open(fileName);
            }
            catch (Exception)
            {
                MessageBox.Show("打开失败！");
                Process myProcess = new Process();
                Process[] wordProcess = Process.GetProcessesByName("winword");
                try
                {
                    foreach (Process pro in wordProcess) //这里是找到那些没有界面的Word进程
                    {
                        IntPtr ip = pro.MainWindowHandle;

                        string str = pro.MainWindowTitle; //发现程序中打开跟用户自己打开的区别就在这个属性
                                                          //用户打开的str 是文件的名称，程序中打开的就是空字符串
                        if (string.IsNullOrEmpty(str))
                        {
                            pro.Kill();
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        private void Word审核_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Thread(delegate () {
                while (FileToDB.IsFileOpen(fileName)) ;
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }).Start();
        }
    }
}
