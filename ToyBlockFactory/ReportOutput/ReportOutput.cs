using System;
namespace ToyBlockFactory
{
    public class ReportOutput
    {
        private IReportParser _parser;
        private IReportPrinter _printer;

        public ReportOutput(IReportParser reportParser, IReportPrinter printer)
        {
            _parser = reportParser;
            _printer = printer;
        }

        public void Print(OrderReport orderReport)
        {
            var output = _parser.ConvertToString(orderReport);
            _printer.Print(output);
        }
    }
}
