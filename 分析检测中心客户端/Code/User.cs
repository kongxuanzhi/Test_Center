using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    static class User
    {
        /// <summary>
        ///判断当前全局服务器是否是特殊样品服务器
        /// </summary>
        public static bool TSMODE = false;  
        public static bool IsOfficial = false;    //判断是否为官方模式

        public static string userName="";
        public static string name="";      
        public static string section="";   //部门
        public static string grant = "";   //用于控制菜单权限


        public static bool checkGrant(string key)  //检查权限
        {
            if (grant.Contains(key))
            {
                return true;
            }
            return false;
        }
        
    }
}
