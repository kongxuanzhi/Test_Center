using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.OleDb;
using Code;

namespace TRESystem2011.Manage
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(formatDbDate));
            t.Start();
            MessageBox.Show("已经开始执行更新！！请耐心等待~期间请勿关闭程序！");
        }

        void formatDbDate() //更新数据库中的日期值
        {
            DataTable dt = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter("select * from sampletable", DB.m_conn);
            OleDbCommandBuilder scb = new OleDbCommandBuilder(adapter); //自动生成SQL语句
            adapter.Fill(dt);
            string timestr;

            foreach (DataRow row in dt.Rows)
            {
                timestr = row["Sintime"].ToString();
                if (timestr.Trim() != "/")
                    row["Sintime"] = Convert.ToDateTime(timestr).ToLocalTime().ToString();
                timestr = row["Sprooftime"].ToString();
                if (timestr.Trim() != "/") row["Sprooftime"] = Convert.ToDateTime(timestr).ToLocalTime().ToString();
                timestr = row["Ssignintime"].ToString();
                if (timestr.Trim() != "/") row["Ssignintime"] = Convert.ToDateTime(timestr).ToLocalTime().ToString();
                timestr = row["Souttime"].ToString();
                if (timestr.Trim() != "/") row["Souttime"] = Convert.ToDateTime(timestr).ToLocalTime().ToString();
                timestr = row["Sverifytime"].ToString();
                if (timestr.Trim() != "/") row["Sverifytime"] = Convert.ToDateTime(timestr).ToLocalTime().ToString();
                timestr = row["Sapprovetime"].ToString();
                if (timestr.Trim() != "/") row["Sapprovetime"] = Convert.ToDateTime(timestr).ToLocalTime().ToString();
                timestr = row["Rsendtime"].ToString();
                if (timestr.Trim() != "/") row["Rsendtime"] = Convert.ToDateTime(timestr).ToLocalTime().ToString();
                timestr = row["Scontracttime"].ToString().ToString();
                if (timestr.Trim() != "/") row["Scontracttime"] = Convert.ToDateTime(timestr).ToShortDateString();

            }

            adapter.Update(dt);
            MessageBox.Show("搞定！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "delete from Resulttable where Titem='/'";
            int n = DB.ExecuteNonQuery(sql);
            MessageBox.Show(n.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "alter table resulttable add id int primary key identity(1,1);";
                DB.ExecuteNonQuery(sql);
                MessageBox.Show("Resulttable完成");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("出错！"+ex.Message);
            }
 
        }

        /// <summary>
        /// 修改字段为可变长度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int n;
                string sql;
//                 sql = @"
//                         alter table Customer
//                         ALTER COLUMN customerNo nvarchar(20) not null
//                         alter table Customer
//                         ALTER COLUMN customername nvarchar(50)
//                         alter table Customer
//                         ALTER COLUMN address nvarchar(100)
//                         alter table Customer
//                         ALTER COLUMN relation nvarchar(20)
//                         alter table Customer
//                         ALTER COLUMN email nvarchar(50)
//                         alter table Customer
//                         ALTER COLUMN postcode nvarchar(20)
//                         alter table Customer
//                         ALTER COLUMN tel nvarchar(50)
//                         alter table Customer
//                         ALTER COLUMN fax nvarchar(50)
//                         alter table Customer
//                         ALTER COLUMN net nvarchar(50)
//                         alter table Customer
//                         ALTER COLUMN kinds nvarchar(10)
// 
//                         update Customer
//                         set customerNo = rtrim(customerNo) ,
//                         customername=rtrim(customername),
//                         address=rtrim(address),
//                         relation=rtrim(relation),
//                         email=rtrim(email),
//                         postcode=rtrim(postcode),
//                         tel=rtrim(tel),
//                         fax=rtrim(fax),
//                         net=rtrim(net),
//                         kinds=rtrim(kinds)";
//                 n = DB.ExecuteNonQuery(sql);
//                 MessageBox.Show("Customer表处理数据：" + n);
// 
//                 sql = @"alter table Users
//                         ALTER COLUMN usernumber nvarchar(20)
//                         alter table Users
//                         ALTER COLUMN username nvarchar(20)
//                         alter table Users
//                         ALTER COLUMN department nvarchar(20)
//                         alter table Users
//                         ALTER COLUMN password nvarchar(255)
// 
//                         update Users
//                         set usernumber=rtrim(usernumber),
//                         username=rtrim(username),
//                         department=rtrim(department),
//                         password=rtrim(password)";
//                 n = DB.ExecuteNonQuery(sql);
//                 MessageBox.Show("User表处理数据：" + n);
//                 sql = @"alter table SampleKinds
//                         ALTER COLUMN [ID] nvarchar(10) NOT NULL 
//                         alter table SampleKinds
//                         ALTER COLUMN KindsName nvarchar(20)
//                         alter table SampleKinds
//                         ALTER COLUMN TestKinds nvarchar(30)
//                         alter table SampleKinds
//                         ALTER COLUMN [Index] nvarchar(10)
// 
//                         update SampleKinds
//                         set ID=rtrim(ID),
//                         KindsName=rtrim(KindsName),
//                         TestKinds=rtrim(TestKinds),
//                         [Index]=rtrim([Index])";
//                 n = DB.ExecuteNonQuery(sql);
//                 MessageBox.Show("SampleKinds表处理数据：" + n);
// 
// 
//                 sql = @"      
//                     alter table Product
//                     ALTER COLUMN productnumber nvarchar(50) NOT NULL 
//                     alter table Product
//                     ALTER COLUMN productname nvarchar(200)
//                     alter table Product
//                     ALTER COLUMN kinds nvarchar(10) 
// 
//                     update Product
//                     set productnumber =rtrim(productnumber),
//                     productname =rtrim(productname),
//                     kinds =rtrim(kinds)";
//                 n = DB.ExecuteNonQuery(sql);
//                 MessageBox.Show("Product表处理数据：" + n);
// 
//                 sql = @"
//                     alter table ProductName
//                     ALTER COLUMN [ProductName] nvarchar(30) NOT NULL 
//                     alter table ProductName
//                     ALTER COLUMN [ProductKind] nvarchar(10) 
//                     alter table ProductName
//                     ALTER COLUMN [According] nvarchar(100) 
// 
// 
//                     update ProductName
//                     set ProductName =rtrim(ProductName),
//                     ProductKind =rtrim(ProductKind ),
//                     According=rtrim(According)";
//                 n = DB.ExecuteNonQuery(sql);
//                 MessageBox.Show("ProductName表处理数据：" + n);
// 
// 
// 
//                 sql = @"alter table ProductItem
//                     ALTER COLUMN ProductName nvarchar(30)
//                     alter table ProductItem
//                     ALTER COLUMN ProductType nvarchar(20)
//                     alter table ProductItem
//                     ALTER COLUMN ProductClass nvarchar(10)
//                     alter table ProductItem
//                     ALTER COLUMN ProductItem nvarchar(20)
//                     alter table ProductItem
//                     ALTER COLUMN ItemUnit nvarchar(10)
//                     alter table ProductItem
//                     ALTER COLUMN ItemValue nvarchar(20)
// 
//                     update ProductItem
//                     set ProductName=rtrim(ProductName),
//                     ProductType=rtrim(ProductType),
//                     ProductClass=rtrim(ProductClass),
//                     ProductItem=rtrim(ProductItem),
//                     ItemUnit=rtrim(ItemUnit),
//                     ItemValue=rtrim(ItemValue)";
//                 n = DB.ExecuteNonQuery(sql);
//                 MessageBox.Show("ProductItem表处理数据：" + n);              

                sql = @"alter table QStamp drop column centername;
                    alter table qstamp drop column signs;
                    alter table qstamp ALTER COLUMN SampleNumber nvarchar(20);
                    alter table qstamp alter column ReportName nvarchar(100);
                    update Qstamp set
                    SampleNumber=rtrim(Samplenumber),
                    ReportName=rtrim(ReportName)
";


                n = DB.ExecuteNonQuery(sql);
                MessageBox.Show("QStamp表处理数据：" + n);    


                MessageBox.Show("处理完毕！");

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql = "update sampletable set CanBaseInformation='false',CanSintime='false',CanCost='false',CanScontracttime='false',CanItems='false'";
            MessageBox.Show(DB.ExecuteNonQuery(sql).ToString());
        }

        /// <summary>
        /// 转换数据库字段
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {

        }


    }
}

