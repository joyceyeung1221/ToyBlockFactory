using System;
namespace ToyBlockFactory
{
    public class ConsoleIO : IInputOutput
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
