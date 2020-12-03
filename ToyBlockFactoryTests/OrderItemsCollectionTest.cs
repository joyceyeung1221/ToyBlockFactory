using System;
using System.Collections.Generic;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class OrderItemsCollectionTest
    {
        private Color _red;
        private Color _yellow;
        private Color _blue;
        private Block _circle;
        private Block _sqaure;
        private Block _triangle;

        public OrderItemsCollectionTest()
        {
            _red = new Color("Red", (decimal)1.00);
            _yellow = new Color("Yellow", (decimal)0.00);
            _blue = new Color("Blue", (decimal)0.00);

            _circle = new Block("Circle", (decimal)3.00);
            _sqaure = new Block("Square", (decimal)1.00);
            _triangle = new Block("Triangle", (decimal)2.00);

        }

        [Fact]
        public void ShouldReturnAListOfColorsWithoutDuplicateColors()
        {
            var item1 = new OrderItem(_circle, _yellow);
            var item2 = new OrderItem(_circle, _red);
            var item3 = new OrderItem(_sqaure, _red);
            var item4 = new OrderItem(_sqaure, _yellow);
            var item5 = new OrderItem(_triangle, _yellow);
            var orderItems = new List<OrderItem>
            {
                item1,item2,item3,item4,item5
            };
            var orderItemsCollection = new OrderItemsCollection(orderItems);

            var result = orderItemsCollection.GetAllColors();

            Assert.Equal(2, result.Count);
            Assert.Contains(_yellow, result);
            Assert.Contains(_red, result);
        }

        [Fact]
        public void ShouldReturnAListOfBlocksWithoutDuplicateBlocks()
        {
            var item1 = new OrderItem(_circle, _yellow);
            var item2 = new OrderItem(_circle, _red);
            var item3 = new OrderItem(_sqaure, _yellow);
            var item4 = new OrderItem(_circle, _yellow);

            var orderItems = new List<OrderItem>
            {
                item1,item2,item3,item4
            };
            var orderItemsCollection = new OrderItemsCollection(orderItems);

            var result = orderItemsCollection.GetAllShapes();

            Assert.Equal(2, result.Count);
            Assert.Contains(_circle, result);
            Assert.Contains(_sqaure, result);
        }

        [Fact]
        public void ShouldReturnTotalNumberOfTheGivenShape()
        {
            var item1 = new OrderItem(_circle, _yellow);
            var item2 = new OrderItem(_circle, _red);
            var item3 = new OrderItem(_sqaure, _yellow);
            var item4 = new OrderItem(_triangle, _yellow);
            var item5 = new OrderItem(_triangle, _red);
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

            Assert.Equal(5, orderItemsCollection.GetQuantityByShape(_circle));
            Assert.Equal(4, orderItemsCollection.GetQuantityByShape(_triangle));
        }

        [Fact]
        public void ShouldReturnTotalNumberOfTheGivenColor()
        {
            var item1 = new OrderItem(_circle, _yellow);
            var item2 = new OrderItem(_circle, _red);
            var item3 = new OrderItem(_sqaure, _yellow);
            var item4 = new OrderItem(_triangle, _yellow);
            var item5 = new OrderItem(_triangle, _red);
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

            Assert.Equal(5, orderItemsCollection.GetQuantityByColor(_yellow));
            Assert.Equal(6, orderItemsCollection.GetQuantityByColor(_red));
        }

        [Fact]
        public void ShouldReturnTotalNumberOfTheGivenColorAndShape()
        {
            var item1 = new OrderItem(_circle, _yellow);
            var item2 = new OrderItem(_circle, _red);
            var item3 = new OrderItem(_sqaure, _yellow);
            var item4 = new OrderItem(_triangle, _yellow);
            var item5 = new OrderItem(_triangle, _red);
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

            Assert.Equal(4, orderItemsCollection.GetQuantityByShapeAndColor(_circle, _red));
        }

        [Fact]
        public void ShouldReturnNumberOfItemsInTheCollections()
        {
            var item1 = new OrderItem(_circle, _yellow);
            var item2 = new OrderItem(_circle, _red);
            var item3 = new OrderItem(_sqaure, _yellow);
            var item4 = new OrderItem(_triangle, _yellow);
            var item5 = new OrderItem(_triangle, _red);
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
