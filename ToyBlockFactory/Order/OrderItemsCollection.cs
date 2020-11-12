using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderItemsCollection
    {
        private List<OrderItem> _orderItems;

        public OrderItemsCollection(List<OrderItem> orderItems)
        {
            _orderItems = orderItems;
        }

        public List<Color> GetColors()
        {
            var colors = new List<Color>();
            foreach (var item in _orderItems)
            {
                colors.Add(item.ColorOption);
            }
            colors = RemoveDuplicate(colors);
            colors.Sort((x, y) => x.Name.CompareTo(y.Name));


            return colors;
        }

        public List<Block> GetShapeBlocks()
        {
            var shapes = new List<Block>();
            foreach (var item in _orderItems)
            {
                shapes.Add(item.Block);
            }
            shapes = RemoveDuplicate(shapes);
            shapes.Sort((x, y) => x.Shape.CompareTo(y.Shape));

            return shapes;
        }

        private List<Color> RemoveDuplicate(List<Color> colors)
        {
            var uniqueList = new List<Color>();
            foreach (var color in colors)
            {
                if (!uniqueList.Contains(color))
                {
                    uniqueList.Add(color);
                }
            }
            return uniqueList;
        }

        private List<Block> RemoveDuplicate(List<Block> blocks)
        {
            var uniqueList = new List<Block>();
            foreach (var block in blocks)
            {
                var index = uniqueList.FindIndex(x => x.Shape == block.Shape);
                if(index<0)
                {
                    uniqueList.Add(block);
                }
            }
            return uniqueList;
        }

        public int GetQuantityByShape(Block block)
        {
            var quantity = 0;
            foreach (var item in _orderItems)
            {
                if (item.Block.Shape == block.Shape)
                {
                    quantity += item.Quantity;
                }
            }
            return quantity;
        }
        public int GetQuantityByColor(Color color)
        {
            var quantity = 0;
            foreach (var item in _orderItems)
            {
                if (item.ColorOption == color)
                {
                    quantity += item.Quantity;
                }
            }
            return quantity;
        }

        public int GetQuantityByShapeAndColor(Block block, Color color)
        {
            foreach (var item in _orderItems)
            {
                if (item.ColorOption == color && item.Block.Shape == block.Shape)
                {
                    return item.Quantity;
                }
            }
            return 0;
        }

        public int GetNumberOfItems()
        {
            return _orderItems.Count;
        }

    }

}
