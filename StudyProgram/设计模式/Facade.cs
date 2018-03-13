using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*外观模式（Facade Pattern）【结构型】
    1、动机（Motivate）
      在软件系统开发的过程中，当组件的客户（即外部接口，或客户程序）和组件中各种复杂的子系统有了过多的耦合，
     * 随着外部客户程序和各子系统的演化，这种过多的耦合面临很多变化的挑战。如何简化外部客户程序和系统间的交互接口？
     * 如何将外部客户程序的演化和内部子系统的变化之间的依赖相互解耦？
     
    2、意图（Intent）
      为子系统中的一组接口提供一个一致的界面，Facade模式定义了一个高层接口，这个接口使得这一子系统更加容易使用。　　　　　　——《设计模式》GoF
    
     3、模式的组成    
        外观模式包含如下两个角色：
      （1）、外观角色（Facade）：在客户端可以调用它的方法，在外观角色中可以知道相关的（一个或者多个）子系统的功能和责任；
     * 在正常情况下，它将所有从客户端发来的请求委派到相应的子系统去，传递给相应的子系统对象处理。

      （2）、子系统角色（SubSystem）：在软件系统中可以有一个或者多个子系统角色，每一个子系统可以不是一个单独的类，而是一个类的集合，它实现子系统的功能；
     * 每一个子系统都可以被客户端直接调用，或者被外观角色调用，它处理由外观类传过来的请求；子系统并不知道外观的存在，对于子系统而言，外观角色仅仅是另外一个客户端而已。     
     */
    class Facade
    {
    }

    public class A
    {
        public void Method_A()
        {
            Console.WriteLine("实现A系统中的方法A");
        }
    }

    public class B
    {
        public void Method_B()
        {
            Console.WriteLine("实现B系统中的方法B");
        }
    }

    public class F_Facade
    {
        //private A _a = new A();//这样子不可取，这样是程序运行时就会实例化
        private A _a;
        private B _b;
        public F_Facade()
        {
            _a = new A();//这边不叫构造器注入，只能说在构造函数中初始化
            _b = new B();
        }
        public void Method_C()
        {
            this._a.Method_A();
            this._b.Method_B();
            Console.WriteLine("实现所有系统的中的方法，实现登录（购物）");
        }
    }
}
