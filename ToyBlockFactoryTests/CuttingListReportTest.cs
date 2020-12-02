using System;
using System.Collections.Generic;
using System.Linq;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class CuttingListReportTest
    {
        public CuttingListReportTest()
        {
        }

        [Fact]
        public void ShouldFirstElementsOfTheListContainsOneElementAsColumnHeader()
        {

            var report = new CuttingListReport(TestData.TestOrder);
            var table = report.GetTable();
            var result = table.Header;
            var expectedHeader = new List<string> { "Quantity" };

            Assert.Equal(1, result.Count);
            Assert.Equal(expectedHeader, result);
        }

        [Fact]
        public void ShouldContainThreeDataRowsPlusHeaderListForThreeShapesWithCorrectQuantity()
        {

            var report = new CuttingListReport(TestData.TestOrder);
            var table = report.GetTable();
            var result = table.Body;
            var expectedQuantityForCircle = new List<int> { 5 };
            var expectedQuantityForSquare = new List<int> { 1 };
            var expectedQuantityForTriangle = new List<int> { 1 };

            var expectedLineOne = new List<string> { "Circle", "5" };
            var expectedLineTwo = new List<string> { "Square", "1" };
            var expectedLineThree = new List<string> { "Triangle", "1" };

            Assert.Equal(3, result.Count);
            Assert.True(result["Circle"].SequenceEqual(expectedQuantityForCircle));
            Assert.True(result["Square"].SequenceEqual(expectedQuantityForSquare));
            Assert.True(result["Triangle"].SequenceEqual(expectedQuantityForTriangle));

        }

        [Fact]
        public void ShouldContainTwoDataRowsPlusHeaderListForTwoShapesWithCorrectQuantity()
        {
            var order = new Order(TestData.TestDate, TestData.TestCustomer, TestData.orderItemsWithTwoColorsTwoShapes);
            var report = new CuttingListReport(order);
            var table = report.GetTable();
            var result = table.Body;
            var expectedQuantityForSquare = new List<int> { 2 };
            var expectedQuantityForTriangle = new List<int> { 3 };
            var expectedLineOne = new List<string> { "Square", "2" };
            var expectedLineTwo = new List<string> { "Triangle", "3" };

            Assert.Equal(2, result.Count);
            Assert.True(result["Square"].SequenceEqual(expectedQuantityForSquare));
            Assert.True(result["Triangle"].SequenceEqual(expectedQuantityForTriangle));

        }
    }
}
