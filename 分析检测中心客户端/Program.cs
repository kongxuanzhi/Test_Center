using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using TRESystem2011.Sample;

namespace TRESystem2011
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool checkUpdate = true;
            try
            {
                if (ConfigurationManager.AppSettings["CheckUpdate"].ToString() == "false")
                {
                    checkUpdate = false;
                };
            }
            catch (Exception)
            {

            }

            //if (checkUpdate)
            //{
            //    string appName = "updater.exe"; //更新程序

            //    try
            //    {
            //        Process proc = Process.Start(appName);
            //        if (proc != null)
            //        {
            //            proc.WaitForExit();
            //            MessageBox.Show("更新程序已经退出！");
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        MessageBox.Show("更新程序启动失败！");
            //    }

            //}

            Login myfrm = new Login();
            myfrm.ShowDialog();
            if (myfrm.login)
            {
                myfrm.Close();
                Application.Run(new Systems());
            }

        }
    }
}