using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*职责链模式（Chain of Responsibility Pattern）【行为型】
     1、动机（Motivate）
       在软件构建过程中，一个请求可能被多个对象处理，但是每个请求在运行时只能有一个接受者，如果显示指定，将必不可少地带来请求发送者与接受者的紧耦合。
       如何使请求的发送者不需要指定具体的接受者，让请求的接受者自己在运行时决定来处理请求，从而使两者解耦。
     
     2、意图（Intent）
       避免请求发送者与接收者耦合在一起，让多个对象都有可能接受请求，将这些对象连接成一条链，并且沿着这条链传递请求，知道有对象处理它为止。　　　   ——《设计模式》GoF

     3、模式的组成      
    （1）、抽象处理者角色（Handler）：抽象处理者定义了一个处理请求的接口，它一般设计为抽象类，由于不同的具体处理者处理请求的方式不同，因此在其中定义了抽象请求处理方法。
     * 因为每一个处理者的下家还是一个处理者，因此在抽象处理者中定义了一个自类型的对象，作为其对下家的引用。通过该引用，处理者可以连成一条链。

    （2）、具体处理者角色（ConcreteHandler）：具体处理者是抽象处理者的子类，它可以处理用户请求，在具体处理者类中实现了抽象处理者中定义的抽象处理方法，
     * 在处理请求之前需要进行判断，看是否有相应的处理权限，如果可以处理请求就处理它，否则将请求转发给后继者；在具体处理者中可以访问链中下一个对象，以便请求的转发。
     
     */

    class Chain_of_Responsibility
    {
        //职责链模式（Chain of Responsibility Pattern）【行为型】
        //以公司采购请求为例子，金额在一定的范围内需要什么上司审批。。
    }

    public sealed class PurchaseRequest
    {
        public double Amount { get; set; }

        public string ProductName { get; set; }

        public PurchaseRequest(double ammount, string productName)
        {
            Amount = ammount;
            ProductName = productName;
        }
    }

    public abstract class Approver
    {
        //下个审批人
        public Approver NextApprover { get; set; }

        //审批人名
        public string Name { get; set; }

        public Approver(string name)
        {
            Name = name;
        }

        //处理请求
        public abstract void ProcessRequest(PurchaseRequest request);
    }

    //部门经理
    public sealed class Manger : Approver
    {
        public Manger(string name) : base(name) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            //审批条件
            if (request.Amount <= 10000)
            {
                Console.WriteLine("{0}部门经理批准了对原材料{1}的采购计划", Name, request.ProductName);
            }
            //审批条件不满足的话，下个审批人不为空就到下个审批人审核
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

    //财务经理
    public sealed class FinancialManager : Approver
    {
        public FinancialManager(string name) : base(name) { }

        public override void ProcessRequest(PurchaseRequest request)
        {
            if (request.Amount > 10000 && request.Amount <= 50000)
            {
                Console.WriteLine("{0}财务经理批准了对原材料{1}的采购计划", Name, request.ProductName);
            }
            else if (NextApprover != null)
            {
                NextApprover.ProcessRequest(request);
            }
        }
    }

    //CEO
    public sealed class CEO : Approver
    {
        public CEO(string name) : base(name) { }

        public override void ProcessRequest(PurchaseRequest request)
        {            
            if (request.Amount > 50000 && request.Amount <= 100000)
            {
                Console.WriteLine("{0}总裁批准了对原材料{1}的采购计划", Name, request.ProductName);
            }
            else if (request.Amount > 100000)
            {
                Console.WriteLine("这个采购计划的金额比较大，需要一次董事会会议讨论才能决定！");
            }
            else {
                Console.WriteLine("金额太少{0}不审批",Name);
            }
        }
    }
}
