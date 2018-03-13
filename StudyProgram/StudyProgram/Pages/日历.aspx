<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="日历.aspx.cs" Inherits="StudyProgram.Pages.日历" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .GridViewStyle
        {
            width: 100%;
            height: 1%;
            border-collapse: collapse;
        }
        .GridViewHeaderStyle
        {
            background: url(images/biaotbg.gif) repeat-x bottom;
            height: 23px;
            line-height: 23px;
            color: #0062af;
            font: 12px "宋体" , arial,sans-serif;
        }
        .GridViewRowStyle
        {
            background-color: #fff; /* color: #303030;*/
            height: 24px;
            line-height: 24px;
            border: 1px solid #eaeaea;       
            border-top: 0px;
            border-right: 0px;
            text-align: center;
            padding-top: 2px;
            font: 13px "宋体" , arial,sans-serif;
        }
        .table
        {
            font: 14px "宋体" ,arial,sans-serif;
            border-collapse: collapse;
            line-height: 24px;
            height: 24px;
        }
        
        .table tr
        {
            font: 14px "宋体" ,arial,sans-serif;
            border: 1px solid black;
            line-height: 24px;
            height: 24px;
            text-align: center;
        }
        .table tr td
        {
            border: 1px solid black;
            width: 120px;
        }
        .style1
        {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 50%; margin: 10px auto;">
        <asp:GridView ID="GridView1" runat="server" class="GridViewStyle">
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <RowStyle CssClass="GridViewRowStyle" />            
        </asp:GridView>
    </div>
    <table class="table">
        <tr>
            <td>
                学号
            </td>
            <td>
                姓名
            </td>
            <td>
                年龄
            </td>
            <td>
                性别
            </td>
        </tr>
      <%--  <%#Eval("sortid")%>#表示绑定循环的数据   <%=Eval("sortid")%>=表示固定的字段--%>
        <asp:Repeater ID="rept" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <%#Eval("xh") %>
                    </td>
                       <td>
                        <%#Eval("xm") %>
                    </td>
                     <td>
                        <%#Eval("nl") %>
                    </td>
                    <td>
                        <%#Eval("xb") %>
                    </td>
                </tr>          
            </ItemTemplate>
        </asp:Repeater>
    </table>
    </form>
</body>
</html>
