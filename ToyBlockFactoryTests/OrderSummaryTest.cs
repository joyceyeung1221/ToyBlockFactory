using System;
using System.Collections.Generic;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class OrderSummaryTest
    {
        public OrderSummaryTest()
        {
        }

        [Fact]
        public void ShouldPrintOrderDetails()
        {
            var customer = new Customer("Mark Pearl", "1 Bob Avenue, Auckland");
            var orderItems = new Dictionary<Block, int>();
            var orderItemCollection = new OrderItemsCollection(orderItems);
            var date = new DateTime(2019, 01, 19);
            var order = new Order(date, customer, orderItemCollection);

            var orderSummary = new OrderSummary();
            var result = orderSummary.GenerateString(order);
            var expected = "Name: Mark Pearl Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001";

            Assert.Equal(expected, result);

        }
    }
}
