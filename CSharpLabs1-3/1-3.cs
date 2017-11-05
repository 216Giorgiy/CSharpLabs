using System;
using System.Diagnostics;
using System.Linq;

namespace CSharpLabs1
{
    namespace Exp3
    {
        internal static class Program
        {
            private static void Main()
            {
                Console.Write(
                    (from i in Enumerable.Range(1, 9)
                     select
                     (from j in Enumerable.Range(1, i)
                      select i * j).Aggregate("", (s, v) => s + v + " ", s => s.TrimEnd()))
                    .Aggregate((s1, s2) => s1 + "\n" + s2)
                );
            }
        }
    }
}