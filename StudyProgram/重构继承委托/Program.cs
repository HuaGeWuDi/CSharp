using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 重构继承委托
{
    class Program
    {
        static void Main(string[] args)
        {
            Child child = new Child();
            Console.WriteLine(child.getPubStr());
            Console.WriteLine(child.getVirStr());
            Console.WriteLine(child.getVirStr1());
            Console.WriteLine(child.getAbStr());
            child.getAbsStr();
            Child1 child1 = new Child1();
            Console.WriteLine(child1.getPubStr());
            Console.ReadKey();
        }
    }

    public abstract class Parent
    {
        private string Id { get; set; }
        public string getPubStr()
        {
            return "I am Public parent";
        }
        public virtual string getVirStr()
        {
            return "I am Virtual parent";
        }
        public virtual string getVirStr1()
        {
            return "I am Virtual parent`1";
        }
        public abstract void getAbsStr(); //abstract关键字只能用在抽象类中修饰方法,因为抽象方法只是声明, 不提供实现, 所以方法只以分号结束,没有方法体,即没有花括号部分;如
        public abstract string getAbStr();//只要声明，不需要实现；

    }

    public class Child : Parent
    {
        //如果继承基类的话,子类可以使用基类中公共的方法
        //virtual(虚函数)修饰的基类函数的话：子类没有重写基类中的方法的话，子类调用的话则使用基类中的虚函数，否则的使用自己重写的虚函数
        public override string getVirStr1()
        {
            return "I am Virtual child ";
        }
        //abstract(抽象函数)修饰的基类函数的话：子类继承后必须重写该方法否则会报错
        public override void getAbsStr()
        {
            Console.WriteLine("I am Abstract child ");
        }
        public override string getAbStr()
        {
            return "I am Abstract child ";
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
    
    //如果我只想实现parent中的getPubStr()函数时，我们可以不需继承该类里面其他方法，这时候我们需要重构
    public class Child1
    {
        //因为parent是抽象类，无法实例，我们可以实例化child类，从而实现parent中getPubStr()函数
        //通过构造注入和方法注入
        private Child _child;
        public Child1()
        {
            _child = new Child();
        }
        public string getPubStr()
        {
            return _child.getPubStr();
        }
    }
}
