using System;
namespace ToyBlockFactory
{
    public class ReportOutput
    {
        private IReportParser _reportParser;
        private IReportPrinter _printer;

        public ReportOutput(IReportParser reportParser, IReportPrinter printer)
        {
            _reportParser = reportParser;
            _printer = printer;
        }

        public void Print(OrderReport orderReport)
        {
            var output = _reportParser.FormatToString(orderReport);
            _printer.Print(output);
        }
    }
}
