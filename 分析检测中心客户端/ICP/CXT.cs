using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using LuaInterface;

namespace ICPTOOLS_DONET
{
   

    [Serializable]
    public class YS   //元素以及值
    {

        public const int MAX_SAMPLES = 5;

        public string name;    //元素名
        public List<double> originalval;   //原始数据
        public double[] oval;           //计算后氧化物
        public double[] val;            //计算后单质
        
        public string limitval;             //修正后数据（最终用来输出数据）
        public double oavgval;              //氧化物修正后平均值
        public double avgval;               //单质修正后平均值
        
        public double omaxdiffer;              //氧化物最大偏差
        public double maxdiffer;               //单质最大偏差

        public double blank;                //空白专用数据
        public double other;                //其他数据

        public YS(string name)
        {
            this.name = name;
            oval = new double[MAX_SAMPLES];
            val = new double[MAX_SAMPLES];
            originalval = new List<double>();
            oavgval = 0;
            avgval = 0;
            omaxdiffer = 0;
            maxdiffer = 0;
            blank = 0;
            other = 0;

        }
        /// <summary>
        /// 计算修正值
        /// </summary>
        public void calLimit(double downline, int downrate, bool is_o)
        {
            string formatstr = "{0:F" + downrate + "}";
            string downformatstr = "<{0:F" + downrate + "}";
            if (is_o)
            {
                if (oavgval < downline)
                {
                    limitval = string.Format(downformatstr, downline);
                }
                else
                {
                    limitval = string.Format(formatstr, oavgval);
                }
            }
            else
            {
                if (avgval < downline)
                {
                    limitval = string.Format(downformatstr, downline);
                }
                else
                {
                    limitval = string.Format(formatstr, avgval);
                }
            }
        }


        public void calMaxDiffer()
        {

            for (int i = 0; i < originalval.Count; i++)
            {
                double tmp1 = Math.Round(Math.Abs(oval[i] - oavgval),3);
                double tmp2 = Math.Round(Math.Abs(val[i] - avgval),3);
                if (tmp1 > omaxdiffer)
                {
                    omaxdiffer = tmp1;
                }
                if (tmp2 > maxdiffer)
                {
                    maxdiffer = tmp2;
                }
            }

        }


        
    }

    [Serializable]
    public class XT
    {

        public static Dictionary<string, XT> TotalDic = new Dictionary<string, XT>();   //全局所有XT



        //以下用来定义flag
        public int[] flags; //标记

        public const int MODE = 0; //所处模式
        public const int MODE_PFAL = 0;    //配分AL模式
        public const int MODE_PURE = 1;    //纯度模式
        public const int MODE_RPT = 2;      //报告模式


        public const int IS_O = 1; //是否氧化物
        public const int IS_LIMIT = 2; //是否修正
        public const int PURE_INDEX = 3;   //纯度最大值

        //以下是属性

        public string id;	//编号
	    public string name;	//名称
	    public string customnum;	//客户编号
        public List<YS> xtyslist;  //存放所有稀土元素及数据
        public List<YS> qtyslist;   //存放所有其他元素及数据（AL）

        public double opjfzl;   //氧化物平均分子量
        public double pjfzl;    //单质平均分子量
        public double fzlrate;  //分子量比值

        public List<string> fromFiles; //原始数据文件路径

        public XT(string id)
        {
            this.id = id;
            flags = new int[10];
            opjfzl = 0;
            pjfzl = 0;
            fzlrate = 0;
            customnum = "";
            xtyslist = new List<YS>();
            qtyslist = new List<YS>();
            fromFiles = new List<string>();
            flags[MODE] = MODE_PFAL;    //默认配分AL
            flags[IS_O] = 1;        //默认是氧化物
            flags[IS_LIMIT] = 0;    //默认无修正
           
        }


        public void calPF()  //计算配分（只计算稀土元素）
        {
            flags[MODE] = MODE_PFAL;
            if (xtyslist.Count==0)
            {
                return;
            }
            int n = xtyslist[0].originalval.Count;
            double[] sumlist=new double[n];
            double[] sumlist1 = new double[n];  //单质总和
            for (int i = 0; i < n; i++) 
            {
                sumlist[i] = 0;
                sumlist1[i] = 0;
                foreach (YS y in xtyslist)  //计算加和
                {
                   sumlist[i]+=y.originalval[i];
                }

                foreach (YS y in xtyslist)  //计算出每个数据的oval和未归一前val
                {
                    y.oval[i] = Math.Round(y.originalval[i] / sumlist[i] * 100, 3);   
                    y.val[i] =y.oval[i] * (double)Lualib.getYSProp(y.name, "rate");
                    sumlist1[i] += y.val[i];
                }
                foreach (YS y in xtyslist)  
                {
                    y.val[i] = Math.Round(y.val[i] / sumlist1[i]*100,3); 
                }

            }

            double molsum = 0;
            double molsum1 = 0;
            foreach (YS y in xtyslist)  
            {
                y.oavgval = 0;
                y.avgval = 0;
                for (int i = 0; i < n; i++)
                {
                    y.oavgval += y.oval[i];
                    y.avgval += y.val[i];
                }
                y.oavgval = Math.Round(y.oavgval/n,3); //计算出此元素平均氧化物的值
                y.avgval = Math.Round(y.avgval/n,3);  //计算出此元素平均单质的值
                y.limitval = string.Format("{0:F2}",y.oavgval);   //平均修正值

                molsum += y.oavgval / (double)Lualib.getYSProp(y.name, "reo");
                molsum1 += y.avgval / (double)Lualib.getYSProp(y.name, "re");

                y.calMaxDiffer();   //计算最大差值
            }
            opjfzl = Math.Round( 1/ molsum*100,3);   //氧化物平均分子量
            pjfzl = Math.Round( 1/ molsum1 * 100,3);//单质平均分子量
            fzlrate = opjfzl / pjfzl;
        }

        public void calQTYS()   //计算其他元素，默认按单质计算
        {
            flags[MODE] = MODE_PFAL;

            if (qtyslist.Count == 0)
            {
                return;
            }

            for (int i = 0; i < qtyslist.Count; i++)
            {
                YS ys = qtyslist[i];
                ys.avgval = 0;
                ys.oavgval = 0;

                double rate = (double)Lualib.getYSProp(ys.name, "rate");        //换算比率
                double divnum = (double)Lualib.getYSProp(ys.name, "divnum");    //除的系数

                for (int j = 0; j < ys.originalval.Count; j++)
                {
                    //这里使用的是单质
                    ys.val[j] = Math.Round((ys.originalval[j] - ys.blank) / divnum, 3);   //每个减去空白再计算
                    ys.oval[j] = Math.Round(ys.val[j] / rate,3);  //计算氧化物
                    ys.avgval += ys.val[j];
                    ys.oavgval += ys.oval[j];
                }

                
                //已经改成默认按单质计算
                ys.avgval = Math.Round(ys.avgval / ys.originalval.Count, 3); //得到单质的平均值
                ys.oavgval = Math.Round(ys.oavgval / ys.originalval.Count, 3); //氧化物平均值
                ys.limitval = string.Format("{0:F2}", ys.oavgval); //修正值
                ys.calMaxDiffer();
            }

        }

        public void calPURE()   //计算纯度
        {
            flags[MODE] = MODE_PURE;
            if (xtyslist.Count == 0)
            {
                return;
            }           
            int n = xtyslist[0].originalval.Count;  //平行样数量

            int PureMaxFlag = 0;    //最纯的INDEX

            for(int i=0;i<xtyslist.Count;i++)  //计算平均值
            {
                YS y = xtyslist[i];
                y.oavgval = 0;
                y.avgval = 0;
                for (int j = 0; j < n; j++)
                {
                    y.oval[j] = y.originalval[j];   //氧化物直接除
                    y.val[j] = Math.Round(y.originalval[j] / (double)Lualib.getYSProp(y.name, "rate"), 5);    //单质
                    y.oavgval += y.oval[j];
                    y.avgval += y.val[j];
                }
                y.oavgval = Math.Round(y.oavgval / n, 3); //计算出此元素平均氧化物的值
                y.avgval = Math.Round(y.avgval / n, 3);  //计算出此元素平均单质的值
                y.limitval = string.Format("{0:F2}", y.oavgval);   //平均修正值
                y.calMaxDiffer();   //计算最大差值

                if (xtyslist[PureMaxFlag].oavgval<y.oavgval)  //找出最纯的元素序号
                {
                    PureMaxFlag = i;
                }
            }
            flags[XT.PURE_INDEX] = PureMaxFlag; 
            //这里分子量直接用最纯的元素近似代替
            opjfzl = (double)Lualib.getYSProp(xtyslist[PureMaxFlag].name, "reo");   
            pjfzl = (double)Lualib.getYSProp(xtyslist[PureMaxFlag].name, "re");
            fzlrate = opjfzl / pjfzl;

        }


    }


    public class RPTXT //报告专用XTRPT
    {
        public string id;  //标号
        public Dictionary<string, object> YSDic;   //元素和值的列表

        public RPTXT(string id)
        {
            this.id = id;
            YSDic = new Dictionary<string, object>();
        }




    }

    



}
