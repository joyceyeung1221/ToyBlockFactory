using System;
namespace ToyBlockFactory
{
    public class ConsoleIO : IInputOutput , IReportPrinter
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
            Console.WriteLine(text);
        }

        public void Print(string text)
        {
            Output(text);
        }
    }
}
