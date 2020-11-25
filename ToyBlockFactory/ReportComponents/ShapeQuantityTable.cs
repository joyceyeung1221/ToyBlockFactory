using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ShapeQuantityTable : ITable
    {

        public string GenerateString(OrderItemsCollection orderItems)
        {
            var blocks = orderItems.GetAllShapes();
            var stringToPrint = ConstructQuantityString(orderItems, blocks);
            return RemoveNewLineAtTheEnd(stringToPrint);
        }


        private string RemoveNewLineAtTheEnd(string stringToPrint)
        {
            return stringToPrint.Remove(stringToPrint.Length - 1);
        }

        private string ConstructQuantityString(OrderItemsCollection orderItems, List<Block> rowHeaders)
        {
            var stringToPrint = "";
            foreach (var block in rowHeaders)
            {
                if (stringToPrint == "")
                {
                    stringToPrint += " ,Quantity\n";
                }

                stringToPrint += block.Shape + "," + ConstructRowString(orderItems, block);

            }
            return stringToPrint;
        }



        private string ConstructRowString(OrderItemsCollection orderItems, Block rowHeader)
        {
            string rowToPrint = "";
            var quantity = orderItems.GetQuantityByShape(rowHeader);
            rowToPrint += (quantity == 0 ? "-" : quantity.ToString()) + "\n";

            return rowToPrint;
        }
    }
}
