using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Data;
using System.Xml.Linq;
using Assembly学习v;

namespace Assembly学习
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(typeof(int).Assembly.FullName);
            Console.WriteLine(typeof(XmlDocument).Assembly.FullName);
            Console.WriteLine(typeof(DataSet).Assembly.FullName);

            var tmp = @"<array><img src='http://192.168.0.220:8899/a12dd147-6048-43e3-806d-2b347fe58cb5/C/201703/2e8a04f472a14b55a5ba6310b38cea63-0bbb1d4b322747feb1a7e59f7b7c4714-00.jpg' width='100%' />
<img src='http://192.168.0.220:8899/a12dd147-6048-43e3-806d-2b347fe58cb5/C/201703/2e8a04f472a14b55a5ba6310b38cea63-ccdcac9578a04805bf4c333a48acc0e6-01.jpg' width='100%' />
<img src='http://192.168.0.220:8899/a12dd147-6048-43e3-806d-2b347fe58cb5/C/201703/2e8a04f472a14b55a5ba6310b38cea63-3abfe5a6dfdd44648f9c4292376d00eb-02.jpg' width='100%' /></array>";

            var element = XElement.Parse(tmp);

            var array = element.Elements().Select(el => el.ToString()).ToArray();

            XmlHelper xmlHelp = new XmlHelper();
            var temp = xmlHelp.GetAppValueByKey("ConnectionString");
            var te = xmlHelp.LinqToXml("appsettings", "add","ConnectionString");
            Console.WriteLine(temp);
            Console.WriteLine(te);
            Console.ReadKey();
           
        }
    }
}
