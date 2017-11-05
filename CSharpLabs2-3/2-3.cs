using System;

namespace CSharpLabs2
{
    namespace Exp3
    {
        internal class DemoClass
        {
            private readonly double _x;
            private readonly double _y;

            public DemoClass()
            {
                _x = 0;
                _y = 0;
            }

            public DemoClass(double x, double y)
            {
                _x = x;
                _y = y;
            }

            public void Show()
            {
                Console.WriteLine($"x = {_x}");
                Console.WriteLine($"y = {_y}");
            }
        }
        internal static class Program
        {
            private static void Main()
            {
                var demoA = new DemoClass();
                demoA.Show();
                var demoB = new DemoClass(1, 2.2);
                demoB.Show();
            }
        }
    }
}
