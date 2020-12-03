using System;
namespace ToyBlockFactory
{
    public interface IReportFormatter
    {
        string ConvertToString(OrderReport report);
    }
}
