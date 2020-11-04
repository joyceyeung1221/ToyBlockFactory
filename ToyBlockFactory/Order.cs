using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class Order
    {
        public DateTime DueDate { get; private set; }
        public Customer Customer { get; private set; }
        public OrderItemCollection OrderItems { get; private set; }
        public int OrderNumber { get; private set; }

        private static int lastOrderNumber = 0;

        public Order(DateTime dueDate, Customer customer, OrderItemCollection orderItems)
        {
            DueDate = dueDate;
            Customer = customer;
            OrderItems = orderItems;
            OrderNumber = lastOrderNumber + 1;
            lastOrderNumber += 1;
        }
    }
}
