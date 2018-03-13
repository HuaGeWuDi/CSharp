using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace 设计模式
{
    /** 原型模式（Prototype Pattern）【创建型】
     * 
     * 1、动机（Motivate）

        在软件系统中，经常面临着“某些结构复杂的对象”的创建工作；由于需求的变化，这些对象经常面临着剧烈的变化，但是它们却拥有比较稳定一致的接口。如何应对这种变化？如何向“客户程序（使用这些对象的程序）”隔离出“这些易变对象”，从而使得“依赖这些易变对象的客户程序”不随着需求改变而改变？

       2、意图（Intent）

      使用原型实例指定创建对象的种类，然后通过拷贝这些原型来创建新的对象。  
     * 
     * 3、模式的组成
     * 
     （1）、原型类（Prototype）：原型类，声明一个Clone自身的接口；

　   （2）、具体原型类（ConcretePrototype）：实现一个Clone自身的操作。

　   在原型模式中，Prototype通常提供一个包含Clone方法的接口，具体的原型ConcretePrototype使用Clone方法完成对象的创建。

     * 
     * **/
    class Prototype
    {

    }

    /// <summary>
    /// 类的复制
    /// </summary>
   [Serializable()]
    public class CopyClass
    {
        public int i = 0;
        public string str = "";

        public int[] arr = new[] { 1, 2, 3 };//直接={1,2,3}

        // MemberwiseClone方法创建一个浅表副本，具体来说就是创建一个新对象，然后将当前对象的非静态字段复制到该新对象。
        //如果字段是值类型的，则对该字段执行逐位复制。如果字段是引用类型，则复制引用但不复制引用的对象。
        //因此，原始对象及其复本引用的是同一对象(重点)
        public CopyClass Clone1()
        {
            return (CopyClass)this.MemberwiseClone();//创建当前的浅副本
        }

        public CopyClass Clone2()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);              
                //不设置流的位置试试看发现错误：在分析完成之前就遇到流结尾。
                ms.Position = 0;
                return (CopyClass)formatter.Deserialize(ms);
            }
        }
    }
}
