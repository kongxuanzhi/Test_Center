using Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TRESystem2011.Code;

namespace TRESystem2011.Test
{
    public partial class Verify : Form
    {
        private string sno;
        private string fileName;

        public Verify()
        {
            InitializeComponent();
        }
        public Verify(string sno)
        {
            InitializeComponent();
            this.sno = sno;
            fileName = Application.StartupPath + "\\docs\\" + sno + ".docx";
        }
        private void Verify_Load(object sender, EventArgs e)
        {
            //1、将报表显示出来
            ShowBrief();
            //2、将详情显示出来
           
            object ishas = DB.ExecuteObject("select TEstDoc from Sampletable where sno='" + sno + "'");
            if (!string.IsNullOrEmpty(ishas.ToString()))
            {
                ShowDetail();
            }
            this.WindowState = FormWindowState.Maximized;
        }

        private void ShowDetail()
        {
            try
            {
                new FileToDB().show(sno,fileName);
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

        private void ShowBrief()
        {

            ReportFactory rf = new ReportFactory();
            rf.FillReportViewer(crystal_result_main, sno, "简约格式",false);
            //MidDBReport ds = new MidDBReport();
            //DataRow dr = ds.MittionReport.NewRow();
            //string sql = "select Sno,Cno,Sname,Sstate,Squantity,Sintime,chargestd,WhoTake,customerNo,customername,relation,tel, Costtotal as totalMoney,Ssignintime,Taccording,Tkind,MainDevice,TestResult,Sremark from Sampletable S,Customer C where S.Cno = C.customerNo and Sno = '" + sno + "'";
            //DataTable tempdr = DB.getDataTable(sql);
            //for (int i = 0; i < tempdr.Columns.Count; i++)
            //{
            //    string colName = tempdr.Columns[i].ColumnName;
            //    dr[colName] = tempdr.Rows[0][colName];
            //}
            //#region 试样编号
            //List<object> SampleNOs = DB.getList("select SampleNO from SampleSerialNO where Sno = '" + sno + "'");
            //string SampleNO = "";
            //for (int i = 0; i < SampleNOs.Count; i++)
            //{
            //    SampleNO += SampleNOs[i].ToString();
            //    if (i != SampleNOs.Count - 1)
            //    {
            //        SampleNO += ",";
            //    }
            //}
            //dr["SampleNOs"] = SampleNO;
            //#endregion
            //#region 检测项目字符串用逗号隔开
            //List<object> Titem = DB.getList("select Titem from Resulttable where Sno = '" + sno + "'");
            //string Titems = "";
            //for (int i = 0; i < Titem.Count; i++)
            //{
            //    Titems += Titem[i].ToString();
            //    if (i != Titem.Count - 1)
            //    {
            //        Titems += ",";
            //    }
            //}
            //dr["Titem"] = Titems;
            //#endregion
            //#region 主检检测时间
            //string sqltime = "select Souttime from Sampletable where sno='"+ sno + "'";
            //DateTime dt = Convert.ToDateTime(DB.ExecuteObject(sqltime));
            //dr["Year"] = dt.Year;
            //dr["Month"] = dt.Month;
            //dr["Day"] = dt.Day;
            //#endregion
            //dr["mainTest"] = (Byte[])DB.ExecuteObject("select underwrite from users,sampletable where Smastertest=username and  sno='" + sno + "'");
            //dr["Checked"] = (Byte[])DB.ExecuteObject("select underwrite from users,sampletable where Sverifier=username and  sno='" + sno + "'");
            //dr["approve"] = (Byte[])DB.ExecuteObject("select underwrite from users,sampletable where Sapprover=username and  sno='" + sno + "'");

            ////将图片加上去
            //dr["CAM"] = Res.cma;
            //dr["CenterZhang"] =  Res.test;

            //ds.MittionReport.Rows.Add(dr);
            //DB.fillDataSet(ds, "SampleSerialNO", "SELECT Id,SoriginalNo, SampleNO,sno FROM SampleSerialNO where sno='" + sno + "' ");
            ////将数据填充到dt，
            ////将dt绑定到view
            //ReportFactory rf = new ReportFactory();
            //rf.PrintResult(crystal_result_main, sno, ds);
        }

        private void button1_Click(object sender, EventArgs e)
        {
              DialogResult dialogresult = MessageBox.Show("结果无误？", "提示！", MessageBoxButtons.YesNo);
                if (dialogresult == DialogResult.Yes)
                {
                    if (SampleControl.verify(sno))
                    {
                        MessageBox.Show("提交审核成功！");
                    //  this.Dispose();
                       ShowBrief();
                    }
                    else
                    {
                        MessageBox.Show("提交审核失败！");
                    };
                }
                else if (dialogresult == DialogResult.No)
                {
                    return;
                }
        }
        private void Verify_FormClosed(object sender, FormClosedEventArgs e)
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
