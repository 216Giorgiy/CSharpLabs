using System;
using System.Diagnostics;
using System.Linq;

namespace CSharpLabs1
{
    namespace Exp4
    {
        internal static class Program
        {
            private static void Main()
            {
                var param = new double[6];
                var i = 0;
                do
                {
                    do
                    {
                        Console.WriteLine($"Please input {Char.ConvertFromUtf32('A' + i)}: ");
                    } while (!double.TryParse(Console.ReadLine(), out param[i]));
                    ++i;
                } while (i < 6);
                double detla = 0, a = param[0], b = param[1], c = param[2], d = param[3], e = param[4], f = param[5];
                if ((detla = a * e - b * d) != 0)
                {
                    var x = (c * e - b * f) / detla;
                    var y = (a * f - c * d) / detla;
                    Console.WriteLine($"x = {x}, y = {y}");
                }
                else
                {
                    Console.WriteLine("方程组无解或有无穷多组解");
                }
            }
        }
    }
}