using System;

namespace CSharpLabs2
{
    namespace Exp4
    {
        internal class Shape
        {
            protected readonly double Width;
            protected readonly double Height;

            public Shape()
            {
                Width = 0;
                Height = 0;
            }

            public Shape(double width, double height)
            {
                Width = width;
                Height = height;
            }

            public virtual double Area() => Width * Height;
        }

        internal class Triangle : Shape
        {
            public Triangle(double width, double height) : base(width, height)
            {
            }

            public override double Area() => Width * Height / 2;
        }

        internal class Trapezia : Shape
        {
            protected readonly double Width2;
            public Trapezia(double width, double width2, double height) : base(width, height)
            {
                Width2 = width2;
            }

            public override double Area() => (Width + Width2) * Height / 2;
        }
        internal static class Program
        {
            private static void Main()
            {
                var a = new Shape(2, 4);
                var b = new Triangle(1, 2);
                var c = new Trapezia(2, 3, 4);
                Console.WriteLine($"a.Area() = {a.Area()}");
                Console.WriteLine($"b.Area() = {b.Area()}");
                Console.WriteLine($"c.Area() = {c.Area()}");
                a = b;
                Console.WriteLine($"a.Area() = {a.Area()}");
                a = c;
                Console.WriteLine($"a.Area() = {a.Area()}");
            }
        }
    }
}
