using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*装饰模式（Decorator Pattern）【结构型】
     1、动机（Motivate）
       在房子装修的过程中，各种功能可以相互组合，来增加房子的功用。类似的，如果我们在软件系统中，要给某个类型或者对象增加功能，如果使用“继承”的方案来写代码，就会出现子类暴涨的情况。
     * 比如：IMarbleStyle是大理石风格的一个功能，IKeepWarm是保温的一个接口定义，IHouseSecurity是房子安全的一个接口，就三个接口来说，House是我们房子，我们的房子要什么功能就实现什么接口，
     * 如果房子要的是复合功能，接口不同的组合就有不同的结果，这样就导致我们子类膨胀严重，如果需要在增加功能，子类会成指数增长。这个问题的根源在于我们“过度地使用了继承来扩展对象的功能”，
     * 由于继承为类型引入的静态特质（所谓静态特质，就是说如果想要某种功能，我们必须在编译的时候就要定义这个类，这也是强类型语言的特点。静态，就是指在编译的时候要确定的东西；动态，是指运行时确定的东西），
     * 使得这种扩展方式缺乏灵活性；并且随着子类的增多（扩展功能的增多），各种子类的组合（扩展功能的组合）会导致更多子类的膨胀（多继承）。
     * 如何使“对象功能的扩展”能够根据需要来动态（即运行时）地实现？同时避免“扩展功能的增多”带来的子类膨胀问题？从而使得任何“功能扩展变化”所导致的影响降为最低？
     
     2、意图（Intent）
        动态地给一个对象增加一些额外的职责。就增加功能而言，Decorator模式比生成子类更为灵活。　　       ——  《设计模式》GoF
     
     3、模式的组成
        在装饰模式中的各个角色有：
　　（1）、抽象构件角色（Component）：给出一个抽象接口，以规范准备接收附加责任的对象。

　　（2）、具体构件角色（Concrete Component）：定义一个将要接收附加责任的类。

　　（3）、装饰角色（Decorator）：持有一个构件（Component）对象的实例，并实现一个与抽象构件接口一致的接口。

　　（4）、具体装饰角色（Concrete Decorator）：负责给构件对象添加上附加的责任。
     */
    class Decorator
    {
    }

    /// <summary>
    /// 该抽象类就是房子抽象接口的定义，该类型相当于Component类型，是饺子馅，需要装饰的，需要包装的
    /// </summary>
    public abstract class House
    {
        //房子的张绣方法--相当于Component类型的Operation方法
        public abstract void Renovation();
    }

    /// <summary>
    /// 该抽象类就是装饰接口的定义，该类型相当于是Decorator类型,如果需要具体的功能，可以子类化该类型
    /// </summary>
    public abstract class DecorationStrategy : House
    {
        //通过自合方式引用Decorator类型，该类型实施具体功能的增加
            //这是关键点之一，包含关系，体现为Has-a
        private House _house;

        //通过构造器注入，初始化平台实现
        protected DecorationStrategy(House house)
        {
            this._house = house;
        }

        //该方法就相当于Decorator类型的Operation方法
        public override void Renovation()
        {
            if (_house != null)
            {
                this._house.Renovation();
            }
        }
    }

    /// <summary>
    /// Huage风格的房子，我要按照我的要求做房子，相当于ConcreteComponent类型，这就是我们具体的饺子馅
    /// </summary>
    public class HugeFengeGHouse : House
    {

        public override void Renovation()
        {
            Console.WriteLine("装修huage风格的房子");
        }
    }

    /// <summary>
    /// 具有空调功能的设备，相当于ConcreteDecoratorA类型
    /// </summary>
    public class AirConditionerDecorator : DecorationStrategy
    {
        public AirConditionerDecorator(House house) : base(house) { }

        public override void Renovation()
        {
            base.Renovation();//先实现基类中的方法
            Console.WriteLine("增加空调功能");
            //这边还可以增加其他的功能
        }
    }

}
