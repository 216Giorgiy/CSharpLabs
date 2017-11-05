using System;

namespace CSharpLabs2
{
    namespace Exp5
    {
        internal interface IInterface
        {
            string Str { get; set; }
            void Print();
        }

        internal class Inherit: IInterface
        {
            public string Str { get; set; } = ".Net Interface";
            public void Print()
            {
                Console.WriteLine(Str);
            }
        }

        internal static class Program
        {
            private static void Main()
            {
                IInterface iInterface = new Inherit();
                iInterface.Print();
            }
        }
    }
}
