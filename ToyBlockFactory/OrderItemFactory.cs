using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderItemFactory
    {
        private List<(string, decimal)> _colors;

        public OrderItemFactory()
        {
            _colors = new List<(string, decimal)>
            {
                ("yellow", (decimal)0.00),
                ("blue", (decimal)0.00),
                ("red", (decimal)1.00),
            };
        }

        public List<OrderItem> CreateOrderItems()
        {
            var orderItems = new List<OrderItem>();
            foreach(Shape shape in Enum.GetValues(typeof(Shape)))
            {
                foreach(var color in _colors)
                {
                    var orderItem = new OrderItem(new Block(shape), new Color(color.Item1, color.Item2));
                    orderItems.Add(orderItem);
                }
            }
            return orderItems;
        }
    }
}
