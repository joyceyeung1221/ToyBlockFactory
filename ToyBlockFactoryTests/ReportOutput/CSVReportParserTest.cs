using System;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class CSVReportParserTest
    {
        [Fact]
        public void ShouldConvertInvoiceReportIntoASpecificString()
        {
            var parser = new CSVReportParser();
            var report = new InvoiceReport(TestData.TestOrder);
            var result = parser.FormatToString(report);

            var expected = "\"first name\",\"address\",\"due date\",\"order number\",\"squares\",\"triangles\",\"circles\",\"red color surcharges\"" + "\n" +
                            "\"Mark Pearl\",\"1 Bob Avenue, Auckland\",\"19-Jan-19\",\"0001\",\"$1\",\"$2\",\"$15\",\"$2\"\n";

            Assert.Equal(expected, result);
        }
    }
}
