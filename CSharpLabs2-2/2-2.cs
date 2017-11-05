using System;

namespace CSharpLabs2
{
    namespace Exp2
    {
        internal class TextBox
        {
            public string Text { get; set; }

            public string Font { get; set; }

            public TextBox() {
                Text = "text1";
                Font = "SimSun";
            }
        }
        internal static class Program
        {
            private static void Main()
            {
                var textBox = new TextBox();
                Console.WriteLine($"textBox.Text = {textBox.Text}");
                textBox.Text = "This is a TextBox";
                Console.WriteLine($"textBox.Text = {textBox.Text}");
                Console.WriteLine($"textBox.Font = {textBox.Font}");
            }
        }
    }
}
