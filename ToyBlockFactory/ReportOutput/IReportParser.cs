using System;
namespace ToyBlockFactory
{
    public interface IReportParser
    {
        string ConvertToString(OrderReport report);
    }
}
