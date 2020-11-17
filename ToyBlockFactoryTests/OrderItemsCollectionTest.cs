using System;
using System.Collections.Generic;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class OrderItemsCollectionTest
    {
        public OrderItemsCollectionTest()
        {
        }

        [Fact]
        public void ShouldReturnAListOfColorsWithoutDuplicateColors()
        {
            var yellow = new Color("Yellow", (decimal)1.00);
            var red = new Color("Red", (decimal)1.00);

            var item1 = new OrderItem(new Block(Shape.Circle), yellow);
            var item2 = new OrderItem(new Block(Shape.Circle), red);
            var item3 = new OrderItem(new Block(Shape.Square), yellow);
            var item4 = new OrderItem(new Block(Shape.Triangle), yellow);
            var orderItems = new List<OrderItem>
            {
                item1,item2,item3,item4
            };
            var orderItemsCollection = new OrderItemsCollection(orderItems);

            var result = orderItemsCollection.GetAllColors();

            Assert.Equal(2, result.Count);
            Assert.Contains(yellow, result);
            Assert.Contains(red, result);
        }

        [Fact]
        public void ShouldReturnAListOfBlocksWithoutDuplicateBlocks()
        {
            var yellow = new Color("Yellow", (decimal)1.00);
            var red = new Color("Red", (decimal)1.00);

            var circle = new Block(Shape.Circle);
            var sqaure = new Block(Shape.Square);
            var triangle = new Block(Shape.Triangle);

            var item1 = new OrderItem(circle, yellow);
            var item2 = new OrderItem(circle, red);
            var item3 = new OrderItem(sqaure, yellow);
            var item4 = new OrderItem(circle, yellow);

            var orderItems = new List<OrderItem>
            {
                item1,item2,item3,item4
            };
            var orderItemsCollection = new OrderItemsCollection(orderItems);

            var result = orderItemsCollection.GetAllShapes();

            Assert.Equal(2, result.Count);
            Assert.Contains(circle, result);
            Assert.Contains(sqaure, result);
        }

        [Fact]
        public void ShouldReturnTotalNumberOfTheGivenShape()
        {
            var yellow = new Color("Yellow", (decimal)1.00);
            var red = new Color("Red", (decimal)1.00);

            var circle = new Block(Shape.Circle);
            var sqaure = new Block(Shape.Square);
            var triangle = new Block(Shape.Triangle);

            var item1 = new OrderItem(circle, yellow);
            var item2 = new OrderItem(circle, red);
            var item3 = new OrderItem(sqaure, yellow);
            var item4 = new OrderItem(triangle, yellow);
            var item5 = new OrderItem(triangle, red);
            item1.SetQuantity(2);
            item2.SetQuantity(3);
            item3.SetQuantity(1);
            item4.SetQuantity(2);
            item5.SetQuantity(2);

            var orderItems = new List<OrderItem>
            {
                item1,item2,item3,item4,item5
            };
            var orderItemsCollection = new OrderItemsCollection(orderItems);

            Assert.Equal(5, orderItemsCollection.GetQuantityByShape(circle));
            Assert.Equal(4, orderItemsCollection.GetQuantityByShape(triangle));
        }

        [Fact]
        public void ShouldReturnTotalNumberOfTheGivenColor()
        {
            var yellow = new Color("Yellow", (decimal)1.00);
            var red = new Color("Red", (decimal)1.00);

            var circle = new Block(Shape.Circle);
            var sqaure = new Block(Shape.Square);
            var triangle = new Block(Shape.Triangle);

            var item1 = new OrderItem(circle, yellow);
            var item2 = new OrderItem(circle, red);
            var item3 = new OrderItem(sqaure, yellow);
            var item4 = new OrderItem(triangle, yellow);
            var item5 = new OrderItem(triangle, red);
            item1.SetQuantity(2);
            item2.SetQuantity(4);
            item3.SetQuantity(1);
            item4.SetQuantity(2);
            item5.SetQuantity(2);

            var orderItems = new List<OrderItem>
            {
                item1,item2,item3,item4,item5
            };
            var orderItemsCollection = new OrderItemsCollection(orderItems);

            Assert.Equal(5, orderItemsCollection.GetQuantityByColor(yellow));
            Assert.Equal(6, orderItemsCollection.GetQuantityByColor(red));
        }

        [Fact]
        public void ShouldReturnTotalNumberOfTheGivenColorAndShape()
        {
            var yellow = new Color("Yellow", (decimal)1.00);
            var red = new Color("Red", (decimal)1.00);

            var circle = new Block(Shape.Circle);
            var sqaure = new Block(Shape.Square);
            var triangle = new Block(Shape.Triangle);

            var item1 = new OrderItem(circle, yellow);
            var item2 = new OrderItem(circle, red);
            var item3 = new OrderItem(sqaure, yellow);
            var item4 = new OrderItem(triangle, yellow);
            var item5 = new OrderItem(triangle, red);
            item1.SetQuantity(2);
            item2.SetQuantity(4);
            item3.SetQuantity(1);
            item4.SetQuantity(2);
            item5.SetQuantity(2);

            var orderItems = new List<OrderItem>
            {
                item1,item2,item3,item4,item5
            };
            var orderItemsCollection = new OrderItemsCollection(orderItems);

            Assert.Equal(4, orderItemsCollection.GetQuantityByShapeAndColor(circle,red));
        }

        [Fact]
        public void ShouldReturnNumberOfItemsInTheCollections()
        {
            var yellow = new Color("Yellow", (decimal)1.00);
            var red = new Color("Red", (decimal)1.00);

            var circle = new Block(Shape.Circle);
            var sqaure = new Block(Shape.Square);
            var triangle = new Block(Shape.Triangle);

            var item1 = new OrderItem(circle, yellow);
            var item2 = new OrderItem(circle, red);
            var item3 = new OrderItem(sqaure, yellow);
            var item4 = new OrderItem(triangle, yellow);
            var item5 = new OrderItem(triangle, red);
            item1.SetQuantity(2);
            item2.SetQuantity(4);
            item3.SetQuantity(1);
            item4.SetQuantity(2);
            item5.SetQuantity(2);

            var orderItems = new List<OrderItem>
            {
                item1,item2,item3,item4,item5
            };
            var orderItemsCollection = new OrderItemsCollection(orderItems);

            Assert.Equal(5, orderItemsCollection.GetNumberOfItems());
        }
    }
}
