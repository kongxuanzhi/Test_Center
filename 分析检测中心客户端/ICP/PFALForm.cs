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
    public partial class PFALForm : Form
    {

        Dictionary<string, XT> XTDic;
        List<string> YSList;

        public void LoadXT(Dictionary<string, XT> dic)
        {
            this.XTDic = dic;
            showXT();
        }

        public PFALForm()
        {
            InitializeComponent();
            XTDic = new Dictionary<string, XT>();
            YSList = new List<string>();
            XTGridView1.RowHeadersWidth = 70;
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

        void JXPF(string path)//解析配分
        {
            YSList.Clear();

            ExcelBase excel = new ExcelBase();
            excel.open(path);

            ICell slpos = excel.FindCellS("Solution Label", 10, 0);	//找元素起始标签行！！！！！！！

            if (slpos == null)
            {
                MessageBox.Show("读取数据失败！");
                excel.close();
                return;
            }

            int tmp_x=slpos.RowIndex+1;   //起始X
            int tmp_y = slpos.ColumnIndex + 1;  //起始Y

            ICPOperation.fillYSList(YSList, slpos.Row, 1);  //获取元素列表


            int readline = tmp_x;   //从这里开始往下读

            while (excel.getCellStr(readline, slpos.ColumnIndex) != "")  //第一条样品记录（XT()....）
            {
                IRow row = excel.sheet.GetRow(readline);
                string id = row.GetCell(slpos.ColumnIndex).StringCellValue.Trim();//获取ID

                if (id.StartsWith("标准"))   //如果是以标准开头，直接跳过
                {
                    readline++;
                    continue;
                }

                XT tmpxt;
                if (XTDic.ContainsKey(id))  //如果该稀土存在
                {
                    tmpxt = XTDic[id];    //直接指向
                }
                else
                {
                    tmpxt = new XT(id);   //写入ID
                    XTDic[id] = tmpxt;
                }

                tmpxt.fromFiles.Add(path);   //将改路径写入！
                ICPOperation.fillXTYSData(tmpxt, YSList, row, 1);  //获取原始数据
                tmpxt.calPF();//计算配分
                readline++;

            }

            showXT();
            excel.close();
        }

        private void button2_Click(object sender, EventArgs e)  //解析配分按钮
        {
            string[] strs = pathBox.Text.Split(';');
            foreach (string str in strs)
            {
                if (str != "")
                {
                    JXPF(str);
                }

            }
            pathBox.Text = "";

        }

        private void XTListBox_SelectedIndexChanged(object sender, EventArgs e) //显示XT数据
        {
            string xtid = XTListBox.SelectedItem.ToString();
            XT xt = XTDic[xtid];
            showXTinfo(xt);

        }

        void showXTinfo(XT xt)  //显示XT数据
        {

            bool is_o = true;
            idBox.Text = xt.id;
            nameBox.Text = xt.name;
            customBox.Text = xt.customnum;
            if (xt.flags[XT.IS_O] == 1)
            {
                is_o = true;
                ISOBox.Text = "氧化物";
            }
            else
            {
                is_o = false;
                ISOBox.Text = "单质";
            }
            OFZLBox.Text = string.Format("{0:F2}", xt.opjfzl);
            NOFZLBox.Text = string.Format("{0:F2}", xt.pjfzl);
            fzlRateBox.Text = string.Format("{0:F2}", xt.fzlrate);
            fileFromBox.Text = string.Format("{0}", xt.fromFiles[0]);


            List<YS> tmpys = new List<YS>();    //合并稀土和非稀土元素
            tmpys.AddRange(xt.xtyslist);
            tmpys.AddRange(xt.qtyslist);
            SetYSGridRow(tmpys, xt.flags[XT.IS_O] == 1);
            if (is_o)
            {
                for (int i = 0; i < tmpys.Count; i++)
                {
                    XTGridView1["result", i].Value = tmpys[i].limitval;
                    XTGridView1["avg", i].Value = tmpys[i].oavgval;
                    XTGridView1["maxdiff", i].Value = tmpys[i].omaxdiffer;

                    for (int j = 0; j < tmpys[i].oval.Length; j++)
                    {
                        XTGridView1["val" + (j + 1), i].Value = tmpys[i].oval[j];
                    }
                }
                for (int i = 0; i < tmpys.Count; i++)
                {
                    XTGridView1["result", i].Value = tmpys[i].limitval;
                    XTGridView1["avg", i].Value = tmpys[i].oavgval;
                    XTGridView1["maxdiff", i].Value = tmpys[i].omaxdiffer;

                    for (int j = 0; j < tmpys[i].oval.Length; j++)
                    {
                        XTGridView1["val" + (j + 1), i].Value = tmpys[i].oval[j];
                    }
                }
            }
            else
            {
                for (int i = 0; i < tmpys.Count; i++)
                {
                    XTGridView1["result", i].Value = tmpys[i].limitval;
                    XTGridView1["avg", i].Value = tmpys[i].avgval;
                    XTGridView1["maxdiff", i].Value = tmpys[i].maxdiffer;

                    for (int j = 0; j < tmpys[i].val.Length; j++)
                    {
                        XTGridView1["val" + (j + 1), i].Value = tmpys[i].val[j];
                    }
                }
                for (int i = 0; i < xt.qtyslist.Count; i++)
                {
                    XTGridView1["result", i].Value = tmpys[i].limitval;
                    XTGridView1["avg", i].Value = tmpys[i].avgval;
                    XTGridView1["maxdiff", i].Value = tmpys[i].maxdiffer;

                    for (int j = 0; j < tmpys[i].val.Length; j++)
                    {
                        XTGridView1["val" + (j + 1), i].Value = tmpys[i].val[j];
                    }
                }
            }
        }


        void SetYSGridRow(List<string> strlist, bool is_o)    //显示gridrow
        {
            XTGridView1.Rows.Clear();
            if (is_o)
            {
                for (int i = 0; i < strlist.Count; i++)
                {
                    DataGridViewRow r = new DataGridViewRow();
                    r.HeaderCell.Value = Lualib.getYSProp(strlist[i], "RPTOName");
                    XTGridView1.Rows.Add(r);
                }
            }
            else
            {
                for (int i = 0; i < strlist.Count; i++)
                {
                    DataGridViewRow r = new DataGridViewRow();
                    r.HeaderCell.Value = strlist[i];
                    XTGridView1.Rows.Add(r);
                }
            }
        }

        void SetYSGridRow(List<YS> yslist, bool is_o)   //gridrow元素列表
        {
            XTGridView1.Rows.Clear();
            if (is_o)
            {
                for (int i = 0; i < yslist.Count; i++)
                {
                    DataGridViewRow r = new DataGridViewRow();
                    r.HeaderCell.Value = Lualib.getYSProp(yslist[i].name, "RPTOName");
                    XTGridView1.Rows.Add(r);
                }
            }
            else
            {
                for (int i = 0; i < yslist.Count; i++)
                {
                    DataGridViewRow r = new DataGridViewRow();
                    r.HeaderCell.Value = yslist[i].name;
                    XTGridView1.Rows.Add(r);
                }
            }
        }


        private void ToOBtn_Click(object sender, EventArgs e)   //转成氧化物
        {
            if (!_checkSelectItem())
            {
                return;
            }

            foreach (string xtname in XTListBox.SelectedItems)
            {
                XTDic[xtname].flags[XT.IS_O] = 1;
            }
            button4_Click(null, null);
            showXTinfo(XTDic[XTListBox.SelectedItems[0].ToString()]);
        }

        private void ToNOBtn_Click(object sender, EventArgs e)  //转成单质
        {
            if (!_checkSelectItem())
            {
                return;
            }

            foreach (string xtname in XTListBox.SelectedItems)
            {
                XTDic[xtname].flags[XT.IS_O] = 0;
            }
            button4_Click(null, null);
            showXTinfo(XTDic[XTListBox.SelectedItems[0].ToString()]);
        }

        private void button4_Click(object sender, EventArgs e)  //修正
        {

            if (!_checkSelectItem())
            {
                return;
            }

            double downline = Convert.ToDouble(downBox.Text);
            int downrate = Convert.ToInt16(downRateBox.Text);

            double aldownline = Convert.ToDouble(aldownBox.Text);
            int aldownrate = Convert.ToInt16(alRateBox.Text);


            foreach (string xtname in XTListBox.SelectedItems)
            {
                XT tmpxt = XTDic[xtname];

                foreach (YS tmpys in tmpxt.xtyslist)
                {
                    tmpys.calLimit(downline, downrate, tmpxt.flags[XT.IS_O]==1);
                }

                foreach (YS tmpys in tmpxt.qtyslist)
                {
                    tmpys.calLimit(aldownline, aldownrate, tmpxt.flags[XT.IS_O] == 1);
                }



            }
            showXTinfo(XTDic[XTListBox.SelectedItems[0].ToString()]);
        }

        /// <summary>
        /// 解析AL等带空白非稀土元素
        /// </summary>
        /// <param name="path"></param>
        void JXQTYS(string path)
        {

            YSList.Clear();

            ExcelBase excel = new ExcelBase();
            if (!excel.open(path))
            {
                MessageBox.Show("EXCEL无法启动！");
                return;
            }

            ICell slpos = excel.FindCellS("Solution Label", 10, 0);	//找元素起始标签行！！！！！！！

            if (slpos == null)
            {
                MessageBox.Show("读取数据失败！");
                excel.close();
                return;
            }

            ICell blankcell = excel.FindCellEx("空白", slpos.RowIndex + 1, slpos.RowIndex + 8, slpos.ColumnIndex, slpos.ColumnIndex);//根据标签查找空白数据  
            if (blankcell == null)
            {
                MessageBox.Show("未找到空白数据！");
                excel.close();
                return;
            }

            ICPOperation.fillYSList(YSList, slpos.Row, 1);  //遍历元素

            double[] blankdata=new double[YSList.Count];    //创建空白数据集
            IRow blankRow = blankcell.Row;  //空白行

            int readColumn = blankcell.ColumnIndex+1;  //起始
            for (int i = 0; i < YSList.Count; i++)
            {
                double blanktmp = excel.getCellDouble(blankcell.RowIndex, readColumn);
                if (blanktmp < 0)
                {
                    blanktmp = 0;
                }
                blankdata[i] = blanktmp;
                readColumn++;
            }


            int readline = blankcell.RowIndex+1;	//空白数据下面开始遍历样品数据

            while (excel.getCellStr(readline, slpos.ColumnIndex) != "")	//遍历样品数据
            {
                IRow row = excel.sheet.GetRow(readline);
                string tmpid = row.GetCell(slpos.ColumnIndex).StringCellValue.Trim();//获取XTID
                if (tmpid.StartsWith("标准"))   //如果是标准，直接跳过
                {
                    continue;
                }

                XT tmpxt = null;

                if (XTDic.ContainsKey(tmpid))	//如果已存在
                {
                    tmpxt = XTDic[tmpid];
                }
                else    //不存在则创建
                {
                    tmpxt = new XT(tmpid);
                    XTDic[tmpid] = tmpxt;
                }

                tmpxt.fromFiles.Add(path);  //将路径加入


                ICPOperation.fillQTYSData(tmpxt, YSList, row,blankdata,1);  //写入一行的空白和数据
                readline++;
                tmpxt.calQTYS();  //计算结果

            }

            showXT();
            excel.close();
        }

        private void button3_Click(object sender, EventArgs e)          //批量解析AL
        {
            string[] strs = pathBox.Text.Split(';');
            foreach (string str in strs)
            {
                if (str != "")
                {
                    JXQTYS(str);
                }
            }
            pathBox.Text = "";
        }



        private void SaveBtn_Click(object sender, EventArgs e)  //全局保存
        {
            ICPOperation.saveToTotal(XTDic, true);
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

        private void saveFileBtn_Click(object sender, EventArgs e)  //保存文件
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.icp|*.icp|所有文件|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Libs.Serialize(XTDic, sfd.FileName);
                MessageBox.Show("保存文件成功！");
            }

        }

        private void loadFileBtn_Click(object sender, EventArgs e)  //读取文件
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.icp|*.icp|所有文件|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Dictionary<string, XT> tmpdic = (Dictionary<string, XT>)Libs.Deserialize(ofd.FileName);
                XTDic = tmpdic;
                showXT();
            }

        }

        private void rptBtn_Click(object sender, EventArgs e)   //导出报告
        {

            if (!_checkSelectItem())
            {
                return;
            }

            List<XT> xtlist = new List<XT>();
            foreach (string xtid in XTListBox.SelectedItems)
            {
                xtlist.Add(XTDic[xtid]);
            }


            string filename;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "*.xls|*.xls|所有文件|*.*";

            if (xtlist.Count == 1)
            {
                filename = string.Format("{0}.xls", xtlist[0].id);
            }
            else if(xtlist.Count==2)
            {
                filename = string.Format("{0},{1}.xls", xtlist[0].id,xtlist[1].id);
            }
            else
            {
                filename = string.Format("{0}-{1}.xls", xtlist[0].id, xtlist[xtlist.Count - 1].id);
            }
            sfd.FileName = filename;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ICPOperation.WriteRPT(xtlist, sfd.FileName);
                MessageBox.Show("报告已成功导出！");
            }


        }

        private void PFALForm_Load(object sender, EventArgs e)
        {

        }

        private void getInfoBox_Click(object sender, EventArgs e)   //获取样品信息
        {
            if (!_checkSelectItem())
            {
                return;
            }

            foreach (string xtid in XTListBox.SelectedItems)
            {
                try
                {
                    string sql = string.Format("select * from Sampletable where Sno='{0}'", xtid);
                    DataRow dr = DB.getDataRow(sql);
                    XT xt = XTDic[xtid]; //获取选中的xt
                    xt.name = dr["Sname"].ToString();
                    xt.customnum = dr["Cno"].ToString();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("获取信息失败！"+ex.Message);
                }

            }

            showXTinfo(XTDic[XTListBox.SelectedItems[0].ToString()]);
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
            List<XT> xtlist = new List<XT>();
            foreach (string xtid in XTListBox.SelectedItems)
            {
                xtlist.Add(XTDic[xtid]);
            }
            ICPOperation.WriteDB(xtlist);

        }

        private void PFALForm_FormClosing(object sender, FormClosingEventArgs e)    //退出自动保存
        {

        }


        /// <summary>
        /// 智能分类导出报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void smartRptBtn_Click(object sender, EventArgs e)
        {

            if (!_checkSelectItem())
            {
                return;
            }

            string path = null; //路径
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            else
            {
                return;
            }

            TextForm tf = new TextForm();
            tf.Show();

            string lastCno = "";    //记录上一个CNO
            string filename = "";
            List<XT> xtlist = new List<XT>();

            foreach (string xtid in XTListBox.SelectedItems)   //遍历XT
            {
                XT xt=XTDic[xtid];
                if (xt.customnum == "")
                {
                    MessageBox.Show("请先获取样品信息再使用智能导出！");
                    return;
                }

                if(lastCno=="") //如果是第一个样，则直接添加
                {
                    xtlist.Add(xt);
                    lastCno=xt.customnum;
                }
                else if (xt.customnum == lastCno && xtlist.Count <= 6)    //如果是同一家且没满6个，则直接添加
                {
                    xtlist.Add(xt);  //添加进入
                }
                else //如果不是同一个样，或者是同一个样但是满了6个，则直接输出重来
                {
                    //进行命名操作
                    if (xtlist.Count == 1)
                    {
                        filename = string.Format("{0}\\{1}.xls", path, xtlist[0].id);
                    }
                    else if (xtlist.Count == 2)
                    {
                        filename = string.Format("{0}\\{1},{2}.xls", path, xtlist[0].id, xtlist[1].id);
                    }
                    else
                    {
                        filename = string.Format("{0}\\{1}-{2}.xls", path, xtlist[0].id, xtlist[xtlist.Count - 1].id);
                    }
                    if (ICPOperation.WriteRPT(xtlist, filename))
                    {
                        tf.appendText(filename + "  成功！");
                    }
                    else{
                        tf.appendText(filename + "  失败！");
                    }//导出报告

                    xtlist.Clear();  //清空
                    xtlist.Add(xt);
                    lastCno = xt.customnum;
                }
            }

            if (xtlist.Count > 0)   //将剩余的样品输出
            {
                //进行命名操作
                if (xtlist.Count == 1)
                {
                    filename = string.Format("{0}\\{1}.xls", path, xtlist[0].id);
                }
                else if (xtlist.Count == 2)
                {
                    filename = string.Format("{0}\\{1},{2}.xls", path, xtlist[0].id, xtlist[1].id);
                }
                else
                {
                    filename = string.Format("{0}\\{1}-{2}.xls", path, xtlist[0].id, xtlist[xtlist.Count - 1].id);
                }
                if (ICPOperation.WriteRPT(xtlist, filename))
                {
                    tf.appendText(filename + "  成功！");
                }
                else
                {
                    tf.appendText(filename + "  失败！");
                }//导出报告
                xtlist.Clear();  //清空
            }
            tf.appendText("导出完成！");

        }

        /// <summary>
        /// 元素修正
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            string xtid = XTListBox.SelectedItem.ToString();
            XT xt = XTDic[xtid];    //获取当前选中XT
            double aldownline = Convert.ToDouble(aldownBox.Text);
            int aldownrate = Convert.ToInt16(alRateBox.Text);

            for (int i = 0; i < XTGridView1.Rows.Count;i++ )
            {
                if (XTGridView1.Rows[i].Selected)   //如果被选中则写入列表
                {
                    if (i < xt.xtyslist.Count)
                    {
                        xt.xtyslist[i].calLimit(aldownline, aldownrate, xt.flags[XT.IS_O] == 1);
                    }
                    else
                    {
                        xt.qtyslist[i-xt.xtyslist.Count].calLimit(aldownline, aldownrate, xt.flags[XT.IS_O] == 1);
                    }
                }
            }
            showXTinfo(xt);
        }

        /// <summary>
        /// 手工修正确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            string xtid = XTListBox.SelectedItem.ToString();
            XT xt = XTDic[xtid];    //获取当前选中XT
            for (int i = 0; i < XTGridView1.Rows.Count; i++)
            {
                if (i < xt.xtyslist.Count)
                {
                    xt.xtyslist[i].limitval = XTGridView1.Rows[i].Cells[0].Value.ToString();
                }
                else
                {
                    xt.qtyslist[i - xt.xtyslist.Count].limitval = XTGridView1.Rows[i].Cells[0].Value.ToString();
                } 
            }
            MessageBox.Show("手工修正成功！");
            showXTinfo(xt);
        }
    }
}
