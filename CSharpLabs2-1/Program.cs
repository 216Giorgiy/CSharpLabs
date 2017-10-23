using System;

namespace CSharpLabs2
{
    namespace Exp1
    {
        internal static class Program
        {
            private static void Main()
            {
                try
                {
                    Console.WriteLine("Enter a String:");
                    var a = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine($"a equals {a}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a short!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Overflow!");
                }
                finally
                {
                    Console.ReadKey();
                }
            }
        }
    }
}
