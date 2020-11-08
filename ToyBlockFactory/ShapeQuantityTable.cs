using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ShapeQuantityTable : ITable
    {

        public string GenerateString(OrderItemsCollection orderItems)
        {
            var rowHeaders = orderItems.GetShapes();
            var stringToPrint = ConstructQuantityString(orderItems, rowHeaders);
            return stringToPrint;
        }

        private string ConstructQuantityString(OrderItemsCollection orderItems, List<Shape> rowHeaders)
        {
            var stringToPrint = "";
            foreach (var rowHeader in rowHeaders)
            {
                if (stringToPrint == "")
                {
                    stringToPrint += " ,Quantity\n";
                }

                stringToPrint += rowHeader + "," + ConstructRowString(orderItems, rowHeader);

            }
            return stringToPrint;
        }



        private string ConstructRowString(OrderItemsCollection orderItems, Shape rowHeader)
        {
            string rowToPrint = "";
            var quantity = orderItems.GetQuantityByShape(rowHeader);
            rowToPrint += (quantity == 0 ? "-" : quantity.ToString()) + "\n";

            return rowToPrint;
        }
    }
}
