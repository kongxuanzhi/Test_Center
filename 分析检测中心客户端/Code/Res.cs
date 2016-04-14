using System;
using System.Collections.Generic;
using System.Text;

namespace Code
{
    /// <summary>
    /// 静态资源类
    /// </summary>
    static class Res
    {


        public static byte[] yxkb;  //以下空白

        public static byte[] jxstamp;
        public static byte[] gjstamp;

        public static byte[] blank;
        public static byte[] jxcma;
        public static byte[] jxcma2013;
        public static byte[] jxcal;
        public static byte[] jxcal2013;


        public static byte[] gjcma;
        public static byte[] gjcma2013;
        public static byte[] gjcal2013;
        public static byte[] gjcal;

        public static byte[] test;

        public static byte[] cma;
        public static byte[] cnas;

        //public static Dictionary<string, byte[]> ItemsDic = new Dictionary<string, byte[]>();   //缓存dictionary

        /// <summary>
        /// 预读图片资源
        /// </summary>
        public static void load()
        {

           // yxkb = Libs.getFileBytes("/stamp/yxkb.png"); //以下空白
          //  blank = Libs.getFileBytes("/stamp/blank.jpg"); //空白
           // jxstamp = Libs.getFileBytes("/stamp/jx.jpg");
           // gjstamp = Libs.getFileBytes("/stamp/gj.jpg");
           //// jxcma = Libs.getFileBytes("/stamp/shengcma.jpg");
           // jxcal = Libs.getFileBytes("/stamp/shengcal.jpg");
           // jxcma2013 = Libs.getFileBytes("/stamp/shengcma2013.jpg");
          //  jxcal2013 = Libs.getFileBytes("/stamp/shengcal2013.jpg");


           // gjcma = Libs.getFileBytes("/stamp/guocma.jpg");
          //  gjcal = Libs.getFileBytes("/stamp/guocal.jpg");
         //   gjcal2013 = Libs.getFileBytes("/stamp/guocal2013.jpg"); //cal2013版本

            test = Libs.getFileBytes("/stamp/test31.png"); //检测专用章   
            cma = Libs.getFileBytes("/stamp/cma.jpg");  //Cma章
          //  cnas = Libs.getFileBytes("/stamp/cma.jpg");  //Cma章
        }
    }
}
