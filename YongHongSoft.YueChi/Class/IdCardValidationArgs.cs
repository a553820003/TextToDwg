// // **************************************************************************
// // 项目名称:    YongHongSoft
// // 工程名称:    YongHongSoft.Validation
// // 文 件 名:     IdCardValidationArgs.cs
// // 创  建  人:   Sunny/fish Fly
// // 创建日期:    2016-10-04-16:29
// // 修  改  人:   Sunny/fish Fly
// // 修改日期:    2016-10-05-17:41
// // *************************
// // 功能说明:    IdCardValidationArgs.cs
// // **************************************************************************

#region using

using System;
using System.Collections.Generic;

#endregion

namespace YongHongSoft.YueChi
{
    /// <summary>
    /// 身份证效验
    /// </summary>
    public class IdCardValidationArgs 
    {
       

        public static  string Validation(object value)
        {
            string str1 = value.ToString();
            try
            {
                List<string> list1 = new List<string>();
                string str2 =
                    "11,12,13,14,15,21,22,23,31,32,33,34,35,36,37,41,42,43,44,45,46,50,51,52,53,54,61,62,63,64,65,81,82";
                List<string> list2 = new List<string>();
                string str3 = "01,02,03,04,05,06,07,08,09,10,11,12";
                int[] numArray = new int[18]
                {
                    7,
                    9,
                    10,
                    5,
                    8,
                    4,
                    2,
                    1,
                    6,
                    3,
                    7,
                    9,
                    10,
                    5,
                    8,
                    4,
                    2,
                    1
                };
                string[] strArray = new string[11]
                {
                    "1",
                    "0",
                    "X",
                    "9",
                    "8",
                    "7",
                    "6",
                    "5",
                    "4",
                    "3",
                    "2"
                };
                if (str1.Length == 18)
                {
                    string str4 = str2;
                    char[] chArray1 = new char[1]
                    {
                        ','
                    };
                    foreach (string str5 in str4.Split(chArray1))
                    {
                        list1.Add(str5);
                    }
                    string str6 = str3;
                    char[] chArray2 = new char[1]
                    {
                        ','
                    };
                    foreach (string str5 in str6.Split(chArray2))
                    {
                        list2.Add(str5);
                    }
                    string str7 = str1.Substring(0, 2);
                    str1.Substring(0, 6);
                    string str8 = str1.Substring(6, 4);
                    string str9 = str1.Substring(10, 2);
                    string str10 = str1.Substring(12, 2);
                    str1.Substring(14, 3);
                    string str11 = str1.Substring(17, 1);
                    if (list1.IndexOf(str7) != -1)
                    {
                        if (list2.IndexOf(str9) != -1)
                        {
                            int year1 = Convert.ToInt32(str8);
                            int year2 = DateTime.Now.Year;
                            int num1 = year2 - year1;
                            if (year1 > year2)
                            {
                                return $"身份证检查，出生年【{year1}】错误。";
                            }
                            if (num1 < 0 || num1 > 130)
                            {
                                return  $"身份证检查，出生年【{year1}】错误。";
                              
                            }
                            int month = Convert.ToInt32(str9);
                            DateTime dateTime = new DateTime(year1, month, 1);
                            int day = dateTime.AddMonths(1).AddDays(-dateTime.AddMonths(1).Day).Day;
                            int num2 = Convert.ToInt32(str10);
                            if (num2 >= 1 && num2 <= day)
                            {
                                int num3 = 0;
                                for (int startIndex = 0; startIndex < 17; ++startIndex)
                                {
                                    int num4 = Convert.ToInt32(str1.Substring(startIndex, 1));
                                    num3 += num4*numArray[startIndex];
                                }
                                int index = num3%11;
                                string str5 = strArray[index];
                                if (str11.ToUpper() == str5)
                                    return string.Empty;
                                return  $"身份证检查，校验码【{str11}】错误。";
                            }
                            return  $"身份证检查，出生日【{str10}】错误。";
                        }
                        return  $"身份证检查，出生月【{str9}】错误。";
                    }
                    return "身证号地区编码错误：11-15(京、津、冀、晋、蒙)21-23(辽、吉、黑)31-37 (沪、苏、浙、皖、闽、赣、鲁)41-46(豫、鄂、湘、粤、桂、琼)50-54(渝、川、贵、云、藏)61-65(陕、甘、青、宁、新)81-82(港、澳)";
                   
                }
                return  "身份证号码不足18位.";
            }
            catch (Exception ex)
            {
                return  ex.Message;
            }
        
        }
    }
}