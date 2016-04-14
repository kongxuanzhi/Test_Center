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
    public partial class SampleModify : Form
    {

        bool canInfo = false;
        bool canjy = false;
        bool canhy = false;
        bool canCost = false;
        bool canItems = false;

        string m_sno="";
        DataRow m_dr;
        DataTable m_dt;

        public SampleModify()
        {
            InitializeComponent();
            sampleUC1.init();
            titemsUC1.init();
            sampleUC1.costGroupBox.Enabled = false;
            sampleUC1.infoGroupBox.Enabled = false;
            sampleUC1.jyDatePicker.Enabled = false;
            sampleUC1.hyDatePicker.Enabled = false;
            sampleUC1.extraGroupBox.Enabled = false;
            sampleUC1.extraCheckBox.Enabled = false;
            titemsUC1.Enabled = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 特殊样品修改初始化
        /// </summary>
        /// <param name="sno"></param>
        public void initTSSno(string sno)
        {
            m_sno = sno;
            SnoLB.Text = sno;
            SstatusLB.Text = SampleControl.getStatus(sno);

            DataRow dr = DB.getDataRow(string.Format("select * from sampletable where sno='{0}'", sno));
            m_dr = dr;
            sampleUC1.fillControlsByDataRow(m_dr);

            sampleUC1.CnameTB.Text = DB.ExecuteScalar(string.Format("select Customername from sampletable,customer where sno='{0}' and sampletable.cno=customer.customerno", sno));


            DataTable dt = DB.getDataTable(string.Format("select * from resulttable where sno='{0}' order by [Tindex]", sno));
            m_dt = dt;
            titemsUC1.setDataGridView(m_dt);

            sampleUC1.infoGroupBox.Enabled = true;
            sampleUC1.extraGroupBox.Enabled = true;
            sampleUC1.extraCheckBox.Enabled = true;
            sampleUC1.extraCheckBox.Checked = true;
            canInfo = true;
            infolabel.ForeColor = Color.Green;


            sampleUC1.jyDatePicker.Enabled = true;
            canjy = true;
            jylabel.ForeColor = Color.Green;
   


            sampleUC1.hyDatePicker.Enabled = true;
            canhy = true;
            hylabel.ForeColor = Color.Green;


            sampleUC1.costGroupBox.Enabled = true;
            canCost = true;
            costlabel.ForeColor = Color.Green;


            titemsUC1.Enabled = true;
            canItems = true;
            Titemslabel.ForeColor = Color.Green;      

        }


        /// <summary>
        /// 根据需要修改的sno初始化
        /// </summary>
        /// <param name="sno"></param>
        public void initModifiedSno(string sno)
        {
            m_sno = sno;
            SnoLB.Text = sno;
            SstatusLB.Text = SampleControl.getStatus(sno);

            DataRow dr = DB.getDataRow(string.Format("select * from sampletable where sno='{0}'", sno));
            m_dr = dr;
            sampleUC1.fillControlsByDataRow(m_dr);

            sampleUC1.CnameTB.Text = DB.ExecuteScalar(string.Format("select Customername from sampletable,customer where sno='{0}' and sampletable.cno=customer.customerno", sno));


            DataTable dt = DB.getDataTable(string.Format("select * from resulttable where sno='{0}' order by [Tindex]", sno));
            m_dt = dt;
            titemsUC1.setDataGridView(m_dt);

            if (dr["Ssignintime"].ToString() == "/")  //没有签收时间的情况下，允许修改
            {
                sampleUC1.infoGroupBox.Enabled = true;
                sampleUC1.extraGroupBox.Enabled = true;
                sampleUC1.extraCheckBox.Enabled = true;
                sampleUC1.extraCheckBox.Checked = true;
                canInfo = true;
                infolabel.ForeColor = Color.Green;
                sampleUC1.jyDatePicker.Enabled = true;
                canjy = true;
                jylabel.ForeColor = Color.Green;
                sampleUC1.hyDatePicker.Enabled = true;
                canhy = true;
                hylabel.ForeColor = Color.Green;
                sampleUC1.costGroupBox.Enabled = true;
                canCost = true;
                costlabel.ForeColor = Color.Green;
                titemsUC1.Enabled = true;
                canItems = true;
                Titemslabel.ForeColor = Color.Green;
            }
            else
            {
                if (dr["CanBaseInformation"].ToString().Trim().ToLower() == "true")
                {
                    sampleUC1.infoGroupBox.Enabled = true;
                    sampleUC1.extraGroupBox.Enabled = true;
                    sampleUC1.extraCheckBox.Enabled = true;
                    sampleUC1.extraCheckBox.Checked = true;
                    canInfo = true;
                    infolabel.ForeColor = Color.Green;
                }
                if (dr["CanSintime"].ToString().Trim().ToLower() == "true")
                {
                    sampleUC1.jyDatePicker.Enabled = true;
                    canjy = true;
                    jylabel.ForeColor = Color.Green;
                }

                if (dr["CanScontracttime"].ToString().Trim().ToLower() == "true")
                {
                    sampleUC1.hyDatePicker.Enabled = true;
                    canhy = true;
                    hylabel.ForeColor = Color.Green;

                }
                if (dr["CanCost"].ToString().Trim().ToLower() == "true")
                {
                    sampleUC1.costGroupBox.Enabled = true;
                    canCost = true;
                    costlabel.ForeColor = Color.Green;
                }
                if (dr["CanItems"].ToString().Trim().ToLower() == "true")
                {
                    titemsUC1.Enabled = true;
                    canItems = true;
                    Titemslabel.ForeColor = Color.Green;
                }         
            }



        }

        /// <summary>
        /// 提交修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            if (sampleUC1.fillDataRowByControls(m_dr, canInfo, canjy, canhy, canCost) == 0 && !canItems)
            {
                MessageBox.Show("样品无可修改信息！");
                return;
            }

            string msgstr = "如果本样品已签收，则只能修改一次，确定提交？";
            if (MessageBox.Show(msgstr, "提醒", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (SampleControl.updateSampleInfo(m_dr)>0)
            {
                MessageBox.Show("样品信息更新成功！");
            }

            //新添 对原样表的修改，先删除，后修改
            string deleteSample = string.Format("delete from SampleSerialNO where sno='{0}'", m_dr["Sno"].ToString());
            DB.ExecuteNonQuery(deleteSample);
            SampleControl.addSampleNO(m_dr["Sno"].ToString(), m_dr["SoriginalNo"].ToString());
            if (canItems)    //如果修改了物品样品，则重新设置成未校对状态
            {
                DataTable dt = titemsUC1.getDataTable();
                if (!Libs.checkDT(dt))
                {
                    MessageBox.Show("样品检测数据不全！请填写完整后重新更新！");
                    return;
                }

                List<string> moreItems = new List<string>();

                foreach (DataRow tmpdr in dt.Rows)
                {
                    if (DB.ExecuteScalar(string.Format("select titem from itemtable where titem='{0}'", tmpdr["Titem"])) == "")
                    {
                        //找不到样品则添加
                        moreItems.Add(tmpdr["Titem"].ToString());
                    }
                }
                if (moreItems.Count > 0)//如果存在新增样品
                {
                    MessageBox.Show("存在尚未添加图片的新检测项目！请添加！");
                    Items.ItemAdd f = new Items.ItemAdd();
                    f.init(moreItems);
                    f.ShowDialog();
                }

                if (SampleControl.updateSampleItems(m_sno, dt) > 0)
                {

                    MessageBox.Show("检测项目更新成功！样品将被重新设置成未校对状态");
                }

                SampleControl.ClearSample(m_sno);   //清理样品时间和人名标识
            }

            SampleControl.SetCan(m_sno, "false");   //更新成功后，批量修改can

            string logstr = string.Format("基本{0},进样时间{1},合约时间{2},价格{3},检测项目{4}", canInfo, canjy, canhy, canCost, canItems);
            Log.AddLog(m_sno, "样品修改", logstr);
            this.Dispose();

        }
    }
}
