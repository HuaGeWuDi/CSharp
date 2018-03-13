using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudyProgram.Pages
{
    public partial class test_AutoPostBack_UpdatePanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Textbox1_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            var txt_text = txt.Text.Trim().Split(' ')[0];//获取修改后的文本(不包括后面的时间)
            txt.Text = txt_text + " " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");//设置文本
        }
    }
}