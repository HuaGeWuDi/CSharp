using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Assembly学习v
{
    public class XmlHelper
    {
        //XML操作,JS操作文件
        private string xmlPath = @"D:\程序文件\VS2010学习\StudyProgram\StudyProgram\Web.config";

        public string GetAppValueByKey(string key)
        {
            var res = "";         
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(@"D:\程序文件\VS2010学习\StudyProgram\Assembly学习\cfHelper.xml");
            XmlNode xRoot = xmldoc.SelectSingleNode("configuration");//    //获得第一个姓名匹配的节点（SelectSingleNode）：此xml文件的根节点
            XmlNodeList xmlList = xRoot.ChildNodes;
            foreach (XmlNode a in xmlList)
            {
                if (a.Name.ToLower() == "appsettings")
                {
                    var aa = a.ChildNodes;
                    if (aa != null)
                    {
                        foreach (XmlNode aaa in aa)
                        {
                            if (aaa != null)
                            {
                                if (aaa.Attributes != null)
                                {
                                    if (aaa.Attributes["key"].Value == key)
                                    {
                                        res = aaa.Attributes["value"].Value;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return res;
        }

        public string LinqToXml(string parentName, string childName, string key)
        {
            XElement rootNode = XElement.Load(xmlPath);

            var targetnode = from t in rootNode.Descendants(parentName).Elements(childName)
                             //where t.Attribute("key").Value.Equals(key) && t.HasElements
                             select new
                             {
                                 key=t.Attribute("key").Value,
                                 value=t.Attribute("value").Value
                             };

            //var resnode = targetnode.Where(c => c.Attribute("key").Value == key).FirstOrDefault();

            var resnode = targetnode.Where(c => c.key.Equals(key)).FirstOrDefault();

            return resnode==null?"":resnode.value;
        }
    }
}
