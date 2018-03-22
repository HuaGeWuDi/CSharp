<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownLoad_Zip.aspx.cs" Inherits="StudyProgram.Pages.DownLoad_Zip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/JQuery-1-10-2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btn_down" runat="server" Text="下载" OnClick="btn_down_Click" />
        <input type="button" value="Open下载" onclick="fnOpenGetFile()" />
        <input type="button" value="Form下载" onclick="fnFormGetFile()" />
        <input type="button" value="Href下载" onclick="fnHrefGetFile()" />
    </div>
    </form>
    <script>
        function fnOpenGetFile() {
            //方法一：通过Windows.open();
            //    window.open("../../Images/test.doc");
            window.open("huage/huage.jpg"); //图片下载不行
        }

        function fnFormGetFile() {
            //方法二：通过form
            var $eleForm = $("<form method='get'></form>");

            //  $eleForm.attr("action", "../../Images/test.doc");
            $eleForm.attr("action", "huage/huage.jpg"); //这边也不行，最好在后台直接给他输出图片

            $(document.body).append($eleForm);

            //提交表单，实现下载
            $eleForm.submit();
        }
        function fnHrefGetFile() {
            //  window.location.href = "huage/File.zip";
            //window.location.href = "../../Images/test.doc";
            window.location.href = "huage/huage.jpg";//图片下载不行
        }

    </script>
</body>
</html>
