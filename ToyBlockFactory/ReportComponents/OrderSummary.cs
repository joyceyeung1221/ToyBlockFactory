using System;
namespace ToyBlockFactory
{
    public class OrderSummary
    {
        public string GenerateString(Order order)
        {
            var customer = order.Customer;
            var summary = $"Name: {customer.Name} " +
                $"Address: {customer.Address} " +
                $"Due Date: {order.DueDate.ToString("dd MMM yyyy")} " +
                $"Order #: {order.OrderNumber.ToString("D4")}";
            return summary;
        }
    }
}
