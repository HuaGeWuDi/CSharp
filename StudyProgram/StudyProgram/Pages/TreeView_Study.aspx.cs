using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using StudyProgram.Common;
using Newtonsoft.Json;

namespace StudyProgram.Pages
{
    public partial class TreeView_Study : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            var act = Request["act"];
            if (act != null)
            {
                try
                {
                    var res = GetType().GetMethod(act, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Invoke(this, null);
                    if (res != null)
                        Response.Write(res);
                }
                catch (Exception ex)
                {
                    Response.Write(JsonConvert.SerializeObject(ex));
                }
                Response.End();
            }
            if (!IsPostBack)
            {
                var dt = GetDataTable();
                Treeview1.Attributes.Add("onClick", "OnCheckEvent()");
                TreeBind(SysModuleTree, dt, null, null, "Id", "P_id", "Text");
                TreeBind2(dt, Treeview1.Nodes, null, "Id", "P_id", "Text");
                var aa = GetTreeJson(dt);
                Response.Write(GetTreeJsonByList(dt)+"<br/>");

                var start = (DateTime)Application["starttime"];
                var js = DateTime.Now - start;
                Response.Write("页面执行时间" + js.Milliseconds + "毫秒");
            }

        }

        void TreeBind(TreeView treeView, DataTable dt, TreeNode p_Node, string pid_val, string id, string pid, string text)
        {
            DataView dv = dt.DefaultView;
            TreeNode tn;
            string filter = string.IsNullOrEmpty(pid_val) ? pid + " is null" : string.Format(" {0} ={1} ", pid, pid_val);
            dv.RowFilter = filter;//DV的筛选数据比DataTable好
            foreach (DataRowView row in dv)
            {
                tn = new TreeNode();
                tn.Value = row[id] + "";
                tn.Text = row[text] + "";
                if (p_Node == null) //添加跟节点
                    treeView.Nodes.Add(tn);
                else
                    p_Node.ChildNodes.Add(tn);//添加子节点

                TreeBind(treeView, dt, tn, tn.Value, id, pid, text);//递归 绑定节点下面的子节点中的子节点
            }
        }

        void TreeBind2(DataTable dt, TreeNodeCollection tnc, string pid_val, string id, string pid, string text)
        {
            DataView dv = dt.DefaultView;
            TreeNode tn;
            string filter = string.IsNullOrEmpty(pid_val) ? pid + " is null" : string.Format(pid + "='{0}'", pid_val);
            dv.RowFilter = filter;//筛选数据
            foreach (DataRowView drv in dv)
            {
                tn = new TreeNode();//建立一个新节点 
                tn.Value = drv[id].ToString();  
                tn.Text = drv[text].ToString();   
                tnc.Add(tn);//将该节点加入到TreeNodeCollection（节点集合）中     
                TreeBind2(dt, tn.ChildNodes, tn.Value, id, pid, text);//递归
            }
        }

        DataTable GetDataTable()
        {
            string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            return DBHelper.ExecuteDataset(ConnectionString, CommandType.Text, " SELECT * FROM [dbo].[T_Tree] ").Tables[0];
        }

        public string GetTreeJson1()
        {
            DataTable dt = GetDataTable();
            return TreeHelper.GetTreeJsonTest(dt, "P_id", "Id", "Text", null);
        }

        string GetTreeJson(DataTable dt)
        {
            return TreeHelper.GetTreeJsonTest(dt, "P_id", "Id", "Text", null);
        }

        string GetTreeJsonByList(DataTable dt)
        {
            List<Data> list = TreeHelper.ConvertToList<Data>(dt);
            DataTable dtTest = TreeHelper.ConvertToDataTable<Data>(list);
            var lisTree = TreeHelper.GetTreeJsonByList(list, null);
            return JsonConvert.SerializeObject(lisTree);
        }
    }
}