using System;

namespace CSharpLabs3
{
    namespace Exp3
    {
        internal class Demo
        {
            public int Mul(int a, int b) => a * b;
            public double Mul(double a, int b) => a * b;
            public double Mul(double a, double b) => a * b;
        }

        internal static class Program
        {
            private static void Main()
            {
                var demo = new Demo();
                Console.WriteLine(demo.Mul(1, 1));
                Console.WriteLine(demo.Mul(1.2, 1));
                //Console.WriteLine(demo.Mul(1, 1.2));
                Console.WriteLine(demo.Mul(1.2, 1.2));
            }
        }
    }
}