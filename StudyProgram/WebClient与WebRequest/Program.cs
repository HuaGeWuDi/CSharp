using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudyProgram.LeiKu;
using System.Net;

namespace WebClient与WebRequest
{
    class Program : ClientHelper
    {
        public static string url = "http://www.webservicex.net/globalweather.asmx";
        static void Main(string[] args)
        {

            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var str = client.DownloadString(new Uri("http://www.baidu.com"));
            //WebClient
            //ClientHelper client = new ClientHelper();

            //List<KValue> kValue = new List<KValue>()
            //{
            //    new KValue() { Key = "CountryName", Value = "China" }
            //};
            //client.Url = url + "/GetCitiesByCountry";
            //client.lstKV = kValue;
            //var cres=client.GetData();
            //Console.WriteLine(client.PostData());
            ////client.GetDataAsync();

            ClientHelper client1 = new ClientHelper();
            client1.Url = url + "/GetCitiesByCountry?CountryName=China";

            Console.WriteLine(client1.PostData());






            //HttpWebRequest适合传输数据（一般为JSON字符串），试用于Web Api
            RequestHelper helper = new RequestHelper();
            var methodname = "GetCitiesByCountry";
            var gUurl = url + "/" + methodname + "?CountryName=China";
            helper.Url = gUurl;
            var res = helper.GetResult();
            Console.WriteLine(res);


            //var pUrl = url + "/" + methodname;
            //helper.Url = pUrl;
            //helper.paramStr = "China";
            //var rr=helper.PostResult();

            //var testUrl = "http://localhost:37603/WebService/test.asmx/testWeb?str=wudi";
            //helper.Url = testUrl;
            //res = helper.GetResult();
            //Console.WriteLine(res);

            Console.ReadLine();
        }
    }
}
