using System;
using System.Collections.Generic;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class OrderTableTest
    {
        public OrderTableTest()
        {
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
            var orderTable = new OrderTable();
            var results = orderTable.GenerateString(orderItemCollection);
            var expected = " ,Blue,Red,Yellow\n" +
                "Circle,-,2,3\n" +
                "Square,1,-,-\n" +
                "Triangle,-,-,1\n";

            Assert.Equal(expected, results);
        }
    }
}
