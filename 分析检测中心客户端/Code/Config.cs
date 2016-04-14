using System;
using System.Collections.Generic;
using System.Text;
using Code;

namespace Code
{
    [Serializable]
    public class TREConfig
    {
        public List<string> UserNameList=new List<string>();  //登陆用户名列表
        public int FWQindex=0;    //选择的服务器


        public static void Save(TREConfig c)
        {
            Libs.Serialize(c, "config.tmp");
        }

        public static TREConfig Load()
        {
            return (TREConfig)Libs.Deserialize("config.tmp");
        }


    }
}
