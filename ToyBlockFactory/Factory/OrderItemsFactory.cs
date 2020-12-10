using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderItemsFactory
    {
        private List<Color> _colors;
        private List<Block> _shapes;

        public OrderItemsFactory()
        {
            _colors = new List<Color>
            {
                new Color("Blue", (decimal)0.00),
                new Color("Yellow", (decimal)0.00),
                new Color("Red", (decimal)1.00)
            };

            _shapes = new List<Block>
            {
                new Block("Circle", (decimal)3.00),
                new Block("Square", (decimal)1.00),
                new Block("Triangle", (decimal)2.00),
            };
        }

        public List<OrderItem> Create()
        {
            var orderItems = new List<OrderItem>();
            foreach(var shape in _shapes)
            {
                foreach(var color in _colors)
                {
                    var orderItem = new OrderItem(shape, color);
                    orderItems.Add(orderItem);
                }
            }
            return orderItems;
        }
    }
}
