using Code;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TRESystem2011.Sample
{
    public partial class MissionReport : Form
    {
        private string sno;

        public MissionReport()
        {
            InitializeComponent();
        }
        public MissionReport(string sno)
        {
            this.sno = sno;
            InitializeComponent();
        }
        private void MissionReport_Load(object sender, EventArgs e)
        {
            
            bindDataAndShow();
            //
        }
        public void bindDataAndShow()
        {
            MidDBReport ds = new MidDBReport();
            DataRow dr = ds.MittionReport.NewRow();
            string sql = "select Sno,Cno,Sname,Sstate,Squantity,Sintime,chargestd,WhoTake,customerNo,customername,relation,tel, Convert(int, Costtotal)+Convert(int,Costexpress)+Convert(int,CostSpreparation) as totalMoney,Ssignintime from Sampletable S,Customer C where S.Cno = C.customerNo and Sno = '" + sno+"'";
            DataTable tempdr = DB.getDataTable(sql);
            for (int i = 0; i < tempdr.Columns.Count; i++)
            {
                string colName = tempdr.Columns[i].ColumnName;
                dr[colName] = tempdr.Rows[0][colName];
            }
            #region 试样编号
            List<object> SampleNOs = DB.getList("select SampleNO from SampleSerialNO where Sno = '" + sno + "'");
            string SampleNO = "";
            for (int i = 0; i < SampleNOs.Count; i++)
            {
                SampleNO += SampleNOs[i].ToString();
                if (i != SampleNOs.Count - 1)
                {
                    SampleNO += ",";
                }
            }
            dr["SampleNOs"] = SampleNO;
            #endregion
            #region 检测项目字符串用逗号隔开
            List<object> Titem = DB.getList("select Titem from Resulttable where Sno = '"+sno+"'");
            string Titems = "";
            for (int i = 0; i < Titem.Count; i++)
            {
                Titems += Titem[i].ToString();
                if(i != Titem.Count - 1)
                {
                    Titems += ",";
                }
            }
            dr["Titem"] = Titems;
            #endregion
            ds.MittionReport.Rows.Add(dr);
            DB.fillDataSet(ds, "SampleSerialNO", "SELECT Id,SoriginalNo, SampleNO,sno FROM SampleSerialNO where sno='" + sno + "' ");
            //将数据填充到dt，
            //将dt绑定到view
            ReportFactory rf = new ReportFactory();
            rf.PrintMission(crystalReport_Mission,sno,ds);
        }
    }
}
