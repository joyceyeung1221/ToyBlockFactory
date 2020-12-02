using System;
using System.Collections.Generic;
using ToyBlockFactory;

namespace ToyBlockFactoryTests
{
    public class TestData
    {
        public static OrderItemsCollection orderItemsWithThreeColorsThreeShapes = GenerateOrderItems();
        public static OrderItemsCollection orderItemsWithTwoColorsTwoShapes = GenerateOrderItemsWithTwoColorsTwoShapes();

        private static OrderItemsCollection GenerateOrderItems()
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

            return new OrderItemsCollection(orderItems);
        }

        private static OrderItemsCollection GenerateOrderItemsWithTwoColorsTwoShapes()
        {
            var colors = new List<Color>
            {
                new Color("Yellow",(decimal)0.00),
                new Color("Blue",(decimal)0.00)
            };

            var item1 = new OrderItem(new Block(Shape.Square), colors[0]);
            var item2 = new OrderItem(new Block(Shape.Triangle), colors[1]);
            item1.SetQuantity(2);
            item2.SetQuantity(3);

            var orderItems = new List<OrderItem>
            {
                item1,item2
            };

            return new OrderItemsCollection(orderItems);
        }

        public static Customer TestCustomer = new Customer("Mark Pearl", "1 Bob Avenue, Auckland");

        public static DateTime TestDate = new DateTime(2019, 01, 19);


        public static Order TestOrder = GetOrder();

        public static Order GetOrder()
        {
            var order = new Order(TestDate, TestCustomer, orderItemsWithThreeColorsThreeShapes);
            order.AssignOrderNumber(1);
            return order;
        }

    }

}
