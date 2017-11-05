using System;
using System.Diagnostics;
using System.Linq;

namespace CSharpLabs1
{
    namespace Exp2
    {
        internal static class Program
        {
            private static void PrintArray_For(string[] arr)
            {
                for (var i = 0; i < arr.Length; ++i)
                    Console.Write(arr[i] + "{0}", i < arr.Length - 1 ? " " : "");
            }

            private static void PrintArray_Aggregate(string[] arr)
            {
                Console.WriteLine(arr.Skip(1).Aggregate(arr[0], (s, t) => s + " " + t));
            }

            private static void Main()
            {
                var weeks = new[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
                PrintArray_Aggregate(weeks);
                PrintArray_For(weeks);
            }
        }
    }
}