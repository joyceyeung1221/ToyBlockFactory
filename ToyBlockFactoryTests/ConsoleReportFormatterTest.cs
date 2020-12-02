using System;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class ConsoleReportFormatterTest
    {
        private ConsoleReportFormatter _formatter;

        public ConsoleReportFormatterTest()
        {
            _formatter = new ConsoleReportFormatter();
        }

        [Fact]
        public void ShouldConvertCuttingReportIntoASpecificString()
        {
            var report = new CuttingListReport(TestData.TestOrder);
            var result = _formatter.ConvertToString(report);

            var expected = "Your cutting list has been generated:\n" +
                                "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001\n" +
                                " ,Quantity\n" +
                                "Circle,5\n" +
                                "Square,1\n" +
                                "Triangle,1\n";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldConvertPaintingReportIntoASpecificString()
        {
            var report = new PaintingReport(TestData.TestOrder);
            var result = _formatter.ConvertToString(report);

            var expected = "Your painting report has been generated:" + "\n" +
                            "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001" + "\n" +
                            " ,Blue,Red,Yellow\n" +
                            "Circle,-,2,3\n" +
                            "Square,1,-,-\n" +
                            "Triangle,-,-,1\n";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldConvertInvoiceReportIntoASpecificString()
        {
            var report = new InvoiceReport(TestData.TestOrder);
            var result = _formatter.ConvertToString(report);

            var expected = "Your invoice report has been generated:" + "\n" +
                            "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001" + "\n" +
                            " ,Blue,Red,Yellow\n" +
                            "Circle,-,2,3\n" +
                            "Square,1,-,-\n" +
                            "Triangle,-,-,1\n" +
                            "Circles,5 @ $3 ppi = $15\n" +
                            "Squares,1 @ $1 ppi = $1\n" +
                            "Triangles,1 @ $2 ppi = $2\n" +
                            "Red color surcharges,2 @ $1 ppi = $2\n";

            Assert.Equal(expected, result);
        }
    }
}
