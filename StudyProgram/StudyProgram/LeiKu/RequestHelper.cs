using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;
#pragma warning disable 1591

namespace StudyProgram.LeiKu
{
    public class RequestHelper
    {
        public string Url { get; set; }

        public string paramStr = "";//需要的JSON参数

        public Encoding dataEncode = Encoding.UTF8;//编码方式

        public RequestHelper() { }

        public string GetResult()
        {
            var res = "";
            try
            {
                //这边的URL就需要把参数拼接好（如MesssageHelper里面的参数   var targetUrl = url + userid + key + smsMob + smsText;）
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "Get";
                request.Timeout = 60 * 1000;//60秒超时
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, dataEncode);
                res = reader.ReadToEnd();
                response.Close();
                stream.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            return res;
        }

        public void GetResultAsync()
        {
            var res = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "Get";
            request.Timeout = 60 * 1000;
            request.BeginGetResponse(new AsyncCallback(ReadCallback), request);
        }

        public virtual void ReadCallback(IAsyncResult async)//这边可以重写该方法，进行一步处理数据
        {
            HttpWebRequest request = (HttpWebRequest)async.AsyncState;
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(async);
            Stream stream = response.GetResponseStream();//获得数据
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            var res = reader.ReadToEnd();//读取数据成string（一般为json）（数据到手后的操作，这边重写）
            //Dispatcher.BeginInvoke()跟界面进行通讯。//这边通过该方法，跟前端页面进行联系
            response.Close();
            stream.Close();
            reader.Close();//最后需要关闭继承IDisposable接口的的类来释放资源
        }

        public string PostResult()
        {
            var res = "";
            if (string.IsNullOrEmpty(paramStr))
                throw new ApplicationException("接口传输参数为空");

            try
            {
                byte[] byteParm = dataEncode.GetBytes(paramStr);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(Url));
                request.Method = "Post";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteParm.Length;
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(byteParm, 0, byteParm.Length);//写入参数
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), dataEncode))
                    {
                        res = reader.ReadToEnd();
                    }
                }
                reqStream.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message, ex);
            }
            return res;
        }


    }
}