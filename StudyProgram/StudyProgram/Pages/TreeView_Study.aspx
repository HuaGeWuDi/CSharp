<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeView_Study.aspx.cs"
    Inherits="StudyProgram.Pages.TreeView_Study" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/easyui/themes/material/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../Content/easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/JQuery-1-10-2.js" type="text/javascript"></script>
    <script src="../Content/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {

            //   $("#tt").tree({
            //   url: "treeJson.json",
            //   method: "get"
            //  });

            $.ajax({
                url: "?act=GetTreeJson1",
                type: 'post',
                dataType: 'json',
                success: function (data) {
                    //alert("Sb");
                    console.log(data);
                    if (data != "")
                        $("#tt").tree({
                            data: data
                        });
                },
                error: function (data) {

                }
            });
        });

        //checkbox点击事件
        function OnCheckEvent() {
            var objNode = event.srcElement;
            if (objNode.tagName != "INPUT" || objNode.type != "checkbox")
                return;
            //获得当前树结点
            var ck_ID = objNode.getAttribute("ID");
            var node_ID = ck_ID.substring(0, ck_ID.indexOf("CheckBox")) + "Nodes";
            var curTreeNode = document.getElementById(node_ID);
            //级联选择
            SetChildCheckBox(curTreeNode, objNode.checked);
            SetParentCheckBox(objNode);
        }

        //子结点字符串
        var childIds = "";
        //获取子结点ID数组
        function GetChildIdArray(parentNode) {
            if (parentNode == null)
                return;
            var childNodes = parentNode.children;
            var count = childNodes.length;
            for (var i = 0; i < count; i++) {
                var tmpNode = childNodes[i];
                if (tmpNode.tagName == "INPUT" && tmpNode.type == "checkbox") {
                    childIds = tmpNode.id + ":" + childIds;
                }
                GetChildIdArray(tmpNode);
            }
        }

        //设置子结点的checkbox
        function SetChildCheckBox(parentNode, checked) {
            if (parentNode == null)
                return;
            var childNodes = parentNode.children;
            var count = childNodes.length;
            for (var i = 0; i < count; i++) {
                var tmpNode = childNodes[i];
                if (tmpNode.tagName == "INPUT" && tmpNode.type == "checkbox") {
                    tmpNode.checked = checked;
                }
                SetChildCheckBox(tmpNode, checked);
            }
        }

        //设置父结点的checkbox
        function SetParentCheckBox(childNode) {
            if (childNode == null)
                return;
            var parent = childNode.parentNode;
            if (parent == null || parent == "undefined")
                return;
            do {
                parent = parent.parentNode;
            }
            while (parent && parent.tagName != "DIV");
            if (parent == "undefined" || parent == null)
                return;
            var parentId = parent.getAttribute("ID");
            var objParent;
            if (parentId != "") {
                objParent = document.getElementById(parentId);
                childIds = "";
                GetChildIdArray(objParent);
            }
            //判断子结点状态
            childIds = childIds.substring(0, childIds.length - 1);
            var aryChild = childIds.split(":");
            var result = false;
            //当子结点的checkbox状态有一个为true，其父结点checkbox状态即为true,否则为false
            for (var i in aryChild) {
                var childCk = document.getElementById(aryChild[i]);
                if (childCk != null && childCk.checked)
                    result = true;
            }
            if (parentId != null) {
                parentId = parentId.replace("Nodes", "CheckBox");
                var parentCk = document.getElementById(parentId);
                if (parentCk == null)
                    return;
                if (result)
                    parentCk.checked = true;
                else
                    parentCk.checked = false;
                SetParentCheckBox(parentCk);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="SysModuleTree" runat="server" ShowCheckBoxes="All" ImageSet="Arrows">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="微软雅黑" Font-Size="12pt" ForeColor="Black" HorizontalPadding="5px"
                NodeSpacing="0px" VerticalPadding="0px" />
            <%--根--%>
            <ParentNodeStyle Font-Bold="False" ForeColor="Blue" />
            <%--父级--%>
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                VerticalPadding="0px" />
            <%--叶子--%>
        </asp:TreeView>
        <br />
        <br />
        <asp:TreeView ID="Treeview1" runat="server" ShowCheckBoxes="All" ImageSet="Arrows"
            CssClass="TreeMenu">
            <HoverNodeStyle ForeColor="#5555DD" />
            <NodeStyle Font-Names="微软雅黑" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                NodeSpacing="0px" VerticalPadding="0px" />
            <RootNodeStyle Font-Bold="True" />
            <ParentNodeStyle Font-Bold="True" ForeColor="#653CFC" />
            <SelectedNodeStyle ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
        <br />
        <br />
        <ul id="tt">
        </ul>
        <%--<ul id="Ul1" class="easyui-tree">
            <li><span>Folder</span>
                <ul>
                    <li><span>Sub Folder 1</span>
                        <ul>
                            <li><span><a href="#">File 11</a></span></li>
                            <li><span>File 12</span></li>
                            <li><span>File 13</span></li>
                        </ul>
                    </li>
                    <li><span>File 2</span></li>
                    <li><span>File 3</span></li>
                </ul>
            </li>
            <li><span>File21</span></li>
        </ul>--%>
    </div>
    </form>
</body>
</html>
