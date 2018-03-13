
//public static string GetTreeJsonByTable(DataTable tabel, string idCol, string txtCol, string rela, string pId)
//{
//    StringBuilder result = new StringBuilder();
//    StringBuilder sb = new StringBuilder();
//    result.Append(sb.ToString());
//    sb.Clear();
//    if (tabel.Rows.Count > 0)
//    {
//        sb.Append("[");
//        string filer = string.IsNullOrEmpty(pId) ? rela + " is null " : string.Format("{0}='{1}'", rela, pId);
//        DataRow[] rows = tabel.Select(filer);
//        if (rows.Length > 0)
//        {
//            foreach (DataRow row in rows)
//            {
//                sb.Append("{\"id\":\"" + row[idCol] + "\",\"text\":\"" + row[txtCol] + "\",\"state\":\"open\"");
//                if (tabel.Select(string.Format("{0}='{1}'", rela, row[idCol])).Length > 0)
//                {
//                    sb.Append(",\"children\":");
//                    GetTreeJsonByTable(tabel, idCol, txtCol, rela, row[idCol] + "");
//                    result.Append(sb.ToString());
//                    sb.Clear();
//                }
//                result.Append(sb.ToString());
//                sb.Clear();
//                sb.Append("},");
//            }
//            sb = sb.Remove(sb.Length - 1, 1);
//        }
//        sb.Append("]");
//        result.Append(sb.ToString());
//        sb.Clear();
//    }
//    return result.ToString();
//}

//public static string GetTreeJsonByList(List<Tree> treeList, string pid)
//{
//    var list = treeList.Where(c => string.IsNullOrEmpty(pid) ? string.IsNullOrEmpty(c.p_id) : c.p_id == pid).ToList();
//    foreach (var ll in list)
//    {
//        var child = list.Where(c => c.p_id == ll.id).ToList();
//    }

//    return "";
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;

namespace StudyProgram.Common
{

    /// <summary>
    /// Tree帮助类
    /// </summary>
    public class TreeHelper
    {

      

        /// <summary>
        /// 获取EasyUi——tree的JSON格式
        /// </summary>
        /// <param name="tabel">数据</param>
        /// <param name="pid">父Id的字段名</param>
        /// <param name="id">id的字段名</param>
        /// <param name="text">文本字段名</param>
        /// <param name="p_val">根节点的父Id的值（0或者null等等）</param>
        /// <returns></returns>
        public static string GetTreeJsonTest(DataTable tabel, string pid, string id, string text, string p_val)
        {
            List<Tree> list = new List<Tree>();

            string filer = string.IsNullOrEmpty(p_val) ? pid + " is null " : string.Format("{0}='{1}'", pid, p_val);
            DataRow[] rows = tabel.Select(filer);//筛选出根节点
            foreach (DataRow dr in rows)
            {
                Tree tree = new Tree();
                tree.id = dr[id] + "";
                tree.p_id = dr[pid] + "";
                tree.text = dr[text] + "";
                tree.children = GetChild(tree, tabel, pid, id, text);//获取子节点
                list.Add(tree);
            }
            return JsonConvert.SerializeObject(list);//转JSON
        }

        /// <summary>
        /// 获取子节点
        /// </summary>
        /// <param name="node">父节点</param>
        /// <param name="dt">数据源</param>
        /// <param name="pid">父Id的字段名</param>
        /// <param name="id">id的字段名</param>
        /// <param name="text">文本字段名</param>     
        /// <returns></returns>
        private static List<Tree> GetChild(Tree node, DataTable dt, string pid, string id, string text)
        {
            List<Tree> lst = new List<Tree>();
            DataRow[] rows = dt.Select(pid + " = " + node.id);//筛选pid为父节点的Id的节点（即父节点node的所有子节点）
            foreach (var row in rows)
            {
                Tree n = new Tree();
                n.id = row[id] + "";
                n.text = row[text] + "";
                n.p_id = row[pid] + "";
                lst.Add(n);
                DataRow[] dr = dt.Select(pid + "=" + n.id);
                if (dr.Length > 0)
                    n.children = GetChild(n, dt, pid, id, text);
            }
            return lst;
        }


        /// <summary>
        /// List转EasyUi_tree格式
        /// </summary>
        /// <param name="lstData"></param>
        /// <param name="p_val"></param>
        /// <returns></returns>
        public static List<Tree> GetTreeJsonByList(List<Data> lstData, string p_val)
        {
            List<Tree> lstTree = new List<Tree>();
            if (lstData != null)
            {
                var lstRoot = lstData.Where(c => string.IsNullOrEmpty(p_val) ? c.P_id == null : c.P_id == Convert.ToInt32(p_val)).ToList();//找到根节点
                foreach (var ll in lstRoot)
                {
                    Tree tree = new Tree();
                    tree.id = ll.Id + "";
                    tree.p_id = ll.P_id + "";
                    tree.text = ll.Text;
                    tree.children = GetTreeJsonByList(lstData, ll.Id + "");
                    lstTree.Add(tree);
                }
            }
            return lstTree;
        }

        /// <summary>
        /// DataTable转List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ConvertToList<T>(DataTable dt) where T : new()
        {
            List<T> list = new List<T>();
            PropertyInfo[] props = typeof(T).GetProperties();

            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                foreach (PropertyInfo pro in props)
                {
                    if (dt.Columns.Contains(pro.Name))
                    {
                        if (!pro.CanWrite) continue;//属性不能写入,直接写入下个属性
                        object obj = dr[pro.Name];
                        if (obj != DBNull.Value)
                            pro.SetValue(t, obj, null);
                    }
                }
                list.Add(t);
            }
            return list;
        }

        /// <summary>
        /// List转DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(List<T> list) where T : new() //在方法前面定义T，后面Where作为泛型约束
        {
            DataTable dt = new DataTable();
            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (var p in props)
                dt.Columns.Add(p.Name, p.Name.GetType());

            foreach (var t in list)
            {
                DataRow n_row = dt.NewRow();
                foreach (var p in props)
                    n_row[p.Name] = p.GetValue(t, null);

                dt.Rows.Add(n_row);
            }
            return dt;
        }
    }


    public class Tree
    {
        public string id { get; set; }
        public string text { get; set; }
        public string p_id { get; set; }//父id可以不需要
        //public string iconCls
        //{
        //    get { return "icon-save"; }//设置Tree的图标，默认是文件夹
        //}
        public List<Tree> children { get; set; }
    }


    public class Data
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? P_id { get; set; }//父id可以不需要       
    }
}