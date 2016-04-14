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
    public partial class PureForm : Form
    {

        Dictionary<string, XT> XTDic;
        List<string> YSList;

        public void LoadXT(Dictionary<string, XT> dic)
        {
            this.XTDic = dic;
            showXT();
        }

        public PureForm()
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

        void JXPURE(string path)//解析纯度
        {
            YSList.Clear();

            ExcelBase excel = new ExcelBase();
            excel.open(path);

            ICell slpos = excel.FindCellS("Solution Label", 10, 0);	//找元素行
            if (slpos == null)
            {
                MessageBox.Show("读取数据失败！");
                excel.close();
                return;
            }

            ICPOperation.fillYSList(YSList, slpos.Row, 1);  //读取元素列表


            int readline = slpos.RowIndex+1;   //从这里开始往下读


            while (excel.getCellStr(readline, slpos.ColumnIndex) != "")  //不为空则一直读下去
            {
                IRow row=excel.sheet.GetRow(readline);  
                string id = row.GetCell(slpos.ColumnIndex).StringCellValue.Trim();//获取ID

                if (id.StartsWith("标准"))   //如果是标准，直接跳过
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

                ICPOperation.fillXTYSData(tmpxt, YSList, row, 1);   //读取数据
                tmpxt.calPURE();    //计算纯度
                readline++;
                

            }

            showXT();
            excel.close();
        }

        private void button2_Click(object sender, EventArgs e)  //解析纯度按钮
        {
            string[] strs = pathBox.Text.Split(';');
            foreach (string str in strs)
            {
                if (str != "")
                {
                    JXPURE(str);
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
            PureYsBox.Text = xt.xtyslist[xt.flags[XT.PURE_INDEX]].name; //最纯元素
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
            double upline = Convert.ToDouble(upBox.Text);
            int uprate = Convert.ToInt16(upRateBox.Text);

            string normalDownFormatStr = "{0:F" + downrate + "}";
            string downFormatStr = "<{0:F" + downrate + "}";
            string upFormatStr = ">{0:F" + uprate + "}";

            foreach (string xtname in XTListBox.SelectedItems)
            {
                XT tmpxt = XTDic[xtname];

                double tmpPure = 100;

                if (tmpxt.flags[XT.IS_O] == 1)
                {
                    foreach (YS tmpys in tmpxt.xtyslist)
                    {
                        if (tmpys != tmpxt.xtyslist[tmpxt.flags[XT.PURE_INDEX]]) //如果不是最纯的那个元素的话
                        {
                            if (tmpys.oavgval < downline)
                            {
                                tmpys.limitval = string.Format(downFormatStr, downline);    //小于数值
                                tmpPure -= downline;
                            }
                            else
                            {
                                tmpys.limitval = string.Format(normalDownFormatStr, tmpys.oavgval); //实际数值
                                tmpPure -= tmpys.oavgval;
                            }
                        }
                    }

                }
                else
                {
                    foreach (YS tmpys in tmpxt.xtyslist)
                    {
                        if (tmpys != tmpxt.xtyslist[tmpxt.flags[XT.PURE_INDEX]]) //如果不是最纯的那个元素的话
                        {
                            if (tmpys.avgval < downline)
                            {
                                tmpys.limitval = string.Format(downFormatStr, downline);
                                tmpPure -= downline;
                            }
                            else
                            {
                                tmpys.limitval = string.Format(normalDownFormatStr, tmpys.avgval);
                                tmpPure -= tmpys.avgval;
                            }
                        }
                    }
                }
                tmpxt.xtyslist[tmpxt.flags[XT.PURE_INDEX]].limitval = string.Format(upFormatStr, tmpPure);   //最纯元素
            }
            
            showXTinfo(XTDic[XTListBox.SelectedItems[0].ToString()]);
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
                string sql = string.Format("select * from Sampletable where Sno='{0}'", xtid);
                DataRow dr = DB.getDataRow(sql);
                XT xt = XTDic[xtid]; //获取选中的xt
                xt.name = dr["Sname"].ToString();
                xt.customnum = dr["Cno"].ToString();
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
        private void smartRPTBtn_Click(object sender, EventArgs e)
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
                XT xt = XTDic[xtid];
                if (xt.customnum == "")
                {
                    MessageBox.Show("请先获取样品信息再使用智能导出！");
                    return;
                }

                if (lastCno == "") //如果是第一个样，则直接添加
                {
                    xtlist.Add(xt);
                    lastCno = xt.customnum;
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
                    else
                    {
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
    }
}
