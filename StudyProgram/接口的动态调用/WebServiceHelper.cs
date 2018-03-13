using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web.Services.Description;
using System.CodeDom;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

namespace 接口的动态调用
{
    public class WebServiceHelper
    {
        //动态调用web服务
        public  object InvokeWebService(string url, string methodname, params object[] args)
        {
            return InvokeWebService(url, null, methodname, args);
        }

        public object InvokeWebService(string url, string classname, string methodname, params object[] args)
        {
            //这里的namespace是需引用的webservices的命名空间，在这里是写死的，大家可以加一个参数从外面传进
            var @namespace = "client";

            classname = string.IsNullOrEmpty(classname) ? GetWsClassName(url) : classname;

            try
            {
                //使用指定的文件初始化 System.Xml.XmlTextReader 类的新实例。
                XmlTextReader xmlReader = new XmlTextReader(url + "?wsdl");               

                //提供一种方法，以创建和格式化用于描述 XML Web services 的有效的 Web 服务描述语言 (WSDL) 文档文件，该文件是完整的，具有适当的命名空间、元素和属性。
                ServiceDescription serDesc = ServiceDescription.Read(xmlReader);

                ServiceDescriptionImporter serDescImp = new ServiceDescriptionImporter();

                //将指定的 System.Web.Services.Description.ServiceDescription 添加到要导入的 System.Web.Services.Description.ServiceDescriptionImporter.ServiceDescriptions值的集合中。
                serDescImp.AddServiceDescription(serDesc, "", "");


                //命名空间
                CodeNamespace codeName = new CodeNamespace(@namespace);

                CodeCompileUnit codeComUnit = new CodeCompileUnit();
                //添加指定的system.codedom.codenamespace对象集合
                codeComUnit.Namespaces.Add(codeName);

                //导入指定的 System.Web.Services.Description.ServiceDescriptionImporter.ServiceDescriptions
                //值，并将按照 System.Web.Services.Description.ServiceDescriptionImporter.Style 属性的指定来生成代码。
                serDescImp.Import(codeName, codeComUnit);

                //提供对 C# 代码生成器和代码编译器的实例的访问
                CSharpCodeProvider csc = new CSharpCodeProvider();
                //获取 C# 代码编译器的实例
                ICodeCompiler icc = csc.CreateCompiler();
                //--设定编译参数
                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;// 获取或设置一个值，该值指示是否生成可执行文件
                cplist.GenerateInMemory = true;//  获取或设置一个值，该值指示是否在内存中生成输出
                cplist.ReferencedAssemblies.Add("System.dll");// 添加程序集
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");

                //--编辑代理类
                CompilerResults cr = icc.CompileAssemblyFromDom(cplist, codeComUnit);

                if (cr.Errors.HasErrors)//获取一个值，该值指示集合是否包含错误.---抛出错误信息
                {
                    var sbStr = new System.Text.StringBuilder();
                    foreach (CompilerError c in cr.Errors)
                        sbStr.Append(c.ToString() + "\n");

                    throw new Exception(sbStr.ToString());
                }

                Assembly assembly = cr.CompiledAssembly;//获取或设置已编译的程序集。
                Type t = assembly.GetType(@namespace + "." + classname, true, true);//获取程序集实例中具有指定名称的 System.Type 对象，带有忽略大小写和在找不到该类型时引发异常的选项。

                object obj = Activator.CreateInstance(t);// 使用指定类型的默认构造函数来创建该类型的实例。

                //发现方法的属性并提供对方法元数据的访问
                MethodInfo mi = t.GetMethod(methodname);// 搜索具有指定名称的公共方法

                return mi.Invoke(obj, args); //使用指定的参数调用当前实例所表示的方法或构造函数
            }
            catch (Exception ex)
            {

                throw new Exception(ex.InnerException.Message, new Exception(ex.InnerException.StackTrace));
            }
        }

        private static string GetWsClassName(string wsUrl)
        {
            string[] parts = wsUrl.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');

            return pps[0];
        }
    }
}
