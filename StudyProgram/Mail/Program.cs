using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Mail
{
    class Program
    {
        static void Main(string[] args)
        {
            var toArr = GetToArr();

            Console.WriteLine("请输入你所发的邮件内容");
            var strInfo = Console.ReadLine();
            //string[] toArr = { "956743973@qq.com" };
            //var sbSql=new System.Text.StringBuilder();
            //sbSql.Append("无敌是多么的寂寞,时邵伟是傻逼。。。。");
            //SendMail sendmail = new SendMail(toArr, "1499108081@qq.com", strInfo.ToString(), "测试", "emqthauklhakhfjb");
            //sendmail.Send();           
        }

        public static string[] GetToArr()
        {
            List<string> list = new List<string>();
            Console.WriteLine("请输入您所需发送的的QQ邮箱（如果多个请以','隔开）：");
            var qqStr = Console.ReadLine();
            var qqArr = qqStr.ToString().Split(',');
            var qqZz=@"^[1-9]\d{4,10}@qq\.com$";
            foreach (var q in qqArr)
            {
                var isQq= Regex.IsMatch(q, qqZz);
                if (isQq)
                {
                    list.Add(q);
                }
                else
                {
                    Console.WriteLine("输入信息有误请重新输入");
                    GetToArr();
                }
            }
            return list.ToArray();
        }
    }
}


