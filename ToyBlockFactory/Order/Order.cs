﻿using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class Order
    {
        public DateTime DueDate { get; private set; }
        public Customer Customer { get; private set; }
        public OrderItemsCollection OrderItems { get; private set; }
        public int OrderNumber { get; private set; }
        
        public Order(DateTime dueDate, Customer customer, OrderItemsCollection orderItems)
        {
            DueDate = dueDate;
            Customer = customer;
            OrderItems = orderItems;
        }

        public void AssignOrderNumber(int orderNumber)
        {
            OrderNumber = orderNumber;
        }
    }
}
