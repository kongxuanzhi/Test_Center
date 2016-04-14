using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
using System.Text.RegularExpressions;

namespace TRESystem2011.Sample
{
    public partial class SampleAdd : Form
    {
        private int SnoCount=0;
        public SampleAdd()
        {
            InitializeComponent();
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            sampleUC1.init();
            titemsUC1.init();
            titemsUC1.snControl = sampleUC1.infoGroupBox.Controls["SnameTB"];
            titemsUC1.stControl = sampleUC1.infoGroupBox.Controls["SspecificationTB"];
            titemsUC1.sgControl = sampleUC1.infoGroupBox.Controls["SgradeCB"];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string BaseInfoCheck_Result = sampleUC1.getChecks();
            if (BaseInfoCheck_Result != null)
            {
                MessageBox.Show(BaseInfoCheck_Result);
                return;
            }
            //待测的样品包含的元素种类表
            DataTable TestInfo = titemsUC1.getDataTable();

            if (!Libs.checkDT(TestInfo))
            {
                MessageBox.Show("样品检测项目未选或者，检测项目名称为空！");
                return;
            }

            //废弃
            //if (sampleUC1.SOriginalNoTB.Text == LastSorginalLB.Text) //如果样品编号相同则弹出警告！
            //{
            //    if (MessageBox.Show("样品原编号和上一个相同！是否继续", "警告", MessageBoxButtons.YesNo) == DialogResult.No)
            //    {
            //        return;
            //    }
            //}
            List<string> moreItems = new List<string>();
            foreach (DataRow tmpdr in TestInfo.Rows)
            {
                if (DB.ExecuteScalar(string.Format("select titem from itemtable where titem='{0}'", tmpdr["Titem"])) == "")
                {
                    //找不到检测项目则添加                                                                                                                                                                                                                                                                                                                                                            
                    moreItems.Add(tmpdr["Titem"].ToString());
                }
            }
            if (moreItems.Count > 0)//如果存在新增 检测项目
            {
                MessageBox.Show("存在尚未添加图片的新检测项目！请添加！");
                Items.ItemAdd f = new Items.ItemAdd();
                f.init(moreItems);
                f.ShowDialog();
            }
            DataRow Sampledr = sampleUC1.getNewDataRow();
            //Sampledr["SoriginalNo"] = Regex.Replace(Sampledr["SoriginalNo"].ToString(), "(\\r\\n)+", ",");
            Sampledr["WhoTake"] = User.name;
            string newsno=SampleControl.addNewSample(Sampledr, TestInfo);
            MessageBox.Show("任务添加成功！任务编号："+newsno);
            //不懂
            if (User.TSMODE)   //如果是特殊服务器则直接校对签收完毕
            {
                SampleControl.sproof(newsno);
                SampleControl.signin(newsno);
            }
            lastSnoLB.Text = newsno;
            LastSorginalLB.Text = Regex.Replace(Sampledr["SOriginalNo"].ToString(), "(\\r\\n)+", ",");
            InnerNo.Text = getInnerNo(newsno);
            SnoCount++;
            CountLB.Text = SnoCount.ToString();
            sampleUC1.initTime();
            //sampleUC1.SOriginalNoTB.Text = "";//将原编号改成空值，防止连续按下2次
        }
        /// <summary>
        /// 获得试样编号显示出来  //孔龙飞
        /// </summary>
        /// <param name="newsno"></param>
        /// <returns></returns>
        public string getInnerNo(string newsno)
        {
            string sql = string.Format("select SampleNO from SampleSerialNO where sno = '{0}'",newsno);
            List <object> f = DB.getList(sql);
            List<string> SampleNOs = new List<string>(f.Count);
            foreach (var item in f)
            {
                SampleNOs.Add(item.ToString());
            }
            return string.Join(",",SampleNOs.ToArray());
        }
    }
}
