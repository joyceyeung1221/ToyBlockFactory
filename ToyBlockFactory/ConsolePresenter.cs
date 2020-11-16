using System;
namespace ToyBlockFactory
{
    public class ConsolePresenter : IPresenter
    {
        private IIO _io;

        public ConsolePresenter(IIO io)
        {
            _io = io;
        }

        public void Print(string text)
        {
            _io.Output(text);
        }
    }
}
