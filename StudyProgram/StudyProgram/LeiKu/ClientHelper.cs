using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

namespace StudyProgram.LeiKu
{
    public class ClientHelper
    {
        public ClientHelper() { }
        public string Url = "";
        public List<KValue> lstKV = null;//参数（键值对）
        public string Result;

        //Get请求方式
        public string GetData()
        {
            var res = "";
            WebClient client = new WebClient();
            //client.Headers.Add(HttpRequestHeader.ContentType, "text/plain");
            //client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.Headers.Add(HttpRequestHeader.ContentType, "text/xml");
            if (lstKV != null)
            {
                foreach (var k in lstKV)
                    client.QueryString[k.Key] = k.Value;
            }
            try
            {
                using (Stream stream = client.OpenRead(Url))
                {
                    using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default))
                    {
                        res = reader.ReadToEnd();
                    }
                }
                client.Dispose();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            return res;
        }

        public void GetDataAsync()//异步是不用等待数据传输
        {
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
            if (lstKV != null)
            {
                foreach (var k in lstKV)
                    client.QueryString[k.Key] = k.Value;
            }
            try
            {
                //绑定事件，为了获取返回值（读取完成事件）
                client.OpenReadCompleted += new OpenReadCompletedEventHandler(OpenReadCallBack);
                //异步提交，不用等待
                client.OpenReadAsync(new Uri(Url));

            }
            catch (Exception ex)
            {

                throw new ApplicationException(ex.Message, ex);
            }
        }


        //这边是测试的回调函数//该回调函数为了接收返回值
        public void OpenReadCallBack(Object sender, OpenReadCompletedEventArgs e)
        {
            using (var stream = e.Result)
            {
                using (StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default))
                {
                    var res = reader.ReadToEnd();
                }
            }
        }


        //Post(需要在URL上把参数传过来（?）)
        public string PostData()
        {
            var res = "";
            WebClient client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
            var urlArr = Url.Split('?');
            byte[] data = System.Text.Encoding.Default.GetBytes(urlArr[1]);
            var byteRes= client.UploadData(Url,"POST", data);
            res = System.Text.Encoding.Default.GetString(byteRes);
            client.Dispose();
            return res;
            //client.DownloadString("")
        }

    }

    public class KValue
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}