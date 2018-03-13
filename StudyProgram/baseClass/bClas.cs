using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace baseClass
{

    //virtual这个没有必要在子类中重写
    //abstract的方法（必须在abstract类中）是必须被子类重写 
    //在接口类中，里面的方法需要全部重写。
    abstract public class bClas
    {
        public bClas() { }
        public string ConsoleStr1(string str)
        {
            return str;
        }

        public abstract void ConsoleStr2(params object[] my_params);  //因为抽象方法只是声明, 不提供实现, 所以方法只以分号结束,没有方法体,即没有花括号部分;如
                          
        public virtual string ConsoleStr3(params object[] my_params)
        {
            var reslt = "";
            if (my_params.Length > 0)
            {
                foreach (var m in my_params)
                    reslt += m + "";
            }
            return reslt;
        }
    }
}
