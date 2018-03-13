using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*命令模式（Command Pattern）【行为型】
     
     1、动机（Motivate）
       在软件构建过程中，“行为请求者”与“行为实现者”通常呈现一种“紧耦合”。
     * 但在某些场合——比如需要对行为进行“记录、撤销/重做（undo/redo）、事务”等处理，这种无法抵御变化的紧耦合是不合适的。
     * 在这种情况下，如何将“行为请求者”与“行为实现者”解耦？将一组行为抽象为对象，可以实现二者之间的松耦合。
     
     2、意图（Intent）
       将一个请求封装为一个对象，从而使你可用不同的请求对客户（客户程序，也是行为的请求者）进行参数化；
     * 对请求排队或记录请求日志，以及支持可撤销的操作。  ——《设计模式》GoF
     
     3、模式的组成    
     从命令模式的结构图可以看出，它涉及到五个角色，它们分别是：
    （1）、客户角色（Client）：创建具体的命令对象，并且设置命令对象的接收者。注意这个不是我们常规意义上的客户端，而是在组装命令对象和接收者，或许，把这个Client称为装配者会更好理解，因为真正使用命令的客户端是从Invoker来触发执行。

    （2）、命令角色（Command）：声明了一个给所有具体命令类实现的抽象接口。

    （3）、具体命令角色（ConcreteCommand）：命令接口实现对象，是“虚”的实现；通常会持有接收者，并调用接收者的功能来完成命令要执行的操作。

    （4）、请求者角色（Invoker）：要求命令对象执行请求，通常会持有命令对象，可以持有很多的命令对象。这个是客户端真正触发命令并要求命令执行相应操作的地方，也就是说相当于使用命令对象的入口。

    （5）、接受者角色（Receiver）：接收者，真正执行命令的对象。任何类都可能成为一个接收者，只要它能够实现命令要求实现的相应功能。
     
     */
    class Command
    {
        //今天早上，我奶奶就发布了命令，说她老人家想吃猪肉大葱馅的饺子。
        //我奶奶腿脚不好，就让我爸爸捎个话给我们夫妻俩，晚上要吃猪肉大葱馅的饺子。
        //我瞬间就明白了，这个伟大的任务就落到我们夫妻俩肩上了
        //具体代码如下：
    }

    /// <summary>
    /// 这个类型就是请求者角色---也是使用命令对象的入口。
    /// </summary>
    public sealed class PaPaInoker
    {
        //接受命令
        private GMCommand _command;

        //开始接受具体命令
        public PaPaInoker(GMCommand command) //构造器注入(如果传入类型为无参构造函数，可以直接在构造函数里面直接初始化)
        {
            this._command = command;
        }

        //下达命令
        public void ExecuteCommand()
        {
            this._command.MakeDumplings();
        }

    }

    /// <summary>
    /// 该类型就是抽象命令角色--Command，定义命令的抽象接口
    /// </summary>
    public abstract class GMCommand
    {
        //真正命令的接受者
        protected HuaAndWife _worker;

        protected GMCommand(HuaAndWife worker)
        {
            this._worker = worker;
        }

        //该方法就是抽象命令对象Command的Execute方法
        public abstract void MakeDumplings();
    }

    //该类型是具体命令角色--ConcreteCommand
    public sealed class MakeDumplingCommand : GMCommand 
    {
        //构造函数
        public MakeDumplingCommand(HuaAndWife _worker)
            : base(_worker)
        {

        }

        //执行命令
        public override void MakeDumplings()
        {
            this._worker.Execute("准备饺子，晚上吃饺子。。。");
        }
    }

    //该类型时具体命令接受角色Receiver
    public sealed class HuaAndWife  //sealed 关键字表示私有的不能被继承
    {
        //该方法相当于Receiver类型的Action方法
        public void Execute(string job)
        {
            Console.WriteLine(job);
        }
    }
}
