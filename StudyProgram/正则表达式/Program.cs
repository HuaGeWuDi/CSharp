using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace 正则表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            //string value="123";
            //Regex re=new Regex(^[0-9]{1,2}$);
            //if(!re.IsMatch(value))
            //{

            //}
            Regex reg = new Regex("^[0-9]{1,2}$");
            Regex.IsMatch("^[0-9]{1,2}$", "1234");
            if (Regex.IsMatch("1234", "^[0-9]{1,2}$"))
                Console.WriteLine("正确");

            Regex re = new Regex(@"\d");//“\d”表示配置数字。
            string[] strArr = { "abc", "1a2b942443c13332219", "jadksjd", "0a1s djaksd12asjd" };
            foreach (var s in strArr)
            {
                if (re.IsMatch(s))
                    Console.WriteLine("里面有数字的字符串是:'{0}',字符串里面有{1}个数字,第一个匹配得到的值是{2}", s, re.Matches(s).Count,re.Match(s).Value);
            }


            Console.ReadKey();
        }
    }
}
