using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderTable : ITable
    {

        public string GenerateString(OrderItemsCollection orderItems)
        {
            var colors = orderItems.GetAllColors();
            var blocks = orderItems.GetAllShapes();

            var stringToPrint = ConstructTableUsingCommaDelimiter(orderItems, colors, blocks);

            return stringToPrint;
        }

        private string ConstructTableUsingCommaDelimiter(OrderItemsCollection orderItems, List<Color> colors, List<Block> blocks)
        {
            var stringToPrint = GetRowHeader(colors);
            foreach (var block in blocks)
            {
                stringToPrint += FillRowWithBlockQuantityByColors(orderItems, colors, block);

                if (block != blocks[^1])
                {
                    stringToPrint += "\n";
                }
            }
            return stringToPrint;
        }

        private string GetRowHeader(List<Color> colors)
        {
            var stringToPrint = " ,";
            foreach(var color in colors)
            {
                stringToPrint += color.Name;
                stringToPrint += color != colors[^1] ? "," : "\n";
            }
            return stringToPrint;
        }

        private string FillRowWithBlockQuantityByColors(OrderItemsCollection orderItems, List<Color> colors, Block block)
        {
            string stringToPrint = block.Shape + ",";
            foreach (var color in colors)
            {
                var quantity = orderItems.GetQuantityByShapeAndColor(block, color);
                stringToPrint +=  (quantity == 0 ? "-" : quantity.ToString());
                stringToPrint += (color == colors[^1] ? "" : ",");
            }
            return stringToPrint;
        }
    }
}
