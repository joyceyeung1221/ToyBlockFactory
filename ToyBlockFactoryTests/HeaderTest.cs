using System;
using ToyBlockFactory;
using Xunit;
namespace ToyBlockFactoryTests
{
    public class HeaderTest
    {
        public HeaderTest()
        {
        }

        [Theory]
        [InlineData("Invoice Report", "Your invoice report has been generated:")]
        [InlineData("Painting Report", "Your painting report has been generated:")]
        [InlineData("Cutting List", "Your cutting list has been generated:")]
        public void ShouldPrintReportName(string reportName, string expected)
        {
            var header = new Header(reportName);
            var result = header.PrintString();

            Assert.Equal(expected, result);
        }

    }
}
