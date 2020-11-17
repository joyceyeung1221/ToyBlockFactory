using System;
namespace ToyBlockFactory
{
    public class ConsoleIO : IIO
    {
        public ConsoleIO()
        {
        }

        public string Input()
        {
            return Console.ReadLine();
        }

        public void Output(string text)
        {
            Console.Write(text);
        }
    }
}
