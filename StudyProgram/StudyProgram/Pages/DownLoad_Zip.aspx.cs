using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using Newtonsoft.Json;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;

namespace StudyProgram.Pages
{
    public partial class DownLoad_Zip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var method = Request["method"];
            if (method != null)
            {
                try
                {
                    var obj = this.GetType().GetMethod(method, BindingFlags.Public | BindingFlags.Instance).Invoke(this, null);
                    if (obj != null)
                        Response.Write(obj);
                }
                catch (Exception ex)
                {
                    Response.Write(JsonConvert.SerializeObject(ex));
                }
                Response.End();
            }
        }
        protected void btn_down_Click(object sender, EventArgs e)
        {
            var name = Server.MapPath("huage");
            //if (!Directory.Exists(name))
            //    throw new FileNotFoundException("")
            var zipName = "test";
            DownZip(name, zipName,9);             
        }
        private void DownZip(string dirname, string zipfile, int level = 6, string password = "")
        {
            MemoryStream ms = new MemoryStream();//支持存储区为内存的流
            ZipOutputStream zos = new ZipOutputStream(ms);
            if (password != "")
                zos.Password = password;

            zos.SetLevel(level);
            AddZipEntry(dirname, zos, dirname);          
            zos.Finish();
            zos.Close();          
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlDecode(zipfile,System.Text.Encoding.UTF8) + ".zip");
            Response.BinaryWrite(ms.ToArray());
            ms.Close();
            Response.Flush();
            Response.End();
        }
        private void AddZipEntry(string strPath, ZipOutputStream zos, string baseDirName)
        {
            DirectoryInfo dir = new DirectoryInfo(strPath);
            foreach (FileSystemInfo item in dir.GetFileSystemInfos())
            {
                if ((item.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    AddZipEntry(item.FullName, zos, baseDirName);
                }
                else
                {
                    FileInfo f_item = (FileInfo)item;
                    using (FileStream fs = f_item.OpenRead())
                    {
                        byte[] buffer = new byte[(int)fs.Length];
                        fs.Read(buffer, 0, buffer.Length);
                        ZipEntry entry = new ZipEntry(f_item.FullName.Replace(baseDirName, ""));
                        zos.PutNextEntry(entry);
                        zos.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}