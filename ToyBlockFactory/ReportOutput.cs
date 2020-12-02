using System;
namespace ToyBlockFactory
{
    public class ReportOutput
    {
        private IReportFormatter _formatter;
        private IReportPrinter _printer;

        public ReportOutput(IReportFormatter formatter, IReportPrinter printer)
        {
            _formatter = formatter;
            _printer = printer;
        }

        public void Print(OrderReport orderReport)
        {
            var reportInString = _formatter.ConvertToString(orderReport);
            _printer.Print(reportInString);
        }
    }
}
