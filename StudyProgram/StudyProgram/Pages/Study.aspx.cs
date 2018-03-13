using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
#pragma  warning disable
namespace StudyProgram.Pages
{
    public partial class Study : System.Web.UI.Page
    {
        public static string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();
        }

        public void BindData()
        {
            var sqlStr = "select * from tb_Student where @term=@value";
            //var my_ds = Common.ComomHelper.ExecuteDataset(sqlStr);
            //var my_ds = Common.DBHelper.ExecuteDataset(ConnectionString, CommandType.Text, sqlStr);
            var proName = "pro_SelectStudent";
            SqlParameter[] my_params = new SqlParameter[2];
            my_params[0] = new SqlParameter("@term", SqlDbType.VarChar, 10);
            my_params[1] = new SqlParameter("@value", SqlDbType.VarChar, 1000);
            my_params[0].Value = "1";
            my_params[1].Value = "1";
            var my_ds = Common.DBHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, proName, my_params);
            dataGrid.DataSource = my_ds.Tables[0];
            dataGrid.DataBind();
        }
        //修改     
        protected void dataGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dataGrid.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }
        //取消
        protected void dataGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            this.AddOrEditBind();
        }
        //更新，新增
        protected void dataGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            var index = e.Item.ItemIndex;
            if (dataGrid.EditItemIndex >= 0 && index < dataGrid.Items.Count)//修改，update
            {
                var lblId = (Label)e.Item.FindControl("lblId");
                var txtName = (TextBox)e.Item.FindControl("txtName");
                var txtSex = (TextBox)e.Item.FindControl("txtSex");
                var sqlStr = "update tb_Student set Name=@txtName,Sex=@txtSex where Id=@Id ";
                SqlParameter[] my_params ={
                                         new SqlParameter("@txtName",txtName.Text.Trim()),
                                         new SqlParameter("@txtSex",txtSex.Text.Trim()),
                                         new SqlParameter("@Id",lblId.Text),
                                         };
                var reslt = Common.ComomHelper.ExecuteNonQuery(sqlStr, my_params);//自己要在此处判断是否为0，0的时候执行错误               
            }
            else
            { //add
                var txtName = (TextBox)e.Item.FindControl("txtFootName");
                //var txtSex = (TextBox)e.Item.FindControl("txtFootSex");
                var txtSex = (DropDownList)e.Item.FindControl("dropSex");
                var txtAge = (TextBox)e.Item.FindControl("txtFootAge");
                var sqlStr = "insert into tb_Student select @txtName,@txtAge,@txtSex";
                SqlParameter[] my_params = new SqlParameter[3];
                my_params[0] = new SqlParameter("@txtName", txtName.Text.Trim());
                my_params[1] = new SqlParameter("@txtAge", txtAge.Text.Trim());
                my_params[2] = new SqlParameter("@txtSex", txtSex.SelectedValue);
                var reslt = Common.ComomHelper.ExecuteNonQuery(sqlStr, my_params); //自己要在此处判断是否为0，0的时候执行错误                                                       
            }
            this.AddOrEditBind();
        }

        //编辑或者新增、更新时候的绑定
        public void AddOrEditBind()
        {
            dataGrid.EditItemIndex = -1;
            BindData();
        }
    }
}