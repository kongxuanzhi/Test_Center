using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;
using System.IO;

namespace TRESystem2011.Sample
{
    public partial class SampleMuiltyAdd : Form
    {
        public SampleMuiltyAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "EXCEL模板(*.xls)|*.xls"; 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename = ofd.FileName;
                try
                {
                    samplesDGV.DataSource = ExcelLib.getDataTableFromXLS(filename);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("导入数据失败！"+MessageBox.Show(ex.Message));
                }
            }


        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("确定数据准确无误？", "提醒", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            if (!Libs.checkControls(panel1))
            {
                MessageBox.Show("通用数据不全！");
                return;
            }

            if (samplesDGV.Rows.Count <=1)//第一行因为是注释表头，所以不能算
            {
                MessageBox.Show("没有样品数据！");
                return;
            }

            DataTable dt = titemsUC1.getDataTable();
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("检测项目数据不全！");
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
                return;
            }

            //以上是准备工作！

            DataTable samplesDT = DB.getEmptyTableByTableName("Sampletable");

            for (int i = 1; i < samplesDGV.Rows.Count; i++)
            {
                if (samplesDGV.Rows[i].Cells[0].Value == null)
                {
                    break;
                }

                DataRow dr = samplesDT.NewRow();
                Libs.initDataRow(dr,"/");   //初始化
                dr["Sintime"] = jyDatePicker.Value.ToString("yyyy-MM-dd HH:mm:ss");
                dr["Scontracttime"] = hyDatePicker.Value.ToString("yyyy-MM-dd");
                Libs.fillDataRow(dr, panel1);   //填充基本信息
                fillDataRowByDataGridviewRow(dr, i);    //填充样品单独信息

                if (!checkRow(dr))
                {
                    MessageBox.Show("有样品数据有误！添加中止！");
                    return;
                }
                samplesDT.Rows.Add(dr);
            }
            List<string> snos=SampleControl.addNewSamples(samplesDT, dt);
            if (snos.Count == 0)
            {
                MessageBox.Show("无样品被添加！");
            }
            else
            {
                string msg = "成功添加：";
                foreach (string sno in snos)
                {
                    msg += sno + " ";
                }
                MessageBox.Show(msg);
                samplesDGV.DataSource = null;   //解除绑定

                if (User.TSMODE)   //如果是特殊服务器则直接校对签收完毕
                {
                    foreach (string newsno in snos)
                    {
                        SampleControl.sproof(newsno);
                        SampleControl.signin(newsno);
                    }

                }


            }

            initTime();

           
        }

        /// <summary>
        /// 检查样品信息是否填写完整，修复部分默认数据
        /// </summary>
        /// <param name="dr"></param>
        bool checkRow(DataRow dr)
        {
            try
            {
                if (dr["Sname"].ToString() == "/") return false;
                if (dr["Skind"].ToString() == "/") return false;

                if (DB.ExecuteScalar("select ID from SampleKinds where ID='" + dr["Skind"] + "'") == "")//如果样品分类不存在
                {
                    MessageBox.Show("样品分类" + dr["Skind"] + "不存在！");
                    return false;
                }
                    

                if (dr["SoriginalNo"].ToString() == "/") return false;
                if (dr["Squantity"].ToString() == "/") return false;
                if (dr["Costtotal"].ToString() == "/") return false;
                if (dr["Costexpress"].ToString() == "/") dr["Costexpress"]="0";
                if (dr["CostSpreparation"].ToString() == "/") dr["CostSpreparation"] = "0";
                if (dr["Costnopay"].ToString() == "/") dr["Costnopay"]="0";
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 将第i行填充到dr中
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="i"></param>
        private void fillDataRowByDataGridviewRow(DataRow dr, int i)
        {
            foreach (DataGridViewColumn dgvc in samplesDGV.Columns)
            {
                string ColumnName = dgvc.DataPropertyName;
                if(dr.Table.Columns.Contains(ColumnName)) //如果有所在的列且不为空，则写入
                {
                    try
                    {
                        if (samplesDGV.Rows[i].Cells[ColumnName].Value.ToString() != "")
                        {
                            dr[dr.Table.Columns.IndexOf(ColumnName)] = samplesDGV.Rows[i].Cells[ColumnName].Value;
                            //此处如果遇到空行 会自动退出
                        }
                    }
                    catch (System.Exception)
                    {
                        return;
                    }


                }
            }
        }

        
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SampleMuiltyAdd_Load(object sender, EventArgs e)
        {
            titemsUC1.init();
            ScanretestCB.SelectedIndex = 0;
            RgivemodeCB.SelectedIndex = 0;
            ShandleCB.SelectedIndex = 0;
            CostmodeCB.SelectedIndex = 0;

            initTime();
        }

        /// <summary>
        /// 刷新当前时间
        /// </summary>
        private void initTime()
        {
            jyDatePicker.Value = Libs.getServerDate();
            jyDatePicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
        }

        /// <summary>
        /// 选择客户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Customer.CustomerForm f = new Customer.CustomerForm();
            f.c1 = CnoTB;
            f.c2 = CnameTB;
            f.setSelectMode(true);
            f.ShowDialog();
        }

        /// <summary>
        /// 手工填写 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                samplesDGV.DataSource = ExcelLib.getDataTableFromXLS(Application.StartupPath+@"\template\Sample.xls");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 获取模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string f1 = Application.StartupPath+@"\template\Sample.xls";
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "模板.xls";
                sfd.Filter = "EXCEL模板(*.xls)|*.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    string f2 = sfd.FileName;
                    File.Copy(f1, f2, true);
                    MessageBox.Show("导出成功！位置保存在：" + f2);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);	
            }

        }
    }
}
