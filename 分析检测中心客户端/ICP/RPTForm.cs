using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NPOI.SS.UserModel;
using Code;

namespace ICPTOOLS_DONET
{
    public partial class RPTForm : Form
    {

        Dictionary<string, RPTXT> XTDic;
        List<string> YSList;


        public RPTForm()
        {
            InitializeComponent();
            YSList = new List<string>();
            XTDic = new Dictionary<string, RPTXT>();
        }

        void showXT()
        {
            XTListBox.Items.Clear();
            foreach (string name in XTDic.Keys)
            {
                XTListBox.Items.Add(name);
            }
        }

        private void button1_Click(object sender, EventArgs e)  //选择文件
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true; //允许多选
            ofd.Filter = "(*.xls)|*.xls|所有文件|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string str in ofd.FileNames)
                {
                    pathBox.Text += str + ";";
                }
            }
            //pathBox.Text = pathBox.Text.Substring(0, pathBox.Text.Length-1);    //去掉末尾的;
        }

        void JXRPT(string path)//解析报告
        {
            YSList.Clear();

            ExcelBase excel = new ExcelBase();
            excel.open(path);

            ICell slpos = excel.FindCellS("样品编号", 35, 0);	//找元素行
            if (slpos == null)
            {
                MessageBox.Show("读取数据失败！");
                excel.close();
                return;
            }

            ICell firstYsCell = null ;
            IRow YSRow=slpos.Row;

            for (int i = 1; i < YSRow.LastCellNum;i++ ) //找到第一个元素位置
            {
                if (YSRow.GetCell(i).StringCellValue.Trim() != "")
                {
                    firstYsCell = YSRow.GetCell(i);
                    break;
                }
            }

            if (firstYsCell == null)
            {
                MessageBox.Show("找不到元素数据！");
                excel.close();
                return;
            }

            //遍历元素
            for (int i = firstYsCell.ColumnIndex; i < YSRow.LastCellNum; i++)
            {
                if (YSRow.GetCell(i).StringCellValue.Trim() != "")
                {
                    YSList.Add(YSRow.GetCell(i).StringCellValue);
                }
            }

            int readline=slpos.RowIndex+1;
            int startColumn = firstYsCell.ColumnIndex;
            while (excel.getCellStr(readline,0)!="")    //不为空
            {
                IRow readRow=excel.sheet.GetRow(readline);  //开始读的行
                int readColumn=startColumn; //开始读的位置
                string id = readRow.GetCell(0).StringCellValue;
                RPTXT xt = new RPTXT(id);
                XTDic.Add(id, xt);

                for (int i = 0; i < YSList.Count;i++ )  //遍历将元素和结果写入
                {
                    xt.YSDic.Add(YSList[i], readRow.GetCell(readColumn).ToString());
                    readColumn++;
                }
                readline++;
            }

            showXT();
            excel.close();
        }

        private void button2_Click(object sender, EventArgs e)  //解析报告按钮
        {
            string[] strs = pathBox.Text.Split(';');
            foreach (string str in strs)
            {
                if (str != "")
                {
                    JXRPT(str);
                }

            }
            pathBox.Text = "";

        }

        private void XTListBox_SelectedIndexChanged(object sender, EventArgs e) //显示XT数据
        {
            try
            {
                string xtid = XTListBox.SelectedItem.ToString();
                RPTXT xt = XTDic[xtid];
                showXTinfo(xt);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        void showXTinfo(RPTXT xt)  //显示XT数据
        {
            //int i = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("元素");
            dt.Columns.Add("值");
            foreach(string ys in xt.YSDic.Keys)
            {
                DataRow dr = dt.NewRow();
                dr["元素"] = ys;
                dr["值"] = xt.YSDic[ys];
                dt.Rows.Add(dr);
            }

            dataGridView1.DataSource = dt;
 
        }


    
        private void clearPathBtn_Click(object sender, EventArgs e)
        {
            pathBox.Text = "";
        }

        private void XTListBox_KeyDown(object sender, KeyEventArgs e)   //del键删除
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = XTListBox.SelectedItems.Count - 1; i > -1; i--)
                {
                    XTDic.Remove(XTListBox.SelectedItems[i].ToString());
                }
                showXT();
            }

        }

 
   

        private bool _checkSelectItem() //检查是否有稀土被选中
        {
            if (XTListBox.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请先选中样品！");
                return false;
            }
            return true;
        }

        private void dbbtn_Click(object sender, EventArgs e)    //写入数据库
        {
            if (!_checkSelectItem())
            {
                return;
            }
            List<RPTXT> xtlist = new List<RPTXT>();
            foreach (string xtid in XTListBox.SelectedItems)
            {
                xtlist.Add(XTDic[xtid]);
            }
            ICPOperation.WriteRPTToDB(xtlist,SmartCB.Checked);
        }

        private void RPTForm_Load(object sender, EventArgs e)
        {
            SmartCB.Checked=true;
        }


    }
}
