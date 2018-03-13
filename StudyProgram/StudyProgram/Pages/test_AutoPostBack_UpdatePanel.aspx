<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test_AutoPostBack_UpdatePanel.aspx.cs" Inherits="StudyProgram.Pages.test_AutoPostBack_UpdatePanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:textbox ID="Textbox1" runat="server" AutoPostBack="true" ontextchanged="Textbox1_TextChanged"></asp:textbox>
    </div>
    </form>
</body>
</html>

