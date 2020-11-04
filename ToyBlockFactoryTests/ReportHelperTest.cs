using System;
using System.Collections.Generic;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class ReportHelperTest
    {
        public ReportHelper helper;

        public ReportHelperTest()
        {
            helper = new ReportHelper();

        }

        [Theory]
        [InlineData("Invoice Report", "Your invoice report has been generated:")]
        [InlineData("Painting Report", "Your painting report has been generated:")]
        [InlineData("Cutting List", "Your cutting list has been generated:")]
        public void ShouldPrintReportName(string reportName, string expected)
        {
            var result = helper.PrintHeader(reportName);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ShouldPrintOrderDetails()
        {
            var customer = new Customer("Mark Pearl", "1 Bob Avenue, Auckland");
            var orderItems = new Dictionary<Block, int>();
            var orderItemCollection = new OrderItemsCollection(orderItems);
            var date = new DateTime(2019, 01, 19);
            var order = new Order(date, customer, orderItemCollection);

            var result = helper.PrintOrderSummary(order);
            var expected = "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001";

            Assert.Equal(expected, result);

        }

        [Fact]
        public void ShouldPrintTableBasedOnShapeAndColor()
        {
            var orderItems = new Dictionary<Block, int>
            {
                {new Block(Shape.Circle, Color.Red),2 },
                {new Block(Shape.Circle, Color.Yellow),3 },
                {new Block(Shape.Square, Color.Blue),1 },
                {new Block(Shape.Triangle, Color.Yellow),1 }
            };
            var orderItemCollection = new OrderItemsCollection(orderItems);

            var results = helper.PrintOrderTable(orderItemCollection);
            var expected = " ,Blue,Red,Yellow\n" +
                "Circle,-,2,3\n" +
                "Square,1,-,-\n" +
                "Triangle,-,-,1\n";

            Assert.Equal(expected, results);
        }

        [Fact]
        public void ShouldPrintQuantityTableBasedOnShape()
        {
            var orderItems = new Dictionary<Block, int>
            {
                {new Block(Shape.Circle, Color.Red),2 },
                {new Block(Shape.Circle, Color.Yellow),3 },
                {new Block(Shape.Square, Color.Blue),1 },
                {new Block(Shape.Triangle, Color.Yellow),1 }
            };
            var orderItemCollection = new OrderItemsCollection(orderItems);

            var results = helper.PrintQuantityTable(orderItemCollection);
            var expected = " ,Quantity\n" +
                "Circle,5\n" +
                "Square,1\n" +
                "Triangle,1\n";

            Assert.Equal(expected, results);
        }
    }
}
