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

        public string PrintOrderTable(Dictionary<Block, int> orderItems)
        {
            var headers = GetHeaders(orderItems);
            var columnHeaders = headers.Item1;
            var rowHeaders = headers.Item2;

            var stringToPrint = ConstructOrderString(orderItems, columnHeaders, rowHeaders);
            return stringToPrint;
        }

        public string PrintQuantityTable(Dictionary<Block, int> orderItems)
        {
            var headers = GetHeaders(orderItems);
            var rowHeaders = headers.Item2;

            var stringToPrint = ConstructQuantityString(orderItems, rowHeaders);
            return stringToPrint;
        }

        private string ConstructQuantityString(Dictionary<Block, int> orderItems, List<Shape> rowHeaders)
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

        private string ConstructOrderString(Dictionary<Block, int> orderItems, List<Color> columnHeaders, List<Shape> rowHeaders)
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

        private (List<Color>, List<Shape>) GetHeaders(Dictionary<Block, int> orderItems)
        {
            var columnHeaders = new List<Color>();
            var rowHeaders = new List<Shape>();
            foreach (var item in orderItems.Keys)
            {
                columnHeaders.Add(item.Color);
                rowHeaders.Add(item.Shape);
            }
            columnHeaders = SortAndRemoveDuplicate(columnHeaders);
            rowHeaders = SortAndRemoveDuplicate(rowHeaders);

            return (columnHeaders, rowHeaders);
        }

        private string PrintColumnHeaders(List<Color> columnHeaders)
        {
            return " ," + string.Join(",", columnHeaders.ToArray()) + "\n";
        }

        private string ConstructRowString(Dictionary<Block, int> orderItems, Shape rowHeader)
        {
            string rowToPrint = "";
            var quantity = GetQuantityForEachType(rowHeader, orderItems);
            rowToPrint += quantity + "\n";

            return rowToPrint;
        }

        private string ConstructRowString(Dictionary<Block, int> orderItems, List<Color> columnHeaders, Shape rowHeader)
        {
            string rowToPrint = "";
            foreach (var columnHeader in columnHeaders)
            {
                var quantity = GetQuantityForEachType(rowHeader, columnHeader, orderItems);
                rowToPrint += quantity;
                rowToPrint += (columnHeader == columnHeaders[^1] ? "\n" : ",");
            }
            return rowToPrint;
        }

        private object GetQuantityForEachType(Shape rowHeader, Dictionary<Block, int> orderItems)
        {
            var quantity = 0;
            foreach (var item in orderItems)
            {
                var block = item.Key;
                if (block.Shape == rowHeader)
                {
                    quantity += item.Value;
                }
            }
            return quantity == 0 ? "-" : quantity.ToString();
        }

        private string GetQuantityForEachType(Shape rowHeader, Color columnHeader, Dictionary<Block, int> orderItems)
        {
            foreach(var item in orderItems)
            {
                var block = item.Key;
                if (block.Color == columnHeader && block.Shape == rowHeader)
                {
                    return item.Value.ToString();
                }
            }
            return "-";
        }

        private List<T> SortAndRemoveDuplicate<T>(List<T> headers)
        {
            var uniqueHeaders = new List<T>();
            foreach(var header in headers)
            {
                if(!uniqueHeaders.Contains(header))
                {
                    uniqueHeaders.Add(header);
                }
            }
            uniqueHeaders.Sort();
            return uniqueHeaders;
        }
    }
}
