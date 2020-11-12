﻿using System;
using System.Collections.Generic;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class ItemListWithPriceTest
    {
        [Fact]
        public void ShouldPrintQuantityWithUnitPriceAndTotalCost()
        {
            var customer = new Customer("Mark Pearl", "1 Bob Avenue, Auckland");
            var colors = new List<Color>
            {
                new Color("Red",(decimal)1.00),
                new Color("Yellow",(decimal)1.00),
                new Color("Blue",(decimal)1.00)
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
            var date = new DateTime(2019, 01, 19);
            var order = new Order(date, customer, orderItemsCollection);
            var itemList = new ItemListWithPrice();

            var expected =
                "Circles,5 @ $3 ppi = $15\n" +
                "Squares,1 @ $1 ppi = $1\n" +
                "Triangles,1 @ $2 ppi = $2\n" +
                "Red color surcharge,2 @ $1 ppi = $2";

            var result = itemList.GenerateString(orderItemsCollection);


            Assert.Equal(expected, result);
        }
    }
}