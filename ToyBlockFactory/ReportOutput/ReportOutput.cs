using System;

namespace ToyBlockFactory
{
    public class ReportOutput
    {
        private IReportParser _reportParser;
        private IReportPrinter _reportPrinter;

        public ReportOutput(IReportParser reportParser, IReportPrinter reportPrinter)
        {
            _reportParser = reportParser;
            _reportPrinter = reportPrinter;
        }

        public void Print(OrderReport orderReport)
        {
            var output = _reportParser.FormatToString(orderReport);
            _reportPrinter.Print(output);
        }
    }
}
