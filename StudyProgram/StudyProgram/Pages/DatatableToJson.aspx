<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DatatableToJson.aspx.cs"
    Inherits="StudyProgram.Pages.DatatableToJson" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        列表：<input type="text" list="mydata" placeholder="热门电影排行" />
        <datalist id="mydata">
            <option label="Top1" value="让子弹飞">
            <option label="Top2" value="非诚勿扰2">
            <option label="Top3" value="大笑江湖">
            <option label="Top4" value="赵氏孤儿">
            <option label="Top5" value="初恋这件小事">
        </datalist>
    </div>
    </form>
</body>
</html>
