using System;
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
            var result = header.GetString();

            Assert.Equal(expected, result);
        }
    }
}
