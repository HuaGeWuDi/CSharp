using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 抛出异常
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = 2; var b = 0;

            //var ss = "" ?? "1";

            //Console.WriteLine (ss);
            //try
            //{
            //    Console.WriteLine(a / b);
            //}
            //catch (Exception ex)
            //{

            //    //throw new ApplicationException("数据异常" + ex.Message);
            //    Console.WriteLine("数据错误:" + ex.Message+ex.StackTrace);
            //}
            //Console.ReadKey();9
            //var mySoap = new StudyProgram.WebService.MyWebService();
            //HellowWord.MyWebService service = new HellowWord.MyWebService();
            //var aa=service.HelloWorld(null);


           var arr= DateTime.Parse(null).ToString("yyyy-MM-dd");

            test.MyWebService my_service = new test.MyWebService();
            test.MySoapHeader my_soap = new test.MySoapHeader();
            Console.WriteLine("请输入用户名");
            var UserName = Console.ReadLine().Trim();
            Console.WriteLine("请输入密码");
            var PassWord = Console.ReadLine().Trim();
            my_soap.Name = UserName;
            my_soap.Password = PassWord;
            var res=my_service.HelloWorld(my_soap);

            Console.WriteLine(res);
            Console.ReadKey();           
        }

    }
}
