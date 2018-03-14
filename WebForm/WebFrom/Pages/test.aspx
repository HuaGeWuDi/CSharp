<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebFrom.Pages.test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Content/Scripts/JQuery-1-10-2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="test" type="button" value="test" onclick="fnGetMsg()" />
    </div>
    </form>
    <script>
        function fnGetMsg() {
            var msg = $("#test").val();
            $.post("../../Test/GetMsg", { msg: msg }, function (data) {
                if (data)
                    alert(data);
            });
        }
    </script>
</body>
</html>
