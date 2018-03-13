using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*适配器模式（Adapter Pattern）【结构型】
     
     1、动机（Motivate）
       在软件系统中，由于应用环境的变化，常常需要将“一些现存的对象”放在新的环境中应用，但是新环境要求的接口是这些现存对象所不满足的。
     * 如何应对这种“迁移的变化”？如何既能利用现有对象的良好实现，同时又能满足新的应用环境所要求的接口？
     2、意图（Intent）
        将一个类的接口转换成客户希望的另一个接口。Adapter模式使得原本由于接口不兼容而不能一起工作的那些类可以一起工作。                    
     3、 模式的组成

      （1）、目标角色（Target）：定义Client使用的与特定领域相关的接口。
   
      （2）、客户角色（Client）：与符合Target接口的对象协同。
  
      （3）、被适配角色（Adaptee)：定义一个已经存在并已经使用的接口，这个接口需要适配。
  
      （4）、适配器角色（Adapter) ：适配器模式的核心。它将对被适配Adaptee角色已有的接口转换为目标角色Target匹配的接口。对Adaptee的接口与Target接口进行适配.
     
     */
    class Adapter
    {
    }

    #region 对象适配
    /// <summary>
    /// 只有两孔的插头 适配器模式中的目标（Target）角色，整合后可需要用的
    /// </summary>
    public interface ITwoHoleTarget
    {
        void Reqest();
    }

    /// <summary>
    /// 三个柱子的插头,源角色------需要适配的类（Adaptee）
    /// </summary>
    public class ThreeHoleAdaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是三孔的插头,我可以使用了");
        }
    }

    /// <summary>
    /// 适配器类 将源角色适配成目标角色
    /// </summary>
    public class ThreeToTwoAdapter : ITwoHoleTarget
    {
        //引用三个柱子的插头，从而将客户端与两孔插座联系起来
        private ThreeHoleAdaptee threeHoleAdaptee = new ThreeHoleAdaptee();

        //这边可以继续增加适配对象

        //实现两孔插头的的方法
        public void Reqest()
        {
            Console.WriteLine("我是两孔的插头，在适配类中转换成三孔插头使用");
            threeHoleAdaptee.SpecificRequest();

            //这边可以做具体的转换工作
        }
    }

    #endregion


    #region 类的适配
    /// <summary>
    /// 两个孔的插头，也就是适配器模式中的目标角色
    /// </summary>
    public interface ITwoHoleTarget_1
    {
        void Request();
    }

    /// <summary>
    /// 三个孔的插头，源角色——需要适配的类
    /// </summary>
    public class ThreeHoleAdaptee_1
    {
        public void SpecificRequest()
        {
            Console.WriteLine("我是三孔的插头");
        }
    }

    /// <summary>
    /// 适配器类，接口要放在类的后面
    /// 适配器类提供了两孔插头的行为，但其本质是调用三孔插头的方法
    /// </summary>
    public class ThreeToToAdapter_1 : ThreeHoleAdaptee_1, ITwoHoleTarget_1
    {
        public void Request()
        {
            Console.WriteLine("经过适配器的转换，将两孔的插头转换成三孔的插头");
            this.SpecificRequest();
        }
    }

    #endregion
}
