using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderTable : ITable
    {

        public string GenerateString(OrderItemsCollection orderItems)
        {
            var columnHeaders = orderItems.GetColors();
            var rowHeaders = orderItems.GetShapes();

            var stringToPrint = ConstructOrderString(orderItems, columnHeaders, rowHeaders);
            return stringToPrint;
        }

        private string ConstructOrderString(OrderItemsCollection orderItems, List<Color> columnHeaders, List<Shape> rowHeaders)
        {
            var stringToPrint = "";
            foreach (var rowHeader in rowHeaders)
            {
                if (stringToPrint == "")
                {
                    stringToPrint += PrintColumnHeaders(columnHeaders);
                }

                stringToPrint += rowHeader + "," + ConstructRowString(orderItems, columnHeaders, rowHeader);

            }
            return stringToPrint;
        }

        private string PrintColumnHeaders(List<Color> columnHeaders)
        {
            return " ," + string.Join(",", columnHeaders.ToArray()) + "\n";
        }

        private string ConstructRowString(OrderItemsCollection orderItems, List<Color> columnHeaders, Shape rowHeader)
        {
            string rowToPrint = "";
            foreach (var columnHeader in columnHeaders)
            {
                var quantity = orderItems.GetQuantityByShapeAndColor(rowHeader, columnHeader);
                rowToPrint += (quantity == 0 ? "-" : quantity.ToString());
                rowToPrint += (columnHeader == columnHeaders[^1] ? "\n" : ",");
            }
            return rowToPrint;
        }
    }
}
