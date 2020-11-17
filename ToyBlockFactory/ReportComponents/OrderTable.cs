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

            var stringToPrint = ConstructOrderString(orderItems, colors, blocks);
            return stringToPrint;
        }

        private string ConstructOrderString(OrderItemsCollection orderItems, List<Color> columnHeaders, List<Block> rowHeaders)
        {
            var stringToPrint = "";
            foreach (var block in rowHeaders)
            {
                if (stringToPrint == "")
                {
                    stringToPrint += GeneratePrintableColumnHeaders(columnHeaders);
                }

                stringToPrint += block.Shape + "," + ConstructRowString(orderItems, columnHeaders, block);

            }
            return stringToPrint;
        }

        private string GeneratePrintableColumnHeaders(List<Color> columnHeaders)
        {
            var stringToExtract = " ,";
            foreach(var color in columnHeaders)
            {
                stringToExtract += color.Name;
                stringToExtract += color != columnHeaders[^1] ? "," : "\n";
            }
            return stringToExtract;
        }

        private string ConstructRowString(OrderItemsCollection orderItems, List<Color> columnHeaders, Block block)
        {
            string rowToPrint = "";
            foreach (var columnHeader in columnHeaders)
            {
                var quantity = orderItems.GetQuantityByShapeAndColor(block, columnHeader);
                rowToPrint += (quantity == 0 ? "-" : quantity.ToString());
                rowToPrint += (columnHeader == columnHeaders[^1] ? "\n" : ",");
            }
            return rowToPrint;
        }
    }
}
