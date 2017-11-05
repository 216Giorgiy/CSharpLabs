using System;

namespace CSharpLabs3
{
    namespace Exp1
    {
        internal class Demo
        {
            public int this[int value]
            {
                get
                {
                    if (value >= 0 && value < 5)
                    {
                        return value * 4;
                    }
                    throw new NotImplementedException();
                }
            }
        }

        internal static class Program
        {
            private static void Main()
            {
                var demo = new Demo();
                Console.WriteLine(demo[0]);
                Console.WriteLine(demo[1]);
                Console.WriteLine(demo[2]);
                Console.WriteLine(demo[3]);
            }
        }
    }
}