<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="多个Table.aspx.cs" Inherits="StudyProgram.Pages.多个Table" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/JQuery-1-10-2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td colspan="2">
                    <%=pageTitle %>
                </td>
            </tr>
            <tr>
                <td>
                    序号
                </td>
                <td>
                    内容
                </td>
            </tr>
            <% int i = 1;
               foreach (var a in strArr)
               { 
            %>
            <tr>
                <td>
                    <%= i %>
                </td>
                <td>
                    <%=a %>
                </td>
            </tr>
            <%if (i % 5 == 0)
              {%>
        </table>
        <table id='tab_<%=i %>'>
            <tr>
                <td colspan="2">
                    <%=pageTitle%>
                </td>
            </tr>
            <tr>
                <td>
                    序号
                </td>
                <td>
                    内容
                </td>
            </tr>
            <%}
              i++;
               } %>
        </table>
    </div>
    </form>
    <script type="text/javascript">
        $(function () {
            var tables = $("table");//获取所有table
            for (var i = 0; i < tables.length; i++) {
                var trs = $("tr", $(tables[i]));//获取该table下面的所有行
                if (trs.length<3) {//tables的第三行如果没有的话，则该table消失
                    $(tables[i]).css("display", "none");
                }
            }
        });
    </script>
</body>
</html>
