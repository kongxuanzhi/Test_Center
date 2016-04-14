using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;

namespace TRESystem2011.Sample
{
    public partial class SampleMuiltyAuthorize : Form
    {
        public SampleMuiltyAuthorize()
        {
            InitializeComponent();
        }


        public void setMode(string modeType)
        {
            if (modeType == "yw")
            {
                itemCB.Enabled = false;
                resultCB.Enabled = false;
            }
            else if (modeType == "result")
            {
                infoCB.Enabled = false;
                jyCB.Enabled = false;
                hyCB.Enabled = false;
                costCB.Enabled = false;
                itemCB.Enabled = false;
            }
        }


        /// <summary>
        /// 授权修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("是否确认批准选中样品的修改？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            List<string> snos = searchGridView1.getSelectIds();
            if (snos.Count == 0)
            {
                MessageBox.Show("未选中授权样品！");
                return;
            }


            string sqxm = "";   //授权项目

            sqxm += infoCB.Checked == true ? "CanBaseInformation='true'," : "";
            sqxm += jyCB.Checked == true ? "CanSintime='true'," : "";
            sqxm += hyCB.Checked == true ? "CanScontracttime='true'," : "";
            sqxm += costCB.Checked == true ? "CanCost='true'," : "";
            sqxm += itemCB.Checked == true ? "CanItems='true'," : "";

            sqxm = sqxm.TrimEnd(',');   //去掉末尾的逗号

            string snoArrayStr = Libs.arrayToString(snos.ToArray(), ",", "'");  //样品列表

            if (sqxm != "") //如果不为空则执行授权SQL
            {
                string sql = "update sampletable set " + sqxm;
                sql += " where sno in (" + snoArrayStr + ")";

                //MessageBox.Show(sql);
                DB.ExecuteNonQuery(sql);


            }


            
//             //获取当前选项状态
//             string infostr = infoCB.Checked == true ? "true" : "false";
//             string jystr = jyCB.Checked == true ? "true" : "false";
//             string hystr = hyCB.Checked == true ? "true" : "false";
//             string coststr = costCB.Checked == true ? "true" : "false";
//             string itemstr = itemCB.Checked == true ? "true" : "false";
//             //string resultstr = resultCB.Checked == true ? "true" : "false";

//             string snoArrayStr = Libs.arrayToString(snos.ToArray(), ",", "'");
//             string sql=string.Format("update sampletable set CanBaseInformation='{0}',CanSintime='{1}',CanScontracttime='{2}',CanCost='{3}',CanItems='{4}' where sno in (",infostr,jystr,hystr,coststr,itemstr);
//             sql += snoArrayStr + ")";

            //DB.ExecuteNonQuery(sql);


            if (resultCB.Checked)   //样品结果修改单独放出
            {
                string sql = "update sampletable set Souttime='/',Sverifytime='/',Sapprovetime='/',Rsendtime='/',Sfiller='/',Sverifier='/',Sprinter='/',Sapprover='/',Rsender='/' where sno in (";
                sql += snoArrayStr + ")";
                //MessageBox.Show(sql);
                DB.ExecuteNonQuery(sql);
            }

            try
            {
                Log.AddLogEx(snoArrayStr, "授权", sqxm);  //添加日志
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("日志写入失败！"+ex.Message);

            }


            MessageBox.Show("批准成功！");

        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (searchBar1.search())
            {
                searchGridView1.setDataTable(searchBar1.getDataTable());
            }

        }

        private void SampleMuiltyAuthorize_Load(object sender, EventArgs e)
        {
            searchBar1.Init();
        }
    }
}
