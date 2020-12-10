using System;
namespace ToyBlockFactory
{
    public interface IReportParser
    {
        string FormatToString(OrderReport report);
    }
}
