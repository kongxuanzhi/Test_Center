using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;

namespace TRESystem2011.Customer
{
    public partial class YWLCount : Form
    {
        public YWLCount()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string name =  nameCB.Text;
            string sdate = startDTP.Value.ToString("yyyy-MM-dd");
            string edate = endDTP.Value.ToString("yyyy-MM-dd");
           // string sql = "select * from Sampletable  ";
            string sql = "select sampletable.*,customer.* from sampletable,customer where sampletable.cno=customer.customerno ";
            sql += string.Format("and Smastertest = '{0}' and convert(datetime, Sintime,120) between convert(datetime,'{1}', 120) and dateadd(day,1, convert(datetime, '{2}', 120))", name, sdate, edate);
            //sql += string.Format("and customer.introducer='{0}' and convert(datetime,Sintime,120) between convert(datetime,'{1}',120) and dateadd(day,1,convert(datetime,'{2}',120))", name, sdate, edate);
            DataTable dt = DB.getDataTable(sql);
            searchGridView1.setDataTable(dt);
            countMoneyInfo(dt);
        }

        private void YWLCount_Load(object sender, EventArgs e)
        {
            string sql = "select DisTinct  Smastertest from Sampletable";
            //string sql = "select distinct(introducer) from customer";
            List<object> l = DB.getList(sql);
            nameCB.DataSource = l;
        }


        /// <summary>
        /// 统计money信息
        /// </summary>
        public void countMoneyInfo(DataTable dt)
        {

            int count = dt.Rows.Count;  //样品数量
            int JCOver = 0; //检测超时样品
            //int SYOver = 0; //收样超时样品
            double jcfy = 0;    //检测费用  
            double jjfy = 0;    //加急费用
            double zyfy = 0;    //制样费用
            double wffy = 0;    //未付费用
            string moneyInfo = "";


            bool hasBug = false;


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
                        if (DateTime.Now.Date > Scontracttime)
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

            moneyInfo += "样品数量" + count + "个，其中超时样品" + JCOver + "个。";
            moneyInfo += "总收入" + Convert.ToString(jcfy + jjfy + zyfy) + "元,其中：检测费用" + Convert.ToString(jcfy) + "元,加急费用" + Convert.ToString(jjfy) + "元,制样费用" + Convert.ToString(zyfy) + "元,未付费用" + Convert.ToString(wffy) + "元。";

            infoTB.Text = moneyInfo;

        }
    }
}
