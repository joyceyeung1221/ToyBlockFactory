using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderItemsCollection
    {
        private Dictionary<Block, int> _orderItems;

        public OrderItemsCollection(Dictionary<Block, int> orderItems)
        {
            _orderItems = orderItems;
        }

        public List<Color> GetColors()
        {
            var colors = new List<Color>();
            foreach (var item in _orderItems.Keys)
            {
                colors.Add(item.Color);
            }
            colors = SortAndRemoveDuplicate(colors);

            return colors;
        }

        public List<Shape> GetShapes()
        {
            var shapes = new List<Shape>();
            foreach (var item in _orderItems.Keys)
            {
                shapes.Add(item.Shape);
            }
            shapes = SortAndRemoveDuplicate(shapes);

            return shapes;
        }

        private List<T> SortAndRemoveDuplicate<T>(List<T> headers)
        {
            var uniqueHeaders = new List<T>();
            foreach (var header in headers)
            {
                if (!uniqueHeaders.Contains(header))
                {
                    uniqueHeaders.Add(header);
                }
            }
            uniqueHeaders.Sort();
            return uniqueHeaders;
        }

        public int GetQuantityByShape(Shape shape)
        {
            var quantity = 0;
            foreach (var item in _orderItems)
            {
                var block = item.Key;
                if (block.Shape == shape)
                {
                    quantity += item.Value;
                }
            }
            return quantity;
        }

        public int GetQuantityByShapeAndColor(Shape shape, Color color)
        {
            foreach (var item in _orderItems)
            {
                var block = item.Key;
                if (block.Color == color && block.Shape == shape)
                {
                    return item.Value;
                }
            }
            return 0;
        }

    }

}
