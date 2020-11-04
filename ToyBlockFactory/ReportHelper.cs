using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ReportHelper
    {

        public string PrintHeader(string reportName)
        {
            return $"Your {reportName.ToLower()} has been generated:";
        }

        public string PrintOrderSummary(Order order)
        {
            var customer = order.Customer;
            var summary = $"Name: {customer.Name} " +
                $"Address: {customer.Address} " +
                $"Due Date: {order.DueDate.ToString("dd MMM yyyy")} " +
                $"Order #: {order.OrderNumber.ToString("D4")}";
            return summary;
        }

        public string PrintOrderTable(OrderItemsCollection orderItems)
        {
            var columnHeaders = orderItems.GetColors();
            var rowHeaders = orderItems.GetShapes();

            var stringToPrint = ConstructOrderString(orderItems, columnHeaders, rowHeaders);
            return stringToPrint;
        }

        public string PrintQuantityTable(OrderItemsCollection orderItems)
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

        private string ConstructRowString(OrderItemsCollection orderItems, Shape rowHeader)
        {
            string rowToPrint = "";
            var quantity = orderItems.GetQuantityByShape(rowHeader);
            rowToPrint += (quantity == 0? "-" : quantity.ToString()) + "\n";

            return rowToPrint;
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
