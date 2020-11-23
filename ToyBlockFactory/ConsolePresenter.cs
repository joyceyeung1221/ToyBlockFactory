using System;
namespace ToyBlockFactory
{
    public class ConsolePresenter : IPresenter
    {
        private IInputOutput _io;

        public ConsolePresenter(IInputOutput io)
        {
            _io = io;
        }

        public void Print(string text)
        {
            _io.Output(text);
        }
    }
}
