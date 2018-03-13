using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 重写
{
    class Program : baseClass.bClas, baseClass.InterBase
    {
        public static string huage = "无敌";

        public string Name { get; set; }  //必须实现接口里面的定义
        public string ConsoleStr(string str = "") //必须实现接口里面的定义
        {

            return str;
        }
        public new string ConsoleStr1(string str,string wudi) //（重载父类的方法，除了方法名不可以修改，参数，返回值等都可以修改）继承了基类的该方法，直接覆盖基类中的该方法
        {
            return str + wudi;
        }
        public override void ConsoleStr2(params object[] my_params)//抽象方法里面的该方法不需要实现
        {
            Console.WriteLine(huage);
        }
        public override string ConsoleStr3(params object[] my_params)
        {
            //没有必要在子类中重写
            return base.ConsoleStr3(my_params);
        }
        static void Main(string[] args)
        {
            Program pro = new Program();
            Console.WriteLine(pro.ConsoleStr1("华哥") + "," + pro.ConsoleStr3("无敌", "是多么寂寞"));
            pro.ConsoleStr2();
            Console.ReadKey();
        }


        string baseClass.InterBase.Name
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        string baseClass.InterBase.ConsoleStr(string str)
        {
            throw new NotImplementedException();
        }
    }
}
