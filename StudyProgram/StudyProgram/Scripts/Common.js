//取指定位数的随机数，包含0''
function getRandom(a) {
    return Math.round(Math.random() * a)//round() 方法可把一个数字舍入为最接近的整数
}
//取指定位数的随机数，i true or false 时候包含0
function getRandomMath(i, a) {
    if (i) //包含0，0的几率非常小
        return getRandom(a)
    else {
        var result = getRandom(a);
        if (result == 0) {
            getRandomMath(i, a);
        } else {
            return result;
        }
    }
    return;
}
//取地址栏参数
function getUrlParm1(parm) {//正则表达式取参数
    var urlParm = "";
    var reg = new RegExp("(^|&)" + parm + "=([^&]*)(&|$)");
    var url = location.search; //地址栏"?"后面的所有字符串
    var result = url.substr(1).match(reg); //截取？后面的字符串，并且匹配正则表达式
    if (result != null) urlParm = unescape(result[2]); //解码url链接的字符串
    return urlParm;
}
function getUrlParm2() {//直接获取url中的链接参数对象
    var url = location.search;
    var myRequest = new Object();
    if (url.length > 0) {
        url = url.substr(1);
        var arr = url.split('&');
        for (var i = 0; i < arr.length; i++) {
            var urlArr = arr[i].split('=');
            myRequest[urlArr[0]] = unescape(urlArr[1]);
        }
    }
    return myRequest; //直接得到一个对象    使用方法 var request=getUrlParm2(); request["f"],f为所需要的参数
}
//计时
function getCountTime(fn, time) {//多长时间之后调用fn函数,该方法需要应用JQuery
    //setInterval() 方法会不停地调用函数，直到 clearInterval() 被调用或窗口被关闭。由 setInterval() 返回的 ID 值可用作 clearInterval() 方法的参数。
    setInterval(fn, time); // 例如： setInterval("fort2()",1000);        
}
//转化时间
function DateFormat(datetime, symbol) {
    var a = new Date();
    if (typeof datetime == "undefined" || !datetime) {  // 未定义 variable 变量 或 variable变量 空，0，null...等等
    } else {
        a = new Date(datetime);
    }
    if (typeof symbol == "undefinded" || !symbol) symbol = "-";
    var year = a.getFullYear();
    var Month = showDigit(a.getMonth() + 1); //月份要加1
    var Day = showDigit(a.getDate()); //日期
    var Hour = showDigit(a.getHours());
    var Minute = showDigit(a.getMinutes());
    var Second = showDigit(a.getSeconds());
    var result = year + '{0}' + Month + '{1}' + Day + ' ' + Hour + ':' + Minute + ':' + Second;
    result = result.replace('{0}', symbol).replace('{1}', symbol);
    return result;
}
//获取当月的天数
function monthDays(date) {
    date.setDate(0)
    return date.getDate();
}
//时间取两位位数
function showDigit(data) {
    var data1 = parseInt(data);
    data1 = data >= 10 ? data : "0" + data;
    return data1;
}
//获取月倒计时
function getDJS() {
    var sySec, syMin, syHour, syDay;
    var date = new Date();
    var year = date.getFullYear();
    var Month = date.getMonth() + 1; //当前月份
    var Day = date.getDate();
    var Hour = date.getHours();
    var Min = date.getMinutes();
    var Sec = date.getSeconds();
    var days = monthDays(date); //月天,该月份有多少天
    sySec = 60 - Sec;
    syMin = Sec > 0 ? 60 - Min - 1 : 60 - Min;
    if (Sec > 0 || Min > 0) syHour = 24 - Hour - 1;
    else syHour = 24 - Hour;
    if (Sec > 0 || Min > 0 || Hour > 0) syDay = days - Day - 1;
    else syDay = days - Day;
    return showDigit(syDay) + "-" + showDigit(syHour) + "-" + showDigit(syMin) + "-" + showDigit(sySec);
}