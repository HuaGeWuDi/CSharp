using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;

namespace StudyProgram.Pages
{
    public partial class DatatableToJson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Age", typeof(int));
            dt.Columns.Add("Sex", typeof(string));
            var dr = dt.NewRow();
            dr["Name"] = "huage";
            dr["Age"] = 18;
            dr["Sex"] = "男";
            dt.Rows.Add(dr);
            var tabJson = JsonConvert.SerializeObject(dt);
            //已经过时
            //this.RegisterStartupScript("alert", "<script>alert('" + tabJson + "')</script>");
            this.ClientScript.RegisterStartupScript(this.GetType(), "aa", "<script>alert('" + tabJson + "')</script>");
            var tempTab = JsonConvert.DeserializeObject<DataTable>(tabJson);
        }
    }
}