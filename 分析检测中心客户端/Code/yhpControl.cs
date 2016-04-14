using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Code
{
    /// <summary>
    /// 易耗品控制类
    /// </summary>
    class yhpControl
    {

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="Iid"></param>
        /// <param name="Ltype"></param>
        /// <param name="Icount"></param>
        /// <param name="Remarks"></param>
        /// <returns></returns>
        public static int addLog(string Iid, string Ltype, double Icount, string Remarks)
        {
            string sql = string.Format("insert into yhp_log(Iid,Ltype,Icount,dt,Remarks,Person) values({0},'{1}',{2},'{3}','{4}','{5}')",
                Iid, Ltype, Icount, Libs.getServerDateStr(), Remarks, User.name);
            return DB.ExecuteNonQuery(sql);
        }


        public static int addLog(string Iid, string Ltype, double Icount, string Remarks,string person)
        {
            string sql = string.Format("insert into yhp_log(Iid,Ltype,Icount,dt,Remarks,Person) values({0},'{1}',{2},'{3}','{4}','{5}')",
                Iid, Ltype, Icount, Libs.getServerDateStr(), Remarks, person);
            return DB.ExecuteNonQuery(sql);
        }


        /// <summary>
        /// 增加数量
        /// </summary>
        /// <param name="Iid"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int addNum(string Iid, int num,string Remarks,string p)
        {
            int yj = Convert.ToInt16(DB.ExecuteObject(string.Format("select TotalCount from yhp_items where Iid={0}", Iid)));
            string sql = string.Format("update yhp_items set TotalCount=TotalCount+{0} where IId={1}",num,Iid);
            Remarks = string.Format("{0}=>{1} {2}", yj, yj+num, Remarks);
            int n = DB.ExecuteNonQuery(sql);
            if (n > 0)
            {
                addLog(Iid, "入库", num, Remarks,p);
            }
            return n;
        }

        /// <summary>
        /// 减少数量
        /// </summary>
        /// <param name="Iid"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public static int reduceNum(string Iid, int num, string Remarks,string p)
        {
            int yj = Convert.ToInt16(DB.ExecuteObject(string.Format("select TotalCount from yhp_items where Iid={0}", Iid)));
            string sql = string.Format("update yhp_items set TotalCount=TotalCount+{0} where IId={1}",num,Iid);
            Remarks = string.Format("{0}=>{1} {2}", yj, yj - num, Remarks);
            int n = DB.ExecuteNonQuery(sql);
            if (n > 0)
            {
                addLog(Iid, "出库", num, Remarks,p);
            }
            return n;
        }


        /// <summary>
        /// 修改价格
        /// </summary>
        /// <param name="Iid"></param>
        /// <param name="price"></param>
        /// <param name="Remarks"></param>
        /// <returns></returns>
        public static int changePrice(string Iid,double price,string Remarks)
        {
            string yj = DB.ExecuteScalar(string.Format("select price from yhp_items where Iid={0}", Iid));
            string sql = string.Format("update yhp_items set price={0} where IId={1}", price, Iid);
            int n = DB.ExecuteNonQuery(sql);
            Remarks = string.Format("{0}=>{1} {2}", yj, price, Remarks);
            if (n > 0)
            {
                addLog(Iid, "价格修改",price,Remarks);
            }
            return n;
        }

        /// <summary>
        /// 获取日志列表
        /// </summary>
        /// <param name="Iid"></param>
        /// <returns></returns>
        public static DataTable getLogdt(string Iid,bool asc)
        {
            string sql = "";
            string order = "";
            if (!asc)   //排序方向
            {
                order = " order by dt desc";
            }
            if (Iid=="")
            {
                sql = "select yhp_log.Iid as 物品编号,Iname as 物品名,Ltype as 事件,Icount as 处理结果,Remarks as 备注,person as 执行人,dt as 时间 from yhp_log,yhp_items where yhp_log.Iid=yhp_items.Iid" + order;
            }
            else
            {
                sql = string.Format("select yhp_log.Iid as 物品编号,Iname as 物品名,Ltype as 事件,Icount as 处理结果,Remarks as 备注,person as 执行人,dt as 时间 from yhp_log,yhp_items where yhp_log.Iid=yhp_items.Iid and yhp_items.Iid={0} {1}", Iid,order);
            }
            DataTable dt = DB.getDataTable(sql);
            return dt;
        }


        /// <summary>
        /// 根据名称获取日志列表
        /// </summary>
        /// <param name="Iid"></param>
        /// <returns></returns>
        public static DataTable getLogdtByName(string Iname,string key,bool asc)
        {
            string sql = "";
            string order = "";
            if (!asc)   //排序方向
            {
                order = " order by dt desc";
            }
            sql = string.Format("select yhp_log.Iid as 物品编号,Iname as 物品名,Ltype as 事件,Icount as 处理结果,Remarks as 备注,person as 执行人,dt as 时间 from yhp_log,yhp_items where yhp_log.Iid=yhp_items.Iid and yhp_items.Iname like '%{0}%' ",Iname);
            if (key != "")
            {
                sql += string.Format("and yhp_log.Ltype='{0}' ", key);
            }
            sql += order;

            DataTable dt = DB.getDataTable(sql);
            return dt;
        }




    }
}
