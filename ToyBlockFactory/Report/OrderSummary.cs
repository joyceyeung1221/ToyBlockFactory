using System;

namespace ToyBlockFactory
{
    public class OrderSummary
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public DateTime DueDate { get; private set; }
        public int OrderNumber { get; private set; }

        public OrderSummary(Order order)
        {
            Name = order.Customer.Name;
            Address = order.Customer.Address;
            DueDate = order.DueDate;
            OrderNumber = order.OrderNumber;
        }
    }
}
