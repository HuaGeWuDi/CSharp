<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="缓存Test.aspx.cs" Inherits="StudyProgram.Pages.缓存Test" %>

<%@ OutputCache Duration="10" VaryByParam="none" %>  <%--设置页面缓存，Duration 缓存时间  VaryByParam 参数--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            我是华哥</h1>
        <asp:Label ID="Label1" runat="server"><%=DateTime.Now.ToString() %></asp:Label>
    </div>
    </form>
</body>
</html>
