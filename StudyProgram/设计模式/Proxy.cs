using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*代理模式（Proxy Pattern）【结构型】
     1、动机（Motivate）
      在面向对象系统中，有些对象由于某种原因（比如对象创建的开销很大，或者某些操作需要安全控制，或者需要进程外的访问等），直接访问会给使用者、或者系统结构带来很多麻烦。
      如何在不失去透明操作对象的同时来管理/控制这些对象特有的复杂性？增加一层间接层是软件开发中常见的解决方式。
     
      2、意图（Intent）
       为其他对象提供一种代理以控制对这个对象的访问。　　   ——《设计模式》GoF

      3、模式的组成    
        代理模式所涉及的角色有三个：

        （1）、抽象主题角色（Subject）：声明了真实主题和代理主题的公共接口，这样一来在使用真实主题的任何地方都可以使用代理主题。

        （2）、代理主题角色（Proxy）：代理主题角色内部含有对真实主题的引用，从而可以操作真实主题对象；代理主题角色负责在需要的时候创建真实主题对象；代理角色通常在将客户端调用传递到真实主题之前或之后，都要执行一些其他的操作，而不是单纯地将调用传递给真实主题对象。

        （3）、真实主题角色（RealSubject）：定义了代理角色所代表的真实对象。

     
     */
    class Proxy
    {
    }

    /// <summary>
    /// 该类型就是抽象Subject角色，定义代理角色和真实主体角色共有的接口方法
    /// </summary>
    public abstract class AgentAbstract
    {
        //该方法执行明星具体炒作--相当于抽象的Subject的Request 方法
        public virtual void Speak(string thing)
        {
            Console.WriteLine(thing);
        }
    }

    /// <summary>
    /// 该类型是明星类，有钱有势，真实主体角色--相当于具体的RealSubject角色
    /// </summary>
    public sealed class FanStar : AgentAbstract
    {
        //无参构造函数
        public FanStar() { }

        //要有名气，定期炒作--RealSubject类型的Request方法
        public override void Speak(string thing)
        {
            base.Speak("贾乃亮:" + thing);
        }
    }

    /// <summary>
    /// 该类型是代理类型--相当于具体的Proxy角色
    /// </summary>
    public sealed class AgentPerson : AgentAbstract
    {
        //真实主体
        private FanStar _fanStar;

        public AgentPerson()
        {
            _fanStar = new FanStar();//初始化
        }

        //炒作方法，执行具体的炒作--相当于Proxy类型的Request方法
        public override void Speak(string thing)
        {
            Console.WriteLine("经纪人:前期弄点绯闻");
            _fanStar.Speak(thing);
            Console.WriteLine("经纪人:然后开发布会，伤心哭泣后继续捞钱");
        }
    }
}
