using Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TRESystem2011.Code;

namespace TRESystem2011.Sample
{
    public partial class WordEdit : Form
    {
        private string sno;
        private string fileName;
        public WordEdit()
        {
            InitializeComponent();
        }
        public WordEdit(string sno)
        {
            InitializeComponent();
            this.sno = sno;
            fileName = Application.StartupPath + "\\docs\\" + sno + ".doc";
        }
        public string getFileName()
        {
            return fileName;
        }
        private void WordEdit_Load(object sender, EventArgs e)
        {
           // string fileName = Application.StartupPath + "\\fdfdffdf.doc";
            object ishas = DB.ExecuteObject("select TEstDoc from Sampletable where sno='" + sno + "'");
            if (!string.IsNullOrEmpty(ishas.ToString()))
            {
                new Thread(delegate ()
                {
                    ShowDetail();
                }).Start();
            }
        }
        private void ShowDetail()
        {
            try
            {
                new FileToDB().show(sno,fileName);
                this.axFramerControl1.Open(fileName); //打开文件占用了资源，需要释放
            }
            catch (Exception e)
            {
                MessageBox.Show("打开错误");
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
        }

        private void axFramerControl1_OnSaveCompleted_1(object sender, AxDSOFramer._DFramerCtlEvents_OnSaveCompletedEvent e)
        {
            string fileName2 = e.fullFileLocation;
            new FileToDB().SaveToDB(sno, fileName2);
        }

        private void WordEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            new Thread(delegate() {
                while (FileToDB.IsFileOpen(fileName));
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }).Start();
        }
    
    }
}
