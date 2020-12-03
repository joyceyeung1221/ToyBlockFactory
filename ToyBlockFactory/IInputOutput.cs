using System;
namespace ToyBlockFactory
{
    public interface IInputOutput : IReportPrinter
    {
        string Input();
    }
}
