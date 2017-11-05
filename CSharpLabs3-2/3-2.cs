using System;

namespace CSharpLabs3
{
    namespace Exp2
    {
        // 命名空间，没有任何访问限制，不允许出现访问修饰符
        namespace Inside
        {
            // 仅同一个程序集可访问
            internal class InternalInsideClass
            {
            }
        }

        // 仅同一个程序集可访问
        internal class InternalClass
        {
        }

        // 公开类
        public class PublicClass
        {

            // 公有方法
            public void PublicMethod()
            {
            }

            // 保护方法，仅包含类和派生类可访问
            protected void ProtectedMethod()
            {
                
            }

            // 内部方法，仅限于当前程序集访问
            internal int InternalMethod()
            {
                return PrivateMethod().GetHashCode();
            }

            // 内部方法，仅限于当前程序集或派生自包含类的类型访问
            protected internal void ProtectedInternalMethod()
            {
            }

            // 私有方法，仅自身可访问
            private PrivateNestedClass PrivateMethod()
            {
                PublicMethod();
                return new PrivateNestedClass();
            }

            // 嵌套类型的可访问域不能超出包含类型的可访问域

            // 私有嵌套类，仅包含类可访问
            private class PrivateNestedClass
            {
            }

            // 保护嵌套类，仅包含类和派生类可访问
            protected class ProtectedNestedClass
            {
            }

            // 公有嵌套类
            public class PublicNestedClass
            {
            }
        }

        // 内部子类，仅限于当前程序集访问
        internal class SubClass : PublicClass
        {
        }

        // 基类
        internal class Base
        {
            // 构造函数
            public Base(string name)
            {
                // 为属性赋值
                Name = name;
            }

            // 公有属性
            public string Name { get; set; }

            // 基类方法，重载1
            public void BasetMethod()
            {
            }

            // 基类方法，重载2
            public void BaseMethod(string param)
            {
            }

            // 基类虚方法
            public virtual void BaseVirtualMethod()
            {
            }
        }

        // 派生类
        internal class Sub: Base
        {
            // 派生类构造函数，调用了基类构造函数
            public Sub(string name) : base(name)
            {
            }

            // 派生类重写
            public override void BaseVirtualMethod()
            {
                Name = "";
            }
        }

        internal static class Program
        {
            private static void Main()
            {
                Console.WriteLine(new Inside.InternalInsideClass());
                Console.WriteLine(new InternalClass());
                var pub = new PublicClass();
                Console.WriteLine(pub);
                pub.PublicMethod();
                pub.InternalMethod();
                //pub.ProtectedMethod();
                //pub.PrivateMethod();

                Console.WriteLine(new PublicClass.PublicNestedClass());
                //Console.WriteLine(new PublicClass.ProtectedNestedClass());
                //Console.WriteLine(new PublicClass.PrivateNestedClass());

                Console.WriteLine(new SubClass());

                var sub = new Sub("test");
                Console.WriteLine(sub.Name);
                sub.BaseVirtualMethod();
                Console.WriteLine(sub.Name);
            }
        }
    }
}