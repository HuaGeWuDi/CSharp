using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*观察者模式（Observer Pattern）【行为型】
     1、动机（Motivate）
       在软件构建过程中，我们需要为某些对象建立一种“通知依赖关系”——一个对象（目标对象）的状态发生改变，所有的依赖对象（观察者对象）都将得到通知。如果这样的依赖关系过于紧密，将使软件不能很好地抵御变化。

       使用面向对象技术，可以将这种依赖关系弱化，并形成一种稳定的依赖关系。从而实现软件体系结构的松耦合。
     
     2、意图（Intent）
       定义对象间的一种一对多的依赖关系，以便当一个对象的状态发生改变时，所有依赖于它的对象都得到通知并自动更新。　　　　　　         ——《设计模式》GoF
     
     3、模式的组成    
     可以看出，在观察者模式的结构图有以下角色：
    （1）、抽象主题角色（Subject）：抽象主题把所有观察者对象的引用保存在一个列表中，并提供增加和删除观察者对象的操作，抽象主题角色又叫做抽象被观察者角色，一般由抽象类或接口实现。

    （2）、抽象观察者角色（Observer）：为所有具体观察者定义一个接口，在得到主题通知时更新自己，一般由抽象类或接口实现。

    （3）、具体主题角色（ConcreteSubject）：实现抽象主题接口，具体主题角色又叫做具体被观察者角色。

    （4）、具体观察者角色（ConcreteObserver）：实现抽象观察者角色所要求的接口，以便使自身状态与主题的状态相协调。
               
     */
    class Observer
    {
        //观察者模式，以银行订阅的短信业务为基础（存取钱后，信息变了之后，发送短信）
    }

    public abstract class Depositor
    {
        //状态数据
        private string _name;//姓名，暂且以姓名唯一标识
        private decimal _balance;//余额
        private bool _isChanged;//是否变化  

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        //账户是否变化
        public bool AccountIsChanged
        {
            get { return _isChanged; }
            set { _isChanged = value; }
        }

        //账户操作时间
        public DateTime OperationDate { get; set; }

        public Depositor(string name, decimal total)
        {
            //初始化的时候相当于存款
            this._name = name;
            this._balance = total;//存款总额等于余额
            this._isChanged = false;//账户未发生变化
        }

        public void GetMoney(decimal num)
        {
            if (num <= this._balance && num > 0)
            {
                this._balance = this._balance - num;
                this._isChanged = true;
                OperationDate = DateTime.Now;
            }
        }

        //发送信息通知
        public abstract void SendMsg();
    }

    public sealed class NanJingDepositor : Depositor
    {
        public NanJingDepositor(string name, decimal total) : base(name, total) { }

        public override void SendMsg()
        {
            Console.WriteLine(string.Format("{0}:您的账户发生了变化，变化时间{1}，当前余额为{2}", Name, OperationDate.ToString("yyyy.MM.dd HHmmss"), Balance));
        }
    }

    public abstract class BankMessageSystem
    {
        protected IList<Depositor> observers;

        protected BankMessageSystem()
        {
            observers = new List<Depositor>();
        }

        public abstract void Add(Depositor despositor);//增加客户

        public abstract void Delete(Depositor despositor);//删除客户

        public abstract void Notify();//通知客户
    }

    public sealed class NanJingBankMessageSystem : BankMessageSystem
    {
        public override void Add(Depositor despositor)
        {
           //新增删除都需要判断是否存在客户
            //这边简化一些
            observers.Add(despositor);
        }

        public override void Delete(Depositor despositor)
        {
            observers.Remove(despositor);
        }

        public override void Notify()
        {
            foreach (Depositor de in observers)
            {
                if (de.AccountIsChanged)
                {
                    de.SendMsg();
                    de.AccountIsChanged = false;//发送完短信状态默认不变
                }
            }
        }
    }

}
