<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testWebMethod.aspx.cs"
    Inherits="StudyProgram.Pages.testWebMethod" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/JQuery-1-10-2.js" type="text/javascript"></script>
    <style>
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <button onclick='GetMsg()'>
            测试WebMethod</button>
        <button onclick='GetMsg1()'>
            测试</button>
        <input id="test" type="button" value="contrller" onclick="fnGetMsg(this)" />
    </div>
    </form>
    <script>
        $(function () {
            //      GetMsg();
        });

        //请求后台静态方法
        function GetMsg() {
            $.ajax({ //调用的静态方法，所以下面必须参数按照下面来
                url: 'testWebMethod.aspx/GetMsgByWeb',
                type: 'post',
                contentType: "application/json",
                dataType: 'json',
                data: "{}", //必须的，为空的话也必须是json字符串
                success: function (data) {//这边返回的是个对象
                    console.log(data);
                    if (data != null)
                        alert(data.d);
                }
            });
        }

        //通过后台映射方法请求数据
        function GetMsg1() {
            $.ajax({ //调用的静态方法，所以下面必须参数按照下面来
                url: '?method=GetMsgByWeb1',
                type: 'post',
                data: { id: 'huage' }, 
                dataType: 'text',
                success: function (data) {
                    console.log(data);
                    if (data != "")
                        alert(data);
                }
            });
        }
        
        //通过请求控制器得到结果
        function fnGetMsg(btn) {
            var value = $(btn).val();
//            $.post("../Controllers/Controller/Test", function (res) {
//                if (!res)
//                    alert(res);
            //            });

            $.ajax({ //调用的静态方法，所以下面必须参数按照下面来
                url: "../../Test/GetText",
                type: 'post',
                data: { value: value }, //必须的，为空的话也必须是json字符串
                dataType: 'text',
                success: function (data) {//这边返回的是个对象
                    console.log(data);
                    if (data)
                        alert(data); 
                }
            });
        }
    </script>
</body>
</html>
