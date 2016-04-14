using Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TRESystem2011.Code;

namespace TRESystem2011.Sample
{
    public partial class ResultSubmit : Form
    {
        private string FileName;
        private string sno;
        public ResultSubmit()
        {
            InitializeComponent();
        }
        public ResultSubmit(string sno)
        {
            this.sno = sno;
            InitializeComponent();
            //this.sno = "2016N1";
        }

        private void ResultSubmit_Load(object sender, EventArgs e)
        {
            //1、绑定检测依据
         //   Init();
            label6.Text = sno;
        }

        //private void Init()
        //{
        //    DataTable dt = DB.getDataTable("select * from method");
        //    List<string> accordings = new List<string>();
        //    for (int i = 0; dt != null && i < dt.Rows.Count; i++)
        //    {
        //        string according = dt.Rows[i]["methodnumber"].ToString().Trim();
        //        according += dt.Rows[i]["methodname"].ToString().Trim();
        //        accordings.Add(according);
        //    }
        //    Cb_according.Items.AddRange(accordings.ToArray()) ;
        //}
        private void Btn_Submit_Click(object sender, EventArgs e)
        {
            string text = string.IsNullOrEmpty(Cb_according.Text)? "检测依据没填，确认提交？" :
                string.IsNullOrEmpty(Tb_mainDevice.Text) ? "主要设备没填，确认提交？" :
                string.IsNullOrEmpty(Tb_result.Text) ? "检验结果没填，确认提交？" :
                string.IsNullOrEmpty(Tb_Other.Text) ? "备注没填，确认提交？" : "可以提交";
            DialogResult dr = MessageBox.Show(text, "提示", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                DataRow row = DB.getDataRow("select * from Sampletable where Sno = '" + this.sno + "'");
                string sqlstr = string.Format("update Sampletable set " +
                "Taccording='{0}',MainDevice='{1}',TestResult='{2}',Sremark='{3}',Smastertest='{4}'" +
                "where Sno = '{5}'",Cb_according.Text.Trim(),Tb_mainDevice.Text.Trim(), Tb_result.Text.Trim(), Tb_Other.Text.Trim(), User.name,this.sno);
                try
                {
                    DB.ExecuteNonQuery(sqlstr);
                    SampleControl.Sout(this.sno);  //填写完检时间
                }
                catch (Exception)
                {
                    MessageBox.Show("填报失败，可能是因为网络的原因~~");
                    return;
                }
                sqlstr = string.Format("update users set Uindex=(select max(uindex) from users)+1 where username='{0}'", User.name);
                try
                {
                    DB.ExecuteNonQuery(sqlstr);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("此主检人员在数据库中无签名，请联系管理员添加！" + ex.Message);
                }
                MessageBox.Show("提交成功！");
            }
            else if (dr == DialogResult.Cancel)
            {
                return;
            }
        }

        private void Detail_Click(object sender, EventArgs e)
        {
            WordEdit worfEdit = new WordEdit(sno);
            worfEdit.ShowDialog();
            //FileName = worfEdit.getFileName();
            //if (File.Exists(FileName))
            //{
            //    File.Delete(FileName);
            //}
        }
        private void ResultSubmit_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
