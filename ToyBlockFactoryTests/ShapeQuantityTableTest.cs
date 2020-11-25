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
            var colors = new List<Color>
            {
                new Color("Red",(decimal)1.00),
                new Color("Yellow",(decimal)0.00),
                new Color("Blue",(decimal)0.00)
            };

            var item1 = new OrderItem(new Block(Shape.Circle), colors[0]);
            var item2 = new OrderItem(new Block(Shape.Circle), colors[1]);
            var item3 = new OrderItem(new Block(Shape.Square), colors[2]);
            var item4 = new OrderItem(new Block(Shape.Triangle), colors[1]);
            item1.SetQuantity(2);
            item2.SetQuantity(3);
            item3.SetQuantity(1);
            item4.SetQuantity(1);

            var orderItems = new List<OrderItem>
            {
                item1,item2,item3,item4
            };
            var orderItemsCollection = new OrderItemsCollection(orderItems);
            var shapeQuantityTable = new ShapeQuantityTable();
            var results = shapeQuantityTable.GenerateString(orderItemsCollection);
            var expected = " ,Quantity\n" +
                "Circle,5\n" +
                "Square,1\n" +
                "Triangle,1";

            Assert.Equal(expected, results);
        }
    }
}
