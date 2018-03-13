using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*中介者模式（Mediator Pattern）【行为型】
     1、动机（Motivate）
       在软件构建过程中，经常会出现多个对象互相关联交互的情况，对象之间常常会维持一种复杂的引用关系，如果遇到一些需求的更改，这种直接的引用关系将面临不断地变化。

　     在这种情况下，我们可使用一个“中介对象”来管理对象间的关联关系，避免相互交互的对象之间的紧耦合引用关系，从而更好地抵御变化。

     2、意图（Intent）
       定义了一个中介对象来封装一系列对象之间的交互关系。
       中介者使各个对象之间不需要显式地相互引用，从而使耦合性降低，而且可以独立地改变它们之间的交互行为。　　        ——《设计模式》GoF
     
     3、模式的组成   

    （1）、抽象中介者角色（Mediator）：在里面定义各个同事之间交互需要的方法，可以是公共的通信方法，也可以是小范围的交互方法。

    （2）、具体中介者角色（ConcreteMediator）：它需要了解并维护各个同事对象，并负责具体的协调各同事对象的交互关系。

    （3）、抽象同事类（Colleague）：通常为抽象类，主要约束同事对象的类型，并实现一些具体同事类之间的公共功能，比如，每个具体同事类都应该知道中介者对象，也就是具体同事类都会持有中介者对象，都可以到这个类里面。

    （4）、具体同事类（ConcreteColleague）：实现自己的业务，需要与其他同事通信时候，就与持有的中介者通信，中介者会负责与其他同事类交互。   
     
     */
    class Mediator
    {
        //中介者模式（Mediator Pattern）【行为型】
        //公司管理过程中，就会涉及到各个部门之间的协调和合作，如何各个部门直接来沟通，看着好像直接高效，其实不然。各个部门之间为了完成一个工作，
        //沟通协调就需要一个人来做这个工作，谁呢？总经理，我们这里就把总经理定义为成总的管理者，各个部门需要向他汇报和发起工作请求。
    }

    //抽象中介者
    public interface IMediator
    {
        //void Command(Department dep);
        void Command();
    }

    //抽象同事类
    public abstract class Department
    {
        //持有中介者（总经理）的引用
        private IMediator _imediator;

        public IMediator GetMediator
        {
            get { return _imediator; }
            set { _imediator = value; }
        }

        protected Department(IMediator mediator)
        {
            this._imediator = mediator;
        }

        public abstract void Process();//汇报工作

        public abstract void Apply();//做自己的事情
    }

    //开发部门
    public sealed class Development : Department
    {
        public Development(IMediator mediator) : base(mediator) { }

        public override void Process()
        {
            Console.WriteLine("开发部门,要进行项目开发，没钱了，需要资金支持");
        }

        public override void Apply()
        {
            Console.WriteLine("专心科研，开发项目");
        }
    }

    //财务部门
    public sealed class Financial : Department
    {
        public Financial(IMediator m) : base(m) { }

        public override void Process()
        {
            Console.WriteLine("汇报工作！钱太多了，怎么花出去？");
        }

        public override void Apply()
        {
            Console.WriteLine("数钱");
        }
    }

    //总经理--相当于具体中介者角色
    public sealed class President : IMediator
    {
        private Financial _fin;
        private Development _deve;

        public void SetFinancial(Financial fin)
        {
            this._fin = fin;
        }

        public void SetDevelopment(Development deve)
        {
            this._deve = deve;
        }

        //public void Command(Department dep)
        //{
        //    if (dep.GetType().Equals(typeof(Development)))
        //    {
        //        this._fin.Process();
        //    }
        //}

        public void Command()
        {
            if (this._deve != null)
                this._deve.Process();
            if (this._fin != null)
                this._fin.Process();
        }
    }
}
