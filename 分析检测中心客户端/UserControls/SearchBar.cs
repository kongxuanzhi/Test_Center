using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Code;

namespace TRESystem2011.UserControls
{
    public partial class SearchBar : UserControl
    {
        public string sqlstr="";   //上次查询的sql
        //public string searchInfo="";   //上次查询中文说明
        public string moneyInfo="";    //金钱统计情况
        public string reportInfo = ""; //报告统计情况

        bool flag = false;

        public DataSet ds=null;      //上次使用的ds

        //以下是金钱统计
        int count=0;  //样品数量
        int JCOver=0 ; //检测超时样品
        //int SYOver=0 ; //收样超时样品
        double jcfy=0 ;    //检测费用  
        double jjfy=0 ;    //加急费用
        double zyfy=0 ;    //制样费用
        double wffy=0 ;    //未付费用

        //以下是报告统计
        int rpt_jx = 0;
        int rpt_gj = 0;
        int rpt_jy = 0;
        int rpt_wz = 0;
        int rpt_cma = 0;
        int rpt_cal = 0;
        int rpt_cnas = 0;
        

        public SearchBar()
        {
            InitializeComponent();
            sqlstr = "";
        }

        public int getSampleCount()
        {
            return ds.Tables[0].Rows.Count;
        }

        public void setInfoVisible(bool flag)   //信息是否显示
        {
            groupBox4.Visible = flag;
        }

        public void setCtrlVisible(bool flag)   //控制台是否显示
        {
            groupBox3.Visible = flag;
        }

        private void SearchBar_Load(object sender, EventArgs e)
        {
        }

        public void Init()  //控件初始化代码
        {
            string sqlstr = "Select ID,KindsName,TestKinds,i from SampleKinds order by i";
            DataTable dt = DB.getDataTable(sqlstr);
            DataRow dr = dt.NewRow();
            dr[0] = "QB";
            dr[1] = "全部";
            dt.Rows.InsertAt(dr, 0);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "KindsName";
            comboBox1.ValueMember = "ID";
            tabControl1.SelectedIndex = 1;
            DateTypeBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 创建搜索用的SQL语句
        /// </summary>
        public bool createSearchSql(string sqlTtemplate)
        {
            string searchTemp = "";

            if (sqlTtemplate == "")    //如果没有指定模板，则用默认模板
            {
                sqlTtemplate = "select sampletable.*,customer.* from sampletable,customer where sampletable.cno=customer.customerno {0} order by sno DESC";
            }

            flag = false;  //做查询范围判断

            if (tabControl1.SelectedIndex == 0) //精确搜索
            {

                if (SnoBox.Text.Trim() != "")
                {
                    StringBuilder str = new StringBuilder();
                    for (int i = 0; i < SnoBox.Lines.Length; i++)
                    {
                        if (i > 0)
                        {
                            str.Append(" or ");
                        }
                        if (SnoBox.Lines[i].Trim() != "")  //不匹配空行
                        {
                            str.Append(string.Format("sno like '%{0}%'", SnoBox.Lines[i]));
                        }
                    }

                    searchTemp += "and (" + str + ")";

                    flag = true;
                }
                if (SoriginalBox.Text.Trim() != "")
                {
                    StringBuilder str = new StringBuilder();
                    for (int i = 0; i < SoriginalBox.Lines.Length; i++)
                    {
                        if (i > 0)
                        {
                            str.Append(" or ");
                        }
                        if (SoriginalBox.Lines[i].Trim() != "")  //不匹配空行
                        {
                            str.Append(string.Format("soriginalno like '%{0}%'", SoriginalBox.Lines[i]));
                        }
                    }

                    searchTemp += "and (" + str + ")";

                    flag = true;
                }


            }
            else if (tabControl1.SelectedIndex == 1)    //模糊搜索
            {
                if (checkBox1.Checked)  //按名称
                {

                    if (textBox1.Text.Trim() != "")
                    {
                        searchTemp += " and Sname like '%" + textBox1.Text.Trim() + "%' ";
                        flag = true;
                    }
                    if (textBox2.Text.Trim() != "")
                    {
                        searchTemp += " and customer.customername  like '%" + textBox2.Text.Trim() + "%' ";
                        flag = true;
                    }
                    if (comboBox1.Text.Trim() != "全部")
                    {
                        searchTemp += "and Skind='" + comboBox1.SelectedValue.ToString().Trim() + "' ";
                    }

                }
                if (checkBox2.Checked)  //按时间
                {
                    string timetype = "";
                    if (DateTypeBox.SelectedItem.ToString() == "进样日期")
                    {
                        timetype = "Sintime";
                    }
                    else if (DateTypeBox.SelectedItem.ToString() == "合约日期")
                    {
                        timetype = "Scontracttime";
                    }
//                     else if (DateTypeBox.SelectedItem.ToString() == "授权日期")
//                     {
//                         timetype = "Sapprovetime";   //日期转换的BUG尚未解决
//                     }
//                     else if (DateTypeBox.SelectedItem.ToString() == "发送日期")
//                     {
//                         timetype = "Rsendtime";
//                     }
                    searchTemp += string.Format("and convert(datetime,{0},120) between convert(datetime,'{1}',120) and dateadd(day,1,convert(datetime,'{2}',120)) ", timetype, dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                    //这里sql中的between默认按当天时间0点来的，所以后面的日期要+1天再来汇总
                    flag = true;
                }
            }
            else if (tabControl1.SelectedIndex == 2)   //预设搜索无需设置SQL语句，直接得到table
            {
                return false;
            }
            else if (tabControl1.SelectedIndex == 3)    //按检测项目搜索，较为复杂，直接拼接出SQL，无法使用模板
            {
                searchTemp="select * from sampletable,customer,(select sno,";
                foreach (string item in ItemTB.Lines)
                {
                    if (checkBox3.Checked)   //开启模糊搜索
                    {
                        searchTemp += string.Format("max(case when Titem like '%{0}%' then Tvalue else null end){0},", item);
                    }
                    else
                    {
                        searchTemp += string.Format("max(case Titem when '{0}' then Tvalue else null end){0},", item);
                    }
                }
                searchTemp = searchTemp.TrimEnd(',');
                searchTemp += string.Format(" from resulttable group by sno)t1 where sampletable.cno=customer.customerno and sampletable.sno=t1.sno and sname like '%{0}%'", SnameTB.Text);
                foreach (string item in ItemTB.Lines)
                {
                    searchTemp += string.Format(" and t1.{0} is not null", item);
                }

            }

            if (IsprooferBox.Checked)
            {
                searchTemp += " and Sprooftime!='/'";
            }
            if (IsverifyBox.Checked)
            {
                searchTemp += " and Sverifytime!='/'";
            }
            if (IsapproveBox.Checked)
            {
                searchTemp += " and Sapprovetime!='/'";
            }
            if (IsSendOutBox.Checked)
            {
                searchTemp += " and Rsendtime!='/'";
            }
            if (jjbox.Checked)
            {
                searchTemp += " and Costexpress!='0'";
            }
            if (wfBox.Checked)
            {
                searchTemp += " and Costnopay!='0'";
            }

            if (tabControl1.SelectedIndex == 3) //按检测项目搜索，较为复杂，直接拼接出SQL，无法使用模板
            {
                sqlstr = searchTemp;
            }
            else
            {
                sqlstr = string.Format(sqlTtemplate, searchTemp);
            }
            return true;
        }

        /// <summary>
        /// 进行搜索
        /// </summary>
        /// <returns></returns>
        public bool search()    
        {

            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("起始日期不能大于结束日期！");
                return false;
            }

            if (tabControl1.SelectedIndex == 2)   //预设搜索无需设置SQL语句，直接得到table
            {
                if (IsapproveBox.Checked || IsprooferBox.Checked || IsSendOutBox.Checked || IsverifyBox.Checked || jjbox.Checked||wfBox.Checked)
                {
                    MessageBox.Show("有选项选中时无法使用预设搜索，请取消选项！");
                    return false;
                }

                if (radioButton1.Checked)
                {
                    ds = SampleControl.getSproofDS();
                }
                else if (radioButton2.Checked)
                {
                    ds = SampleControl.getSigninDS();
                }
                else if (radioButton3.Checked)
                {
                    ds = SampleControl.getTestDS();
                }
                else if (radioButton4.Checked)
                {
                    ds = SampleControl.getVerifyDS();
                }
                else if (radioButton5.Checked)
                {
                    ds = SampleControl.getApproveDS();
                }
                else if (radioButton6.Checked)
                {
                    ds = SampleControl.getSendOutDS();
                }
                else if (radioButton7.Checked)
                {
                    ds = SampleControl.getUnCompleteDS();
                }
                countMoneyInfo();
                return true;

            }
            else if(createSearchSql(""))
            {
                if (flag == false)    //如果没有选择任何项目并且没有时间
                {
                    DialogResult dr = MessageBox.Show("查询条件过少，将会查询到大量数据，可能造成卡死，是否继续", "警告", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.No)
                    {
                        return false;
                    }
                }
                ds = DB.getDataSet(sqlstr, "SearchSample");
                countMoneyInfo();//自动统计钱
                return true;
            }

 
            return false;
        }


        /// <summary>
        /// 报告统计
        /// </summary>
        public void countReportInfo()
        {
            reportInfo = "";
            rpt_jx = 0;
            rpt_gj = 0;
            rpt_jy = 0;
            rpt_wz = 0;
            rpt_cma = 0;
            rpt_cal = 0;
            rpt_cnas = 0;



            string tmpsql = "select ReportName from Qstamp,sampletable where Qstamp.samplenumber=sampletable.sno {0}";
            createSearchSql(tmpsql);
//              MessageBox.Show(sqlstr);
//             return;


            DataTable dt = DB.getDataTable(sqlstr);
            int n = dt.Rows.Count;  //总数
            foreach (DataRow dr in dt.Rows)
            {
                string rptName = dr[0].ToString();

                if (rptName.Contains("jx"))
                {
                    rpt_jx++;
                }
                else if (rptName.Contains("gj"))
                {
                    rpt_gj++;
                }
                if (rptName.Contains("简约格式"))
                {
                    rpt_jy++;
                }
                else
                {
                    rpt_wz++;
                }
                if (rptName.Contains("有计量认证")) //旧版报告
                {
                    rpt_cma++;
                    rpt_cal++;
                }
                if (rptName.Contains("有CMA"))  //新版报告
                {
                    rpt_cma++;
                }
                if(rptName.Contains("有CAL"))
                {
                    rpt_cal++;
                }
                if (rptName.Contains("有CNAS"))
                {
                    rpt_cnas++;
                }

            }
            reportInfo += string.Format("报告总数（已授权报告）：{0}份 \r\n", n);
            reportInfo += string.Format("报告抬头情况：【江西】:{0} 【理工】:{1} \r\n", rpt_jx, rpt_gj);
            reportInfo += string.Format("报告格式情况：【简约】:{0} 【完整】:{1} \r\n", rpt_jy, rpt_wz);
            reportInfo += string.Format("印章情况：【CMA】:{0} 【CAL】:{1} 【CNAS】:{2}\r\n", rpt_cma, rpt_cal,rpt_cnas);

        }


        /// <summary>
        /// 统计money信息
        /// </summary>
        public void countMoneyInfo()
        {
            DataTable dt = ds.Tables[0];

            count = dt.Rows.Count;  //样品数量
            JCOver = 0; //检测超时样品
            //SYOver = 0; //收样超时样品
            jcfy = 0;    //检测费用  
            jjfy = 0;    //加急费用
            zyfy = 0;    //制样费用
            wffy = 0;    //未付费用
            moneyInfo = "";


            bool hasBug = false;

            DateTime dtNow = Libs.getServerDate();
            foreach (DataRow dr in dt.Rows) //遍历
            {
                try
                {
                    jcfy += Convert.ToDouble(dr["Costtotal"]);
                    jjfy += Convert.ToDouble(dr["Costexpress"]);
                    zyfy += Convert.ToDouble(dr["CostSpreparation"]);
                    wffy += Convert.ToDouble(dr["Costnopay"]);


                    DateTime Scontracttime = Convert.ToDateTime(dr["Scontracttime"]);
                    if (dr["Sverifytime"].ToString() == "/")
                    {
                        if (dtNow.Date > Scontracttime)
                        {
                            JCOver++;
                        }
                    }
                    else
                    {
                        DateTime Sverifytime = Convert.ToDateTime(dr["Sverifytime"]);
                        if (Sverifytime.Date > Scontracttime)
                        {
                            JCOver++;
                        }
                    }

                }
                catch (Exception)    //如果遇到错误
                {
                    hasBug = true;
                    continue;
                }
            }
            if (hasBug)
            {
                moneyInfo += "【！统计结果可能不精确！】";
            }

            moneyInfo += "样品数量" + count + "个，其中超时样品"+JCOver+"个。";
            moneyInfo += "总收入" + Convert.ToString(jcfy + jjfy + zyfy) + "元,其中：检测费用" + Convert.ToString(jcfy) + "元,加急费用" + Convert.ToString(jjfy) + "元,制样费用" + Convert.ToString(zyfy) + "元,未付费用" + Convert.ToString(wffy) + "元。";
            infoTB.Text = moneyInfo;

        }

        public DataTable getDataTable()
        {
            return ds.Tables[0];
        }



//         public DataSet getDataSet() //返回搜索出来的结果集
//         {
//             if (search())
//             {
//                 countMoneyInfo();//自动统计钱
//                 return ds;
//             }
// 
//             return null;
//         }

    

        public string getInfo() //获取信息文字
        {
            return moneyInfo;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }



    }
}
