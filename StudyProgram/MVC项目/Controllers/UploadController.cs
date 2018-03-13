using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MVC项目.Controllers
{
    public class UploadController :System.Web.Mvc.Controller
    {
        public string uplodFile()
        {
            var result = "";
            HttpRequest request = System.Web.HttpContext.Current.Request;
            HttpFileCollection files = request.Files;
            if (files.Count > 0)
            {
                var file = files[0];//一次上传一个文件
                if (file.ContentLength > 0)
                {
                    var path = Server.MapPath("../uploadfiles");
                    if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                    var conbineName = Path.Combine(path, file.FileName);
                    file.SaveAs(conbineName);
                    result = "上传成功";
                }
                else
                    result = "文件不能能为空";
            }
            else
                result = "文件不能能为空";
            return result;
        }

        public void dowmLoad()
        {
            var path = Server.MapPath("../uploadfiles");
            var files = Directory.GetFiles(path);
            if (files.Count() > 0)
            {
                var fileUrl = files[0];//下载第一个
                var urlArr = fileUrl.Split('\\');
                var fileName = urlArr[urlArr.Length - 1];
                var response = HttpContext.Response;
                response.Clear();
                response.ContentType = "application/octet-stream";
                response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fileName, System.Text.UnicodeEncoding.UTF8));
                response.TransmitFile(fileUrl);//这个方法不在内存中，不需要flush         
            }
        }
    }
}
