using System;
using System.Collections.Generic;
using ToyBlockFactory;

namespace ToyBlockFactoryTests
{
    public class TestData
    {

        public static List<Block> Blocks = GetBlocks();
        public static List<Color> Colors = GetColors();
        public static OrderItemsCollection orderItemsWithThreeColorsThreeShapes = GenerateOrderItems();
        public static OrderItemsCollection orderItemsWithTwoColorsTwoShapes = GenerateOrderItemsWithTwoColorsTwoShapes();




        private static List<Color> GetColors()
        {
            return new List<Color>
            {
                new Color("Red", (decimal)1.00),
                new Color("Yellow", (decimal)0.00),
                new Color("Blue", (decimal)0.00)
            };
        }

        private static List<Block> GetBlocks()
        {
            return new List<Block>
            {

                new Block("Circle", (decimal)3.00),
                new Block("Square", (decimal)1.00),
                new Block("Triangle", (decimal)2.00)
            };
        }

        private static OrderItemsCollection GenerateOrderItems()
        {
            var item1 = new OrderItem(Blocks[0], Colors[0]);
            var item2 = new OrderItem(Blocks[0], Colors[1]);
            var item3 = new OrderItem(Blocks[1], Colors[2]);
            var item4 = new OrderItem(Blocks[2], Colors[1]);
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
            var item1 = new OrderItem(Blocks[1], Colors[1]);
            var item2 = new OrderItem(Blocks[2], Colors[2]);
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
            order.SetOrderNumber(1);
            return order;
        }

    }

}
