using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Code;
using System.Data.OleDb;
using System.Threading;
using System.Diagnostics;
using System.Configuration;
using ICPTOOLS_DONET;
using TRESystem2011.Sample;

namespace TRESystem2011
{
    public partial class Systems : Form
    {
        public Systems()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 进行权限初始化工作
        /// </summary>
        void initMenuGrant()
        {
            if (User.grant.Contains("管理员"))  //管理员账号全部功能开放
            {
                foreach (ToolStripMenuItem t in menuStrip1.Items)
                {
                    t.Enabled = true;
                }
                return;
            }
            if (User.section == "领导")  //领导直接给基本信息
            {
                JBXXMenu.Enabled = true;
            }

            if (User.grant.Contains("基本信息"))
            {
                JBXXMenu.Enabled = true;
            }
            if (User.grant.Contains("样品管理"))
            {
                YPGLMenu.Enabled = true;
            }
            if (User.grant.Contains("业务管理"))
            {
                YWGLMenu.Enabled = true;
            }
            if (User.grant.Contains("检测登录"))
            {
                JCDLMenu.Enabled = true;
                ICPMenu.Enabled = true;
            }
            if (User.grant.Contains("检测管理"))
            {
                JCGLMenu.Enabled = true;
            }
            if (User.grant.Contains("授权签字"))
            {
                SQQZMenu.Enabled = true;
            }
            if (User.grant.Contains("检验报告"))
            {
                JYBGMenu.Enabled = true;
            }
            if (User.grant.Contains("易耗品管理"))
            {
                YHPMenu.Enabled = true;
            }
        }

        private void Systems_Load(object sender, EventArgs e)
        {
            //need to a new thread  to load resource
            try
            {
                Res.load(); //预读资源
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("资源加载失败！程序可能已经损坏，请重新安装或联系管理员！");
                Application.Exit();
            }

            initMenuGrant();
            this.Text = "业务系统——" + User.name;
            this.WindowState = FormWindowState.Maximized;
            GrantLB.Text = string.Format("当前用户权限：【{0}】", User.grant);

            string StatuStr = "";

            if (User.IsOfficial)
            {
                StatuStr += "当前数据库：【正式数据库】";
            }
            else
            {
                StatuStr += "当前数据库：【测试数据库】";
            }
            StatuStr+=string.Format("服务器：【{0}】 库名：【{1}】", DB.m_conn.DataSource, DB.m_conn.Database);


            if (User.TSMODE == true)
            {
                
                menuStrip1.BackColor = Color.LightPink;
                this.Text = "特殊样品管理系统——" + User.name;
                TSYPMenu.Visible = true;
                YWGLMenu.Visible = false;
                JCDLMenu.Visible = false;
                JCGLMenu.Visible = false;
                SQQZMenu.Visible = false;
                JYBGMenu.Visible = false;
                YHPMenu.Visible = false;

                修改样品信息ToolStripMenuItem.Visible = false;//样品修改
                
                StatuStr += "【特殊模式】";
            }

            DBstatusLabel.Text = StatuStr;

//             WebForm wf = new WebForm();
//             wf.MdiParent = this;
//             wf.Show();


        }

        private void 样品登录ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sample.SampleAdd f = new Sample.SampleAdd();
            f.MdiParent = this;
            f.Show();
        }
        /// <summary>
        /// 新增 任务单打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打印任务单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MissionReport missionReport = new MissionReport();
            missionReport.Show();
        }

        private void 客户登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer.CustomerForm f = new Customer.CustomerForm();
            f.MdiParent = this;
            f.Show();
        }

        private void 修改样品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sample.ModifySampleList myfrm = new TRESystem2011.Sample.ModifySampleList();
            myfrm.MdiParent = this;
            myfrm.Show();
        }

        private void 批准样品信息修改ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //批准结果修改
            Sample.SampleMuiltyAuthorize f = new Sample.SampleMuiltyAuthorize();
            f.MdiParent = this;
            f.setMode("result");
            f.Show();
        }

        private void 批准样品信息修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //批准业务修改
            Sample.SampleMuiltyAuthorize f = new Sample.SampleMuiltyAuthorize();
            f.MdiParent = this;
            f.setMode("yw");
            f.Show();
        }

        private void 批准样品信息修改ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //批准样品所有修改
            Sample.SampleMuiltyAuthorize f = new Sample.SampleMuiltyAuthorize();
            f.MdiParent = this;
            f.Show();
//             Sample.SelectInformation myfrm = new TRESystem2011.Sample.SelectInformation();
//             myfrm.MdiParent = this;
//             myfrm.Text = "批准样品修改";
//             myfrm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            Sample.SampleCheck sc = new TRESystem2011.Sample.SampleCheck();
            sc.MdiParent = this;
            sc.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Sample.SampleSignin ss = new TRESystem2011.Sample.SampleSignin();
             ss.MdiParent = this;
             ss.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)   //样品流转
        {
            Sample.SampleTransfer f = new TRESystem2011.Sample.SampleTransfer();
            f.MdiParent = this;
            f.Show();
 
        }

        private void 批准打印报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sample.SampleApprove f = new Sample.SampleApprove();
            f.MdiParent = this;
            f.Show();
        }

        private void reportMenuItem2_Click(object sender, EventArgs e)//打印发出检验报告
        {
            Sample.PrintReport f = new Sample.PrintReport();
            f.MdiParent = this;
            f.Show();
        }

        private void 批量填报ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //已改为数据填报
            Test.WriteinList f = new Test.WriteinList();
           
            f.MdiParent = this;
            f.Show();

        }

        private void 新增检测项目ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Items.ProductManage f = new Items.ProductManage();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)   //打印注意事项
        {
            ReportForm myfrm = new ReportForm();
            myfrm.MdiParent = this.MdiParent;
            myfrm.initAttention();
            myfrm.Show();
        }

        private void toolStripMenuItem147_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void userMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem146_Click(object sender, EventArgs e)
        {
            MessageBox.Show("作者：微波老师\r\n最后更新日期：2014-11-11");
        }

        private void 更新日期ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage.UpdateForm uf = new Manage.UpdateForm();
            uf.MdiParent = this;
            uf.Show();
        }

        private void 签名管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage.UploadMark f = new Manage.UploadMark();
            f.MdiParent = this;
            f.Show();
        }

        private void 人员管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage.PersonManage f = new Manage.PersonManage();
            f.MdiParent = this;
            f.Show();
        }

        private void 检验进度查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sample.SampleProcess f = new Sample.SampleProcess();
            f.MdiParent = this;
            f.Show();
        }

        /// <summary>
        /// 统计信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Sample.SampleCount f= new Sample.SampleCount();
            f.MdiParent = this;
            f.Show();   
        }

        private void 批量样品登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sample.SampleMuiltyAdd f = new Sample.SampleMuiltyAdd();
            f.MdiParent = this;
            f.Show();
        }

        private void 强制更新修复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("强制更新将会退出当前程序，是否继续？","提醒",MessageBoxButtons.OKCancel)==DialogResult.Cancel)
            {
                return;
            }
            try
            {
                File.Delete(Application.StartupPath+@"\LastUpdate.xml");

                string appName = "updater.exe"; //更新程序

                try
                {
                    Process proc = Process.Start(appName);
                }
                catch (Exception)
                {
                    MessageBox.Show("更新程序启动失败！");
                    return;
                }
            }
            catch (System.Exception ex)
            {
            	MessageBox.Show(ex.Message);
            }
            Application.Exit();


        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person.ChangePassword f = new Person.ChangePassword();
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)//账务管理
        {
            Sample.SampleMoney f = new Sample.SampleMoney();
            f.MdiParent = this;
            f.Show();
        }

        private void 批量审核ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Test.VerifyList f = new Test.VerifyList();
            f.MdiParent = this;
            f.Show();

        }

        private void 易耗品综合管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YHP.yhpManage f = new YHP.yhpManage();
            f.MdiParent = this;
            f.Show();
        }

        private void 检测项目图片管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Items.ItemManage f = new Items.ItemManage();
            f.MdiParent = this;
            f.Show();
        }

        private void 特殊样品一览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TS.YWTSSample f = new TS.YWTSSample();
            f.MdiParent = this;
            f.Show();
        }

        /// <summary>
        /// 检测部样品进度查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem7_Click_1(object sender, EventArgs e)
        {
            Sample.SampleProcess f = new Sample.SampleProcess();
            f.setTestMode();
            f.MdiParent = this;
            f.Show();
        }

        private void 检测管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TS.JCTSSample f = new TS.JCTSSample();
            f.MdiParent = this;
            f.Show();
        }

        private void 业务量统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer.YWLCount f = new Customer.YWLCount();
            f.MdiParent = this;
            f.Show();
        }

        private void 库存管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YHP.yhpInOut f = new YHP.yhpInOut();
            f.MdiParent = this;
            f.Show();
        }

        private void 易耗品查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YHP.yhpHistoryView f = new YHP.yhpHistoryView();
            f.MdiParent = this;
            f.Show();
        }

        private void 检测项目图片管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Items.ItemManage f = new Items.ItemManage();
            f.MdiParent = this;
            f.Show();
        }

        private void 日志查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage.LogForm f = new Manage.LogForm();
            f.MdiParent = this;
            f.Show();
        }

        private void 数据库万能查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manage.SQLManage f = new Manage.SQLManage();
            f.MdiParent = this;
            f.Show();
        }

        private void 解析配分铝ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICPTOOLS_DONET.PFALForm f = new ICPTOOLS_DONET.PFALForm();
            f.MdiParent = this;
            f.Show();
        }

        private void 解析纯度ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICPTOOLS_DONET.PureForm f = new ICPTOOLS_DONET.PureForm();
            f.MdiParent = this;
            f.Show();
        }

        private void 解析报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICPTOOLS_DONET.RPTForm f=new ICPTOOLS_DONET.RPTForm();
            f.MdiParent = this;
            f.Show();
        }
    }
}