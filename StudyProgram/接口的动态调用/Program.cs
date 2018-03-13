using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 接口的动态调用
{
    class Program
    {
        static void Main(string[] args)
        {
            WebServiceHelper webSerHelper = new WebServiceHelper();
            string url = "http://www.webservicex.net/globalweather.asmx";
            args = new string[1];
            args[0] = "China";
            var methodname = "GetCitiesByCountry";
            var obj = webSerHelper.InvokeWebService(url, methodname, args);
            Console.WriteLine(obj + "");

            args = new string[2];
            args[0] = "China";
            args[1] = "Beijing";
            methodname = "GetWeather";
            var obj1 = webSerHelper.InvokeWebService(url, methodname, args);
            Console.WriteLine(obj1 + "");
            Console.ReadKey();
        }
    }
}
