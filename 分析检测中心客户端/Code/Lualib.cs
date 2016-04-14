using System;
using System.Collections.Generic;
using System.Text;
using LuaInterface;
using System.Collections.Specialized;
using System.Windows.Forms;


    static class Lualib
    {
        public static Lua lua=null;

        public static void initLua()    //直接初始化lua并获取默认定义
        {
            if (lua==null)
            {
                lua = new Lua();
                lua.DoFile(Application.StartupPath + "\\Define.lua");
                lua.DoFile(Application.StartupPath + "\\ICP.lua");
            }
        }

        public static object getYSProp(string ysname, string propname)  //获取元素属性
        {
            string str = string.Format("ys.{0}.{1}", ysname, propname);
            return lua[str];
        }

        public static object getTempProp(string propname)   //获取模板属性
        {
            string str = string.Format("temp.{0}",propname);
            return lua[str];
        }

        public static LuaTable getLuaTable(string tbname)   //获取lua的表
        {
            return lua.GetTable(tbname);
        }

        public static ListDictionary getListDict(string tbname) //获取luadict
        {
            return lua.GetTableDict(lua.GetTable(tbname));
        }

    }
