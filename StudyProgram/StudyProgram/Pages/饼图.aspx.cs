using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using StudyProgram.LeiKu;

namespace StudyProgram.Pages
{
    public partial class 饼图 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ImageAss();
            }
        }

        public void ImageAss()
        {
            string[] strArr = { "zhangs", "lisi", "wangw" };
            decimal[] demArr = { 0.88M, 0.11M, 0.01M };
            decimal[] demArr1 = { 88M, 11M, 1M };
            var image = DrawImage.GetPieImage("无敌",strArr, demArr);
            var zimage = DrawImage.GetColumnImage("huage", strArr, demArr1);
            var path = Server.MapPath("huage");
            if (!Directory.Exists(path)) //创建文件夹的时候用绝对路径     
                Directory.CreateDirectory(path);

            image.Save(path+"/wudi.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
            zimage.Save(path + "/huage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            Image1.ImageUrl = "huage/wudi.jpg";
        }
    }
}