using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ShapeQuantityTable : ITable
    {

        public string GenerateString(OrderItemsCollection orderItems)
        {
            var blocks = orderItems.GetAllShapes();
            var stringToPrint = ConstructTableUsingCommaDelimiter(orderItems, blocks);

            return stringToPrint;
        }

        private string ConstructTableUsingCommaDelimiter(OrderItemsCollection orderItems, List<Block> blocks)
        {
            var stringToPrint = GetRowHeader();

            foreach (var block in blocks)
            {
                stringToPrint += FillRowWithBlockQuantity(orderItems, block);

                if (block != blocks[^1])
                {
                    stringToPrint += "\n";
                }
            }
            return stringToPrint;
        }

        private string GetRowHeader()
        {
            return " ,Quantity\n";
        }

        private string FillRowWithBlockQuantity(OrderItemsCollection orderItems, Block block)
        {
            string stringToPrint = block.Shape + ",";
            var quantity = orderItems.GetQuantityByShape(block);
            stringToPrint += (quantity == 0 ? "-" : quantity.ToString());

            return stringToPrint;
        }
    }
}
