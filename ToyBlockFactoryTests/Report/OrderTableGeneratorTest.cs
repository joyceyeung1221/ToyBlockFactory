using System;
using System.Collections.Generic;
using System.Linq;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class OrderTableGeneratorTest
    {
        [Fact]
        public void ShouldTableHeaderContainThreeColors_WhenOrderItemsWithThreeDiffererntColorsReceived()
        {

            var orderTable = new OrderTableGenerator();
            var table = orderTable.Generate(TestData.orderItemsWithThreeColorsThreeShapes);
            var result = table.Header;
            var expectedHeader = new List<string> { "Blue", "Red", "Yellow" };

            Assert.Equal(3, result.Count);
            Assert.Contains("Red", result);
            Assert.Contains("Yellow", result);
            Assert.Contains("Blue", result);
            Assert.Equal(expectedHeader, result);
        }

        [Fact]
        public void ShouldTableHeaderContainTwoColors_WhenOrderItemsWithTwoDiffererntColorsReceived()
        {

            var orderTable = new OrderTableGenerator();
            var table = orderTable.Generate(TestData.orderItemsWithTwoColorsTwoShapes);
            var result = table.Header;
            var expectedHeader = new List<string> { "Blue", "Yellow" };

            Assert.Equal(2, result.Count);
            Assert.Contains("Yellow", result);
            Assert.Contains("Blue", result);
            Assert.Equal(expectedHeader, result);
        }

        [Fact]
        public void ShouldTableBodyContainThreeElmentsForThreeDifferntShapesWithCorrectQuantity()
        {

            var orderTable = new OrderTableGenerator();
            var table = orderTable.Generate(TestData.orderItemsWithThreeColorsThreeShapes);
            var result = table.Body;
            var expectedQuantityForCircle = new List<int>{ 0, 2, 3 };
            var expectedQuantityForSquare = new List<int>{ 1, 0, 0 };
            var expectedQuantityForTriangle = new List<int>{ 0, 0, 1 };

            Assert.Equal(3, result.Count);
            Assert.True(result["Circle"].SequenceEqual(expectedQuantityForCircle));
            Assert.True(result["Square"].SequenceEqual(expectedQuantityForSquare));
            Assert.True(result["Triangle"].SequenceEqual(expectedQuantityForTriangle));
        }

        [Fact]
        public void ShouldTableBodyContainTwoElmentsForTwoShapesWithCorrectQuantity()
        {

            var orderTable = new OrderTableGenerator();
            var table = orderTable.Generate(TestData.orderItemsWithTwoColorsTwoShapes);
            var result = table.Body;
            var expectedQuantityForSquare = new List<int> { 0,2 };
            var expectedQuantityForTriangle = new List<int> { 3,0 };

            Assert.Equal(2, result.Count);
            Assert.True(result["Square"].SequenceEqual(expectedQuantityForSquare));
            Assert.True(result["Triangle"].SequenceEqual(expectedQuantityForTriangle));

        }

    }
}
