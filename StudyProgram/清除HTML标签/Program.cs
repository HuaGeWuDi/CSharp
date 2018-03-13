using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace 清除HTML标签
{
    class Program
    {
        public static DataTable GetNewTable(DataTable new_dt, params object[] parms)
        {
            Func<object, string> fnClearHtml = (object obj) =>
            {
                var HtmlStr = obj + "";
                //删除脚本
                HtmlStr = HtmlStr.Replace("\r\n", "");
                HtmlStr = Regex.Replace(HtmlStr, @"<script.*?</script>", "", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"<style.*?</style>", "", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"<.*?>", "", RegexOptions.IgnoreCase);
                //删除HTML
                HtmlStr = Regex.Replace(HtmlStr, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"-->", "", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"<!--.*", "", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"&(nbsp|#160);", "", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
                HtmlStr = Regex.Replace(HtmlStr, @"&#(\d+);", "", RegexOptions.IgnoreCase);
                HtmlStr = HtmlStr.Replace("<", "");
                HtmlStr = HtmlStr.Replace(">", "");
                HtmlStr = HtmlStr.Replace("\r\n", "");
                //HtmlStr = HttpContext.Current.Server.HtmlEncode(HtmlStr).Trim();
                return HtmlStr;
            };
            if (new_dt != null)
            {
                foreach (var p in parms)
                {
                    var pp = p + "";
                    new_dt.Columns.Add();
                    new_dt.Columns.Add(p + "1", typeof(string));
                    foreach (DataRow dr in new_dt.Rows)
                        dr[p + "1"] = fnClearHtml(dr[pp]);

                    new_dt.Columns.Remove(pp);
                    new_dt.Columns[p + "1"].ColumnName = pp;
                }
            }
            return new_dt;
        }
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("sex", typeof(string));
            dt.Columns.Add("age", typeof(string));
            var row = dt.NewRow();
            row["name"]=@"<p>\qq,华哥/\</p>";
            row["sex"] = @"<p>\qq,男神/\</p>";
            row["age"] = @"<script>\qq,18/\</p>";
            dt.Rows.Add(row);
            var _newDT = GetNewTable(dt, "name", "sex", "age");
            Console.WriteLine(_newDT.Columns.Count);
            Console.ReadLine();
        }
    }
}
