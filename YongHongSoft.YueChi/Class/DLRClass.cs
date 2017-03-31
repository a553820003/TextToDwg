using System;

namespace YongHongSoft.YueChi
{
    /// <summary>
    /// 代理人
    /// </summary>
  public  class DLRClass
    {
        /// <summary>
        /// 代理人姓名
        /// </summary>
        public string DLRXM { get; set; }

        /// <summary>
        ///证件种类
        /// </summary>
        public string ZJZL { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string ZJH { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string DHHM { get; set; }
        /// <summary>
        /// 宗地代码
        /// </summary>
        public string ZDDM { get; set; }



    }
    /// <summary>
    /// 法定代表人
    /// </summary>
    public class FDDBRClass
    {
        /// <summary>
        /// 法定代表人
        /// </summary>
        public string FDDBR { get; set; }
        /// <summary>
        /// 证件种类
        /// </summary>
        public string ZJZL { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string ZJH { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string DHHM { get; set; }
        /// <summary>
        /// 宗地代码
        /// </summary>
        public string ZDDM { get; set; }

    

    }

    public class QLRClass
    {
 /// <summary>
        /// 使用权
        /// </summary>
        public string SYQ { get; set; }
        /// <summary>
        /// 权利人类型
        /// </summary>
        public string QLRLX { get; set; }
        /// <summary>
        /// 证件种类
        /// </summary>
        public string ZJZL { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string ZJH { get; set; }
        /// <summary>
        /// 通讯地址
        /// </summary>
        public string TXDZ { get; set; }
        /// <summary>
        /// 权利类型
        /// </summary>
        public string QLLX { get; set;}
        /// <summary>
        /// 权利性质
        /// </summary>
        public string QLXZ { get; set;}
        /// <summary>
        /// 土地权属来源证明材料
        /// </summary>
        public string ZMCL { get; set;}
        /// <summary>
        /// 宗地代码
        /// </summary>
        public string ZDDM { get; set; }

    }

    public class ZDFWXXClass
    {/// <summary>
    /// 宗地代码
    /// </summary>
        public string ZDDM { get; set;}
        /// <summary>
        /// 所有权
        /// </summary>
        public string SYQ { get; set; }
        /// <summary>
        /// 坐落
        /// </summary>
        public string ZL { get; set; }
        /// <summary>
        /// 权利设定方式
        /// </summary>
        public string QLSDFS { get; set; }
        /// <summary>
        /// 国民经济行业分类代码
        /// </summary>
        public string HYFL { get; set; }
        /// <summary>
        /// 预编宗地代码
        /// </summary>
        public string YBZDDM { get; set;}
        /// <summary>
        /// 不动产单元号
        /// </summary>
        public Int64 BDCDYH { get; set; }
      /// <summary>
      /// 比例尺
      /// </summary>
        public string BLC { get; set;}
        /// <summary>
        /// 图符号
        /// </summary>
        public string TFH { get; set; }
        /// <summary>
        /// 北至
        /// </summary>
        public string BZ { get; set; }
        /// <summary>
        /// 东至
        /// </summary>
        public string DZ { get; set; }
        /// <summary>
        /// 南至
        /// </summary>
        public string NZ { get; set; }
        /// <summary>
        /// 西至
        /// </summary>
        public double XZ { get; set; }
        /// <summary>
        /// 批准面积
        /// </summary>
        public double PZMJ { get; set; }
        /// <summary>
        /// 宗地面积
        /// </summary>
        public double ZDMJ { get; set;}
        /// <summary>
        /// 建筑占地面积
        /// </summary>
        public double JZZDMJ { get; set; }
        /// <summary>
        /// 建筑总面积
        /// </summary>
        public int JZZMJ { get; set; }
        /// <summary>
        /// 界址点个数
        /// </summary>
        public DateTime JZDGS { get; set; } 
        /// <summary>
        /// 修建时间
        /// </summary>
        public string XJSJ { get; set; }
        /// <summary>
        /// 房屋结构
        /// </summary>
        public string FWJG { get; set; }
        /// <summary>
        /// 总层数
        /// </summary>
        public int ZCS { get; set; }
        /// <summary>
        /// 有无建设用地许可证
        /// </summary>
        public string JSYDXKZ { get; set; }
        /// <summary>
        /// 有无集体土地建设用地使用权证
        /// </summary>
        public string JTJSYDSYQZ { get; set; }
        /// <summary>
        /// 批准用地面积
        /// </summary>
        public double PZYDMJ { get; set; }
        /// <summary>
        /// 实测建筑面积
        /// </summary>
        public double SCJZMJ { get; set; }
        /// <summary>
        /// 有无建设规划许可证或房屋所有权证
        /// </summary>
        public string JSYDSYQZ { get; set; }
        /// <summary>
        /// 批准建筑面积
        /// </summary>
        public double PZJZMJ { get; set; }
        /// <summary>
        /// 调查员
        /// </summary>
        public string DCY { get; set; }
        /// <summary>
        /// 竣工时间
        /// </summary>
        public string JGSJ { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string BEIZHU { get; set; }
        
        

    }



}
