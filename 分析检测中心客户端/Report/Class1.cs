
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Web;
using System.Data.OleDb;
using TRESystem2011;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) { ConfigureCrystalReports(); }
    private void ConfigureCrystalReports()
    {                 
        //连接字串         
        String connstr = @"Provider=Microsoft.Jet.OLEDB.4.0;Dat a Source=E:\CrZen\testall.mdb;";
        OleDbDataAdapter da = new OleDbDataAdapter();
        OleDbConnection cn = new OleDbConnection(connstr);          //   
        da = new OleDbDataAdapter("SELECT * From RPT_CR_TEST1",  cn);     
        //创建我们的DataSet1实例        
        DataSet1 dt1 = new DataSet1();          //填充dt1         
        //注意：表名mytable必须与我们在xsd设计的表名称一致。 
        //本例中数据库的表实际名称为RPT_CR_TEST1，而最终是以my table为准的 
        //使用 PUSH模式的优点就在此，可以自由组合SQL    
        //前提是表名称和字段名（需要在SQL中使用as别名的方式跟 xsd中设计的字段名一致）都要一致      
        da.Fill(dt1, "mytable");                  
        ReportDocument myReport = new ReportDocument();       
        string reportPath = Server.MapPath("crystalreport1.rpt "); 
        myReport.Load(reportPath);            //绑定数据集，注意，一个报表用一个数据集。       
        myReport.SetDataSource(dt1);      
       //CrystalReportViewer1.ReportSource = myReport;       
    }
}