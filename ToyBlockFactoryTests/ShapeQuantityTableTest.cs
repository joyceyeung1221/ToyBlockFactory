using System;
using System.Collections.Generic;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class ShapeQuantityTableTest
    {
        public ShapeQuantityTableTest()
        {
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
            var orderItemsCollection = new OrderItemsCollection(orderItems);
            var shapeQuantityTable = new ShapeQuantityTable();
            var results = shapeQuantityTable.GenerateString(orderItemsCollection);
            var expected = " ,Quantity\n" +
                "Circle,5\n" +
                "Square,1\n" +
                "Triangle,1\n";

            Assert.Equal(expected, results);
        }
    }
}
