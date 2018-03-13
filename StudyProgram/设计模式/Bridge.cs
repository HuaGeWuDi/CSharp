using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*桥接模式（Bridge Pattern）【结构型】
     1、动机（Motivate）
       在很多游戏场景中，会有这样的情况：【装备】本身会有的自己固有的逻辑，比如枪支，会有型号的问题，同时现在很多的游戏又在不同的介质平台上运行和使用，
     * 这样就使得游戏的【装备】具有了两个变化的维度——一个变化的维度为“平台的变化”，另一个变化的维度为“型号的变化”。
     * 如果我们要写代码实现这款游戏，难道我们针对每种平台都实现一套独立的【装备】吗？复用在哪里？如何应对这种“多维度的变化”？
     * 如何利用面向对象技术来使得【装备】可以轻松地沿着“平台”和“型号”两个方向变化，而不引入额外的复杂度？
     2、意图（Intent）
        将抽象部分与实现部分分离，使它们都可以独立地变化。      ----   --《设计模式》Gof                                                         

        桥模式不能只是认为是抽象和实现的分离，它其实并不仅限于此。
     *  其实两个都是抽象的部分，更确切的理解，应该是将一个事物中多个维度的变化分离。
     4、模式的组成
        桥接模式的结构包括Abstraction、RefinedAbstraction、Implementor、ConcreteImplementorA和ConcreteImplementorB五个部分，其中：

       （1）、抽象化角色(Abstraction)：抽象化给出的定义，并保存一个对实现化对象（Implementor）的引用。

       （2）、修正抽象化角色(Refined Abstraction)：扩展抽象化角色，改变和修正父类对抽象化的定义。

       （3）、实现化角色(Implementor)：这个角色给出实现化角色的接口，但不给出具体的实现。必须指出的是，这个接口不一定和抽象化角色的接口定义相同，
              实际上，这两个接口可以非常不一样。实现化角色应当只给出底层操作，而抽象化角色应当只给出基于底层操作的更高一层的操作。

       （4）、具体实现化角色(Concrete Implementor)：这个角色给出实现化角色接口的具体实现。

　　
     * 在桥接模式中，两个类Abstraction和Implementor分别定义了抽象与行为类型的接口，通过调用两接口的子类实现抽象与行为的动态组合。
     */
    class Bridge
    {

    }

    /// <summary>
    /// 该抽象类就是抽象接口的定义，该类型就相当于是Abstraction类型
    /// </summary>
    public abstract class DataBase
    {
        //通过组合方式引用平台接口，此处就是桥梁，该类型相当于Implementor类型
        protected PlatformImplementor _implementor;

        protected DataBase(PlatformImplementor implementor)//构造器注入
        {
            this._implementor = implementor;
        }
        public abstract void Create();
    }

    /// <summary>
    /// 该抽象类就是实现接口的定义，该类型就相当于Implementor类型
    /// </summary>
    public abstract class PlatformImplementor
    {
        //该方法就相当于Implementor类型的OperationImp1方法
        public abstract void Process();//抽象方法只能在抽象类中定义   抽象类中只能定义抽象方法
    }

    /// <summary>
    /// SQLSever2000版本的数据库，相当于RefinedAbstraction类型
    /// </summary>
    public class SQLServer2000 : DataBase
    {
        //构造函数初始化
        public SQLServer2000(PlatformImplementor implementor) : base(implementor) { }
        public override void Create()
        {
            this._implementor.Process();
        }
    }

    /// <summary>
    /// SQLServer2000版本的数据库针对Unix操作系统的具体实现，相当于ConcreteImplementorA类型
    /// </summary>
    public class SQLServer2000UnixImplementor : PlatformImplementor
    {
        public override void Process()
        {
            Console.WriteLine("SQLServer2000针对Unix的具体实现");
        }
    }

    /// <summary>
    /// SQLServer2005版本的数据库，相当于RefinedAbstraction类型
    /// </summary>
    public class SQLServer2005 : DataBase
    {
        //构造函数初始化
        public SQLServer2005(PlatformImplementor implementor) : base(implementor) { }
        public override void Create()
        {
            this._implementor.Process();
        }
    }

    /// <summary>
    /// SQLServer2000版本的数据库针对Unix操作系统的具体实现，相当于ConcreteImplementorB类型
    /// </summary>
    public class SQLServer2005UnixImplementor : PlatformImplementor
    {
        public override void Process()
        {
            Console.WriteLine("SQLServer2005针对Unix的具体实现");
        }
    }
}
