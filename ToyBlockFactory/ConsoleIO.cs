using System;
namespace ToyBlockFactory
{
    public class ConsoleIO : IInputOutput
    {

        public string Input()
        {
            return Console.ReadLine();
        }

        public void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
