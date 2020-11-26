using System;
using System.Collections.Generic;
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
        public void ShouldPrintReportInStringWithSpecificFormat()
        {
            var customer = new Customer("Mark Pearl", "1 Bob Avenue, Auckland");
            var colors = new List<Color>
            {
                new Color("Red",(decimal)1.00),
                new Color("Yellow",(decimal)0.00),
                new Color("Blue",(decimal)0.00)
            };

            var item1 = new OrderItem(new Block(Shape.Circle), colors[0]);
            var item2 = new OrderItem(new Block(Shape.Circle), colors[1]);
            var item3 = new OrderItem(new Block(Shape.Square), colors[2]);
            var item4 = new OrderItem(new Block(Shape.Triangle), colors[0]);
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
            var report = new CuttingListReport();

            var result = report.GenerateString(order);
            var expected = "Your cutting list has been generated:" + "\n" +
                            "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001" + "\n" +
                            " ,Quantity\n" +
                            "Circle,5\n" +
                            "Square,1\n" +
                            "Triangle,1";
            Assert.Equal(expected, result);
        }
    }
}
