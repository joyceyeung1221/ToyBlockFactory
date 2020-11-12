using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ItemListWithPrice
    {
        public ItemListWithPrice()
        {
        }

        public string GenerateString(OrderItemsCollection orderItems)
        {
            var stringToPrint = "";
            var blocks = orderItems.GetShapeBlocks();
            var shapeOrders = new Dictionary<Block, int>();
            foreach (var block in blocks)
            {
                var quantity = orderItems.GetQuantityByShape(block);
                shapeOrders.Add(block, quantity);
            }

            var colors = orderItems.GetColors();
            var colorOrders = new Dictionary<Color, int>();
            foreach (var color in colors)
            {
                if (color.Price != 0)
                {
                    var quantity = orderItems.GetQuantityByColor(color);
                    colorOrders.Add(color, quantity);
                }
            }
            foreach (var shapeOrder in shapeOrders)
            {
                stringToPrint += $"{shapeOrder.Key.Shape},{shapeOrder.Value} @ ${shapeOrder.Key.Price} ppi = ${shapeOrder.Value * shapeOrder.Key.Price}";
                if (shapeOrder != shapeOrders[^1])
                {
                    stringToPrint += "\n";
                }
            }
            return stringToPrint;
        }
    }
}
