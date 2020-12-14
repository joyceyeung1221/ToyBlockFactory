using System;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class ConsoleReportParserTest
    {
        private ConsoleReportParser parser;

        [Fact]
        public void ShouldConvertNonTableDataInPaintingReportIntoASpecificString()
        {
            var parser = new ConsoleReportParser(new EmptyTableParser());
            var report = new PaintingReport(TestData.TestOrder);
            var result = parser.FormatToString(report);

            var expected = "Your painting report has been generated:" + "\n" +
                            "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001" + "\n" +
                            "";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldConvertNonTableDataInInvoiceReportIntoASpecificString()
        {
            var parser = new ConsoleReportParser(new EmptyTableParser());
            var report = new InvoiceReport(TestData.TestOrder);
            var result = parser.FormatToString(report);

            var expected = "Your invoice report has been generated:" + "\n" +
                            "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001" + "\n" +
                            "" +
                            "Circles,5 @ $3 ppi = $15\n" +
                            "Squares,1 @ $1 ppi = $1\n" +
                            "Triangles,1 @ $2 ppi = $2\n" +
                            "Red color surcharges,2 @ $1 ppi = $2\n";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldConvertNonTableDataInCuttingReportIntoASpecificString()
        {
            var parser = new ConsoleReportParser(new EmptyTableParser());
            var report = new CuttingListReport(TestData.TestOrder);
            var result = parser.FormatToString(report);

            var expected = "Your cutting list has been generated:\n" +
                                "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001\n" +
                                "";

            Assert.Equal(expected, result);
        }
    }

    public class EmptyTableParser : ITableParser
    {
        public string FormatTable(ReportTable table)
        {
            return "";
        }
    }
}
