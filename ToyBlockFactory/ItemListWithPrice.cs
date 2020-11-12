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
            var shapeOrders = new List<(Block, int)>();
            foreach (var block in blocks)
            {
                var quantity = orderItems.GetQuantityByShape(block);
                shapeOrders.Add((block, quantity));
            }

            var colors = orderItems.GetColors();
            var colorOrders = new List<(Color, int)>();
            foreach (var color in colors)
            {
                if (color.Price != 0)
                {
                    var quantity = orderItems.GetQuantityByColor(color);
                    colorOrders.Add((color, quantity));
                }
            }
            foreach (var shapeOrder in shapeOrders)
            {
                var block = shapeOrder.Item1;
                var quantity = shapeOrder.Item2;
                stringToPrint += $"{block.Shape}s,{quantity} @ ${block.Price} ppi = ${quantity * block.Price}";
                if (shapeOrder != shapeOrders[^1])
                {
                    stringToPrint += "\n";
                }
            }
            if(colorOrders.Count != 0)
            {
                foreach(var colorOption in colorOrders)
                {
                    var color = colorOption.Item1;
                    var quantity = colorOption.Item2;
                    stringToPrint += $"\n{color.Name} color surcharge,{quantity} @ ${color.Price} ppi = ${quantity * color.Price}";
                }
            }
            return stringToPrint;
        }
    }
}
