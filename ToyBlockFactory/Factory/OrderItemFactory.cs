using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderItemFactory
    {
        private List<Color> _colors;

        public OrderItemFactory()
        {
            _colors = new List<Color>
            {
                new Color("Blue", (decimal)0.00),
                new Color("Yellow", (decimal)0.00),
                new Color("Red", (decimal)1.00)
            };
        }

        public List<OrderItem> CreateOrderItems()
        {
            var orderItems = new List<OrderItem>();
            foreach(Shape shape in Enum.GetValues(typeof(Shape)))
            {
                foreach(var color in _colors)
                {
                    var orderItem = new OrderItem(new Block(shape), color);
                    orderItems.Add(orderItem);
                }
            }
            return orderItems;
        }
    }
}
