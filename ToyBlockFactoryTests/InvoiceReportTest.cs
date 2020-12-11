using System;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class InvoiceReportTest
    {
        [Fact]
        public void ShouldContainFourElementsWithFourItemOrderDetailsInTheList()
        {
            var order = new Order(DateTime.Today, TestData.TestCustomer, TestData.orderItemsWithThreeColorsThreeShapes);
            var report = new InvoiceReport(order);
            var result = report.GetItemList();

            var expectedFirstElement = new InvoiceItem("Circle", 5, 3, 15);
            var expectedSecondElement = new InvoiceItem("Square", 1, 1, 1);
            var expectedThirdElement = new InvoiceItem("Triangle", 1, 2, 2);
            var expectedForthElement = new InvoiceItem("Red color surcharge", 2, 1, 2);

            Assert.Equal(4, result.Count);
            Assert.True(IsMatch(expectedFirstElement, result[0]));
            Assert.True(IsMatch(expectedSecondElement, result[1]));
            Assert.True(IsMatch(expectedThirdElement, result[2]));
            Assert.True(IsMatch(expectedForthElement, result[3]));

        }

        private bool IsMatch(InvoiceItem a, InvoiceItem b)
        {
            return a.Name == b.Name &&
            a.PricePerItem == b.PricePerItem &&
            a.Quantity == b.Quantity &&
            a.TotalCost == b.TotalCost;
        }
    }
}
