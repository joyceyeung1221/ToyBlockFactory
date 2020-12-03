using System;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class ConsoleReportOutputTest
    {
        public ConsoleReportOutputTest()
        {
        }

        [Fact]
        public void ShouldConvertInvoiceReportIntoASpecificString()
        {
            var formatter = new ConsoleReportFormatter(new ConsoleTableFormatter());
            var report = new InvoiceReport(TestData.TestOrder);
            var result = formatter.ConvertToString(report);

            var expected = "Your invoice report has been generated:" + "\n" +
                            "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001" + "\n" +
                             " ---------------------------------- \n" +
                             " |          | Blue | Red | Yellow |\n" +
                             " ---------------------------------- \n" +
                             " | Circle   | 0    | 2   | 3      |\n" +
                             " ---------------------------------- \n" +
                             " | Square   | 1    | 0   | 0      |\n" +
                             " ---------------------------------- \n" +
                             " | Triangle | 0    | 0   | 1      |\n" +
                             " ---------------------------------- \n\n" +
                             " Count: 3\n" +
                            "Circles,5 @ $3 ppi = $15\n" +
                            "Squares,1 @ $1 ppi = $1\n" +
                            "Triangles,1 @ $2 ppi = $2\n" +
                            "Red color surcharges,2 @ $1 ppi = $2\n";

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldConvertCuttingReportIntoASpecificString()
        {
            var formatter = new ConsoleReportFormatter(new ConsoleTableFormatter());
            var report = new CuttingListReport(TestData.TestOrder);
            var result = formatter.ConvertToString(report);

            var expected = "Your cutting list has been generated:\n" +
                            "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001\n" +
                            " ----------------------- \n" +
                            " |          | Quantity |\n" +
                            " ----------------------- \n" +
                            " | Circle   | 5        |\n" +
                            " ----------------------- \n" +
                            " | Square   | 1        |\n" +
                            " ----------------------- \n" +
                            " | Triangle | 1        |\n" +
                            " ----------------------- \n\n" +
                            " Count: 3\n";

            Assert.Equal(expected, result);
        }
    }
}
