using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Microsoft.VisualBasic;
using System.IO;
using System.Security.Permissions;
using System.Collections;
using System.Runtime.InteropServices;

namespace iTrip.Utility
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Utils
    {
        #region String字符串类
        /// <summary>
        /// 返回字符串真实长度, 1个汉字长度为2
        /// </summary>
        /// <returns></returns>
        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }
        /// <summary>
        /// 过滤非法字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ReplaceBadChar(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            string strBadChar, tempChar;
            string[] arrBadChar;
            strBadChar = "@@,+,',--,%,^,&,?,(,),<,>,[,],{,},/,\\,;,:,\",\"\",";
            arrBadChar = SplitString(strBadChar, ",");
            tempChar = str;
            for (int i = 0; i < arrBadChar.Length; i++)
            {
                if (arrBadChar[i].Length > 0)
                    tempChar = tempChar.Replace(arrBadChar[i], "");
            }
            return tempChar;
        }


        /// <summary>
        /// 检查是否含有非法字符
        /// </summary>
        /// <param name="str">要检查的字符串</param>
        /// <returns></returns>
        public static bool ChkBadChar(string str)
        {
            bool result = false;
            if (string.IsNullOrEmpty(str))
                return result;
            string strBadChar, tempChar;
            string[] arrBadChar;
            strBadChar = "@@,+,',--,%,^,&,?,(,),<,>,[,],{,},/,\\,;,:,\",\"\"";
            arrBadChar = SplitString(strBadChar, ",");
            tempChar = str;
            for (int i = 0; i < arrBadChar.Length; i++)
            {
                if (tempChar.IndexOf(arrBadChar[i]) >= 0)
                    result = true;
            }
            return result;
        }


        /// <summary>
        /// 分割字符串
        /// </summary>
        public static string[] SplitString(string strContent, string strSplit)
        {
            int i = strContent.IndexOf(strSplit);
            if (strContent.IndexOf(strSplit) < 0)
            {
                string[] tmp = { strContent };
                return tmp;
            }
            //return Regex.Split(strContent, @strSplit.Replace(".", @"\."), RegexOptions.IgnoreCase);

            return Regex.Split(strContent, @strSplit.Replace(".", @"\."));
        }
        /// <summary>
        /// 检测是否有危险的可能用于链接的字符串
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeUserInfoString(string str)
        {
            return !Regex.IsMatch(str, @"/^\s*$|^c:\\con\\con$|[%,\*" + "\"" + @"\s\t\<\>\&]|$guestexp/is");
        }

        /// <summary>
        /// string型转换为int型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <returns>转换后的int类型结果.如果要转换的字符串是非数字,则返回-1.</returns>
        public static int StrToInt(object strValue)
        {
            int defValue = -1;
            if ((strValue == null) || (strValue.ToString() == string.Empty) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }

            string val = strValue.ToString();
            string firstletter = val[0].ToString();

            if (val.Length == 10 && IsNumber(firstletter) && int.Parse(firstletter) > 1)
            {
                return defValue;
            }
            else if (val.Length == 10 && !IsNumber(firstletter))
            {
                return defValue;
            }


            int intValue = defValue;
            if (strValue != null)
            {
                bool IsInt = new Regex(@"^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString());
                if (IsInt)
                {
                    intValue = Convert.ToInt32(strValue);
                }
            }

            return intValue;
        }

        /// <summary>
        /// string型转换为int型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static int StrToInt(object strValue, int defValue)
        {
            if ((strValue == null) || (strValue.ToString() == string.Empty) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }

            string val = strValue.ToString();
            string firstletter = val[0].ToString();

            if (val.Length == 10 && IsNumber(firstletter) && int.Parse(firstletter) > 1)
            {
                return defValue;
            }
            else if (val.Length == 10 && !IsNumber(firstletter))
            {
                return defValue;
            }


            int intValue = defValue;
            if (strValue != null)
            {
                bool IsInt = new Regex(@"^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString());
                if (IsInt)
                {
                    intValue = Convert.ToInt32(strValue);
                }
            }

            return intValue;
        }

        /// <summary>
        /// string型转换为float型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的int类型结果</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }

            float intValue = defValue;
            if (strValue != null)
            {
                bool IsFloat = new Regex(@"^([-]|[0-9])[0-9]*(\.\w*)?$").IsMatch(strValue.ToString());
                if (IsFloat)
                {
                    intValue = Convert.ToSingle(strValue);
                }
            }
            return intValue;
        }



        /// <summary>
        /// string型转换为时间型
        /// </summary>
        /// <param name="strValue">要转换的字符串</param>
        /// <param name="defValue">缺省值</param>
        /// <returns>转换后的时间类型结果</returns>
        public static DateTime StrToDateTime(object strValue, DateTime defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 20))
            {
                return defValue;
            }

            DateTime intValue;

            if (!DateTime.TryParse(strValue.ToString(), out intValue))
            {
                intValue = defValue;
            }
            return intValue;
        }


        /// <summary>
        /// 判断给定的字符串(strNumber)是否是数值型
        /// </summary>
        /// <param name="strNumber">要确认的字符串</param>
        /// <returns>是则返加true 不是则返回 false</returns>
        public static bool IsNumber(string strNumber)
        {
            return new Regex(@"^([0-9])[0-9]*(\.\d*)?$").IsMatch(strNumber);
        }


        /// <summary>
        /// 检测是否符合email格式
        /// </summary>
        /// <param name="strEmail">要判断的email字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }


        /// <summary>
        /// 检测是否符合url格式,前面必需含有http://
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsURL(string url)
        {
            return Regex.IsMatch(url, @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");
        }

        /// <summary>
        /// 检测是否符合电话格式
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^(\(\d{3}\)|\d{3}-)?\d{7,8}$");
        }



        /// <summary>
        /// 检测是否符合时间格式
        /// </summary>
        /// <returns></returns>
        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, @"20\d{2}\-[0-1]{1,2}\-[0-3]?[0-9]?(\s*((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?))?");
        }



        /// <summary>
        /// 检测是否符合身份证号码格式
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static bool IsIdentityNumber(string num)
        {
            return Regex.IsMatch(num, @"^\d{17}[\d|X]|\d{15}$");
        }

        /// <summary>
        /// 检测是否符合邮编格式
        /// </summary>
        /// <param name="postCode"></param>
        /// <returns></returns>
        public static bool IsPostCode(string postCode)
        {
            return Regex.IsMatch(postCode, @"^\d{6}$");
        }


        /// <summary>
        /// MD5函数
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str)
        {
            byte[] b = Encoding.Default.GetBytes(str);
            b = new MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');
            return ret;
        }

        /// <summary>
        /// 转换为简体中文
        /// </summary>
        public static string ToSChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.SimplifiedChinese, 0);
        }

        /// <summary>
        /// 转换为繁体中文
        /// </summary>
        public static string ToTChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.TraditionalChinese, 0);
        }

        /// <summary>
        /// 自定义的替换字符串函数
        /// </summary>
        public static string ReplaceString(string SourceString, string SearchString, string ReplaceString, bool IsCaseInsensetive)
        {
            return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString, IsCaseInsensetive ? RegexOptions.IgnoreCase : RegexOptions.None);
        }

        /// <summary>
        /// 检查一个数组中所有的元素是否有包含于指定字符串的元素
        /// </summary>
        /// <param name="arr">存储数据数据的字串</param>
        /// <param name="toFind">要查找的字符串</param>
        /// <param name="separator">数组的分隔符</param>
        /// <returns></returns>
        public static bool FoundStringInArr(string arr, string toFind, char separator)
        {
            if (arr.IndexOf(separator) >= 0)
            {
                string[] arrTemp = arr.Split('|');
                for (int i = 0; i < arrTemp.Length; i++)
                {
                    if ((toFind.ToLower().IndexOf(arrTemp[i].ToLower()) >= 0) && (arrTemp[i].ToLower() != ""))
                        return true;
                }

            }
            else
            {
                if ((toFind.ToLower().IndexOf(arr.ToLower())) >= 0 && (arr.ToLower() != ""))
                    return true;
            }
            return false;
        }


        /// <summary>
        /// 检查输入的文字是否为整数数字
        /// </summary>
        /// <param name="Text">输入的文字</param>
        /// <returns>是数据返回true,不是则返回false</returns>
        public static bool isInt(string Text)
        {
            try
            {
                int.Parse(Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 检查输入的文字是否为浮点数字
        /// </summary>
        /// <param name="Text">输入的文字</param>
        /// <returns>是数据返回true,不是则返回false</returns>
        public static bool isFloat(string Text)
        {
            try
            {
                float.Parse(Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 检查输入的文字是否为浮点数字
        /// </summary>
        /// <param name="Text">输入的文字</param>
        /// <returns>是数据返回true,不是则返回false</returns>
        public static bool isDecimal(string Text)
        {
            try
            {
                decimal.Parse(Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 检查输入的文字是否为双精度型数字
        /// </summary>
        /// <param name="Text">文本</param>
        /// <param name="maxLength">总长度，如Oracle数据类型为Number(19,5)，则为19</param>
        /// <param name="decLength">小数精度，如Oracle数据类型为Number(19,5)，则为5</param>
        /// <returns></returns>
        public static bool isDecimal(string Text,int maxLength,int decLength)
        {
            try
            {
                decimal.Parse(Text);

                int index = Text.IndexOf('.');
                if ((index == -1 && Text.Length <= maxLength - decLength) || (index != -1 && index <= maxLength - decLength))
                { 
                    return true; 
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        /// <summary>
        /// 检查输入的文字是否为有效日期
        /// </summary>
        /// <param name="Text">输入的文字</param>
        /// <returns>是有效日期返回true，不是则返回false</returns>
        public static bool isDate(string Text)
        {
            try
            {
                DateTime.Parse(Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

       public static int trueLength(string str)
        {

            // str 字符串
            // return 字符串的字节长度
            int lenTotal = 0;
            int n = str.Length;
            string strWord = "";
            int asc;
            for (int i = 0; i < n; i++)
            {
                strWord = str.Substring(i, 1);
                asc = Convert.ToChar(strWord);
                if (asc < 0 || asc > 127)
                    lenTotal = lenTotal + 2;
                else
                    lenTotal = lenTotal + 1;
            }

            return lenTotal;
        }


       public static string cutTrueLength(string strOriginal, int maxTrueLength, char chrPad, bool blnCutTail)
        {

            // strOriginal 原始字符串
            // maxTrueLength 需要返回的字符串的字节长度
            // chrPad 字符串不够时的填充字符
            // blnCutTail 字符串的字节长度超过maxTrueLength时是否截断多余字符
            // return 返回填充或截断后的字符串
            string strNew = strOriginal;

            if (strOriginal == null || maxTrueLength <= 0)
            {
                strNew = "";
                return strNew;
            }

            int trueLen = trueLength(strOriginal);
            if (trueLen > maxTrueLength)//超过maxTrueLength
            {
                if (blnCutTail)//截断
                {
                    for (int i = strOriginal.Length - 1; i > 0; i--)
                    {
                        strNew = strNew.Substring(0, i);
                        if (trueLength(strNew) == maxTrueLength)
                            break;
                        else if (trueLength(strNew) < maxTrueLength)
                        {
                            strNew += chrPad.ToString();
                            break;
                        }
                    }
                }
            }
            else//填充
            {
                for (int i = 0; i < maxTrueLength - trueLen; i++)
                {
                    strNew += chrPad.ToString();
                }
            }

            return strNew;
        }

       /// <summary>
       /// 将字符串扩展到指定长度，如果长度不够，在前面或后面补指定字符
       /// </summary>
       /// <param name="strValue">原字串</param>
       /// <param name="totalLen">扩展后总长度</param>
       /// <param name="location">补字符的位置（0-前面；1-后面）</param>
       /// <param name="plus_char">补充的字符</param>
       /// <returns></returns>
       public static string PlusSpecialChar(string strValue, int totalLen, int location, char plus_char)
       {
           int strLen = strValue.Length;
           if (strLen >= totalLen)
           {
               return strValue;
           }
           int lenDiff = totalLen - strLen;

           string plusStr = "";
           for (int i = 0; i < lenDiff; i++)
           {
               plusStr += plus_char.ToString();
           }
           if (location == 0)
           {
               return plusStr + strValue;
           }
           else if (location == 1)
           {
               return strValue + plusStr;
           }
           else
           {
               return strValue;
           }

       }
        #endregion

        #region Sql类

        /// <summary>
        /// 检测是否有Sql危险字符
        /// </summary>
        /// <param name="str">要判断字符串</param>
        /// <returns>判断结果</returns>
        public static bool IsSafeSqlString(string str)
        {

            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        /// <summary>
        /// 改正sql语句中的转义字符
        /// </summary>
        public static string mashSQL(string str)
        {
            string str2;

            if (str == null)
            {
                str2 = "";
            }
            else
            {
                str = str.Replace("\'", "'");
                str2 = str;
            }
            return str2;
        }

        /// <summary>
        /// 替换sql语句中的有问题符号
        /// </summary>
        public static string ReplaceBadSQL(string str)
        {
            string str2;

            if (str == null)
            {
                str2 = "";
            }
            else
            {
                str = str.Replace("'", "''");
                str2 = str;
            }
            return str2;
        }



        #endregion

        #region Html类

        /// <summary>
        /// 返回 HTML 字符串的编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        public static string HtmlEncode(string str)
        {
            // str = str.Replace("'", "''");
            return HttpUtility.HtmlEncode(str);

        }

        /// <summary>
        /// 返回 HTML 字符串的解码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string HtmlDecode(string str)
        {
            //str = str.Replace("''", "'");
            return HttpUtility.HtmlDecode(str);
        }

        /// <summary>
        /// 替换html字符
        /// </summary>
        public static string EncodeHtml(string strHtml)
        {
            if (strHtml != "")
            {
                strHtml = strHtml.Replace(",", "&def");
                strHtml = strHtml.Replace("'", "&dot");
                strHtml = strHtml.Replace(";", "&dec");
                return strHtml;
            }
            return "";
        }

        /// <summary>
        /// 替换回车换行符为html换行符
        /// </summary>
        public static string StrFormat(string str)
        {
            string str2;

            if (str == null)
            {
                str2 = "";
            }
            else
            {
                str = str.Replace("\r\n", "<br />");
                str = str.Replace("\n", "<br />");
                str2 = str;
            }
            return str2;
        }
        #endregion

        #region DateTime类


        /// <summary>
        /// 返回标准日期格式string
        /// </summary>
        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 返回指定日期格式
        /// </summary>
        public static string GetDate(string datetimestr, string replacestr)
        {
            if (datetimestr == null)
            {
                return replacestr;
            }

            if (datetimestr.Equals(""))
            {
                return replacestr;
            }

            try
            {
                datetimestr = Convert.ToDateTime(datetimestr).ToString("yyyy-MM-dd").Replace("1900-01-01", replacestr);
            }
            catch
            {
                return replacestr;
            }
            return datetimestr;

        }


        /// <summary>
        /// 返回标准时间格式string
        /// </summary>
        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// 返回标准时间格式string
        /// </summary>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回相对于当前时间的相对天数
        /// </summary>
        public static string GetDateTime(int relativeday)
        {
            return DateTime.Now.AddDays(relativeday).ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回标准时间格式string
        /// </summary>
        public static string GetDateTimeF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        /// <summary>
        /// 返回标准时间 
        /// </sumary>
        public static string GetStandardDateTime(string fDateTime, string formatStr)
        {
            DateTime s = Convert.ToDateTime(fDateTime);
            return s.ToString(formatStr);
        }

        /// <summary>
        /// 返回标准时间 yyyy-MM-dd HH:mm:ss
        /// </sumary>
        public static string GetStandardDateTime(string fDateTime)
        {
            return GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
        }
        /// <summary>
        /// 返回相差的秒数
        /// </summary>
        /// <param name="Time"></param>
        /// <param name="Sec"></param>
        /// <returns></returns>
        public static int StrDateDiffSeconds(string Time, int Sec)
        {
            TimeSpan ts = DateTime.Now - DateTime.Parse(Time).AddSeconds(Sec);
            if (ts.TotalSeconds > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (ts.TotalSeconds < int.MinValue)
            {
                return int.MinValue;
            }
            return (int)ts.TotalSeconds;
        }

        /// <summary>
        /// 返回相差的分钟数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public static int StrDateDiffMinutes(string time, int minutes)
        {
            if (time == "" || time == null)
                return 1;
            TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddMinutes(minutes);
            if (ts.TotalMinutes > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (ts.TotalMinutes < int.MinValue)
            {
                return int.MinValue;
            }
            return (int)ts.TotalMinutes;
        }

        /// <summary>
        /// 返回相差的小时数
        /// </summary>
        /// <param name="time"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static int StrDateDiffHours(string time, int hours)
        {
            if (time == "" || time == null)
                return 1;
            TimeSpan ts = DateTime.Now - DateTime.Parse(time).AddHours(hours);
            if (ts.TotalHours > int.MaxValue)
            {
                return int.MaxValue;
            }
            else if (ts.TotalHours < int.MinValue)
            {
                return int.MinValue;
            }
            return (int)ts.TotalHours;
        }

        #endregion

        #region file类

        /// <summary>
        /// 得到网站的真实路径
        /// </summary>
        /// <returns></returns>
        public static string GetTrueWebSitePath()
        {
            string path = HttpContext.Current.Request.Path;
            if (path.LastIndexOf("/") != path.IndexOf("/"))
            {
                path = path.Substring(path.IndexOf("/"), path.LastIndexOf("/") + 1);
            }
            else
            {
                path = "/";
            }
            return path;

        }

        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="filePath">相对路径</param>
        /// <returns></returns>
        public static bool FileExists(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;
            filePath = HttpContext.Current.Server.MapPath(filePath);
            DirectoryInfo dirInfo = new DirectoryInfo(filePath);
            if (dirInfo.Exists)
                return true;
            return false;
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="filePath">相对路径</param>
        /// <returns>是否成功</returns>
        public static bool CreateDirectory(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;
            filePath = HttpContext.Current.Server.MapPath(filePath);
            DirectoryInfo dirInfo = new DirectoryInfo(filePath);
            if (dirInfo.Exists)
                return true;
            try
            {
                Directory.CreateDirectory(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Number类

        /// <summary>
        /// 将long型数值转换为Int32类型
        /// </summary>
        /// <param name="objNum"></param>
        /// <returns></returns>
        public static int SafeInt32(object objNum)
        {
            if (objNum == null)
            {
                return 0;
            }
            string strNum = objNum.ToString();
            if (IsNumber(strNum))
            {

                if (strNum.ToString().Length > 9)
                {
                    return int.MaxValue;
                }
                return Int32.Parse(strNum);
            }
            else
            {
                return 0;
            }
        }


        #endregion

        #region IsNotEmpty类

        /// <summary>
        /// 将long型数值转换为Int32类型
        /// </summary>
        /// <param name="objNum"></param>
        /// <returns></returns>
        public static bool IsNotEmpty(string objNum)
        {
            if (objNum == null || objNum.Trim().Length <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        #endregion

        #region 页面跳转
        /// <summary> 
        /// 显示确认对话框,用户点'确定',程序继续执行,'取消',跳转到distPath指定的页面 
        /// </summary> 
        public static void ConfirmDialog(System.Web.UI.Page page, string msg, string distPath)
        {
            msg = msg.Replace("\\", "\\\\").Replace("\r", "\\r").Replace("\n", "\\n");
            System.Text.StringBuilder sb_tmp = new System.Text.StringBuilder();

            sb_tmp.Append("<script language='javascript'>");
            sb_tmp.Append("if(!confirm('" + msg + "')) window.location.href='" + distPath + "'");
            sb_tmp.Append("</script>");

            page.Response.Write(sb_tmp.ToString());
        }


        #endregion 

        #region DateTime
        public static string SetDateTimeEmply(DateTime datetime)
        {
            string _dateTime = string.Empty;
            if (datetime == DateTime.MinValue)
            {
                _dateTime = string.Empty;
            }
            else
            {
                _dateTime = datetime.ToShortDateString();
            }
            return _dateTime;
        }

        /// <summary>
        /// 获取系统时间的年月字符串，格式“YYYYMM”，如“200808”
        /// </summary>
        /// <returns></returns>
        public static string GetYearMonth1()
        {
            return DateTime.Today.ToString("yyyyMM");
        }

        /// <summary>
        /// 获取系统时间的年月字符串，格式“YYMM”，如“0808”
        /// </summary>
        /// <returns></returns>
        public static string GetYearMonth()
        {
            return DateTime.Today.ToString("yyMM");
        }

        #endregion
    }
}
