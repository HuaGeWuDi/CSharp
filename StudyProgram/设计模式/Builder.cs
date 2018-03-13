using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    class Builder { }

    /*------------建造模式（也叫Builder模式）【创建型】--------------
     *1、动机：在软件系统中，有时候面临着“一个复杂对象”的创建工作，其通常由各个部分的子对象用一定的算法构成；
     *由于需求的变化，这个复杂对象的各个部分经常面临着剧烈的变化，但是将它们组合在一起的算法却相对稳定。如何应对这种变化？
     *如何提供一种“封装机制”来隔离出“复杂对象的各个部分”的变化，从而保持系统中的“稳定构建算法”不随着需求改变而改变？      
     * 
     * 2、将一个复杂对象的构建与其表示相分离，使得同样的构建过程可以创建不同的表示。  
     * 
     * 3、组成
     * （1）、抽象建造者角色（Builder）：为创建一个Product对象的各个部件指定抽象接口，以规范产品对象的各个组成成分的建造。一般而言，此角色规定要实现复杂对象的哪些部分的创建，并不涉及具体的对象部件的创建。

       （2）、具体建造者（ConcreteBuilder）

         1）实现Builder的接口以构造和装配该产品的各个部件。即实现抽象建造者角色Builder的方法。

         2）定义并明确它所创建的表示，即针对不同的商业逻辑，具体化复杂对象的各部分的创建

         3) 提供一个检索产品的接口

         4) 构造一个使用Builder接口的对象即在指导者的调用下创建产品实例

       （3）、指导者（Director）：调用具体建造者角色以创建产品对象的各个部分。指导者并没有涉及具体产品类的信息，真正拥有具体产品的信息是具体建造者对象。它只负责保证对象各部分完整创建或按某种顺序创建。

       （4）、产品角色（Product）：建造中的复杂对象。它要包含那些定义组件的类，包括将这些组件装配成产品的接口。
     * 
     */

    /// 这个类型才是组装的，Construct方法里面的实现就是创建复杂对象固定算法的实现，该算法是固定的，或者说是相对稳定的
    /// 这个人当然就是老板了，也就是建造者模式中的指挥者
    public class CarDirector
    {
        public void Construct(CarBuilder builder)
        {
            builder.BuildCarDoor();
            builder.BuildCarWheel();
            builder.BuildCarEngine();
        }
    }

    //汽车类 -- 产品角色
    public sealed class BCar
    {
        private List<string> parts = new List<string>();//程序启动时就实例化

        public void Add(string part)
        {
            parts.Add(part);
        }

        public void show()
        {
            Console.WriteLine("汽车开始组装。。。");
            foreach (var s in parts)
                Console.WriteLine("组件" + s + "已经装好");
        }
    }

    //抽象建造者，它定义了要创建什么部件和最后创建的结果，但是不是组装的的类型，切记
    public abstract class CarBuilder
    {
        //创建车门
        public abstract void BuildCarDoor();
        //创建车轮
        public abstract void BuildCarWheel();
        //创建引擎
        public abstract void BuildCarEngine();
        //这边还可以车的其他部件：方向盘，座椅，大灯。。。

        //获取组装好的汽车
        public abstract BCar GetCar();
    }

    //具体创建者，具体的车型的创建者 如：宝马（BMW）
    public sealed class BmwBuild : CarBuilder
    {
        BCar bmw_car = new BCar();
        public override void BuildCarDoor()
        {
            bmw_car.Add("BWM's Door");
        }

        public override void BuildCarWheel()
        {
            bmw_car.Add("BWM's Wheel");
        }

        public override void BuildCarEngine()
        {
            bmw_car.Add("BWM's Engine");
        }

        public override BCar GetCar()
        {
            return bmw_car;
        }
    }
    //具体创建者，具体的车型的创建者 如：奔驰
    public sealed class BenChiBuild : CarBuilder
    {
        BCar bc_car = new BCar();
        public override void BuildCarDoor()
        {
            bc_car.Add("BenChi's Door");
        }

        public override void BuildCarWheel()
        {
            bc_car.Add("BenChi's Wheel");
        }

        public override void BuildCarEngine()
        {
            bc_car.Add("BenChi's Engine");
        }

        public override BCar GetCar()
        {
            return bc_car;
        }
    }

}
