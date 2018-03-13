using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*状态模式（State Pattern）【行为型】
     1、动机（Motivate）
       在软件构建过程中，某些对象的状态如果改变，其行为也会随之而发生变化，比如文档处于只读状态，其支持的行为和读写状态支持的行为就可能完全不同。
       如何在运行时根据对象的状态来透明地更改对象的行为？而不会为对象操作和状态转化之间引入紧耦合？
     
     2、意图（Intent）
      允许一个对象在其内部状态改变时改变它的行为。从而使对象看起来似乎修改了其行为。　　　　　　       ——《设计模式》GoF
    
     3、模式的组成   
    （1）、环境角色（Context）：也称上下文，定义客户端所感兴趣的接口，并且保留一个具体状态类的实例。这个具体状态类的实例给出此环境对象的现有状态。
 
    （2）、抽象状态角色（State）：定义一个接口，用以封装环境对象的一个特定的状态所对应的行为。 

    （3）、具体状态角色（ConcreteState）：每一个具体状态类都实现了环境（Context）的一个状态所对应的行为。

    
     */
    class State
    {
        //状态模式（State Pattern）【行为型】
        //下面以客户下订单>等待受理>手里发货>确认收货>教育完成
        //或者取消订单。。。
    }

    //环境角色--相当于Context类型
    public sealed class Order
    {
        private IState _state;

        public double Minute { get; set; }

        public bool IsCancel { get; set; }

        public bool Finish { get; set; }

        public Order()
        {
            this._state = new WaitForAcceptance();
            IsCancel = false;
        }

        public void SetState(IState s)
        {
            this._state = s;
        }

        public void Action()
        {
            _state.Process(this);
        }
    }

    //抽象状态角色--相当于State类型
    public interface IState
    {
        //处理订单
        void Process(Order order);
    }

    //等待受理--相当于具体状态角色
    public sealed class WaitForAcceptance : IState
    {

        public void Process(Order order)
        {
            Console.WriteLine("我们开始受理，准备备货!");
            if (order.Minute < 30 && order.IsCancel)
            {
                Console.WriteLine("接受半小时之内，可以取消订单！");
                order.SetState(new CanceOrder());
                order.Finish = true;
                order.Action();
            }
            else
            {
                order.SetState(new AcceptAndDeliver());
                order.Finish = false;
                order.Action();
            }
        }
    }

    //受理发货---相当于具体状态角色
    public sealed class AcceptAndDeliver : IState
    {

        public void Process(Order order)
        {
            Console.WriteLine("我们货物已经准备好，可以发货，不可以撤销订单");

            if (!order.Finish)
            {
                order.SetState(new Success());
                order.Action();
            }
        }
    }

    //交易成功---相当于具体状态角色
    public sealed class Success : IState
    {
        public void Process(Order order)
        {
            Console.WriteLine("订单结算");
            order.SetState(new ConfirmationReceipt());
            order.Finish = true;
            order.Action();
        }
    }

    //确认收货---相当于具体状态角色
    public sealed class ConfirmationReceipt : IState
    {
        public void Process(Order order)
        {
            Console.WriteLine("检查货物，没问题就可以签收");
        }
    }

    //取消订单---相当于具体状态角色
    public sealed class CanceOrder : IState
    {
        public void Process(Order order)
        {
            Console.WriteLine("有问题，取消订单");
        }
    }


}
