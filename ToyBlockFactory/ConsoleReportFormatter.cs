using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ConsoleReportFormatter : IReportFormatter
    {
        public ConsoleReportFormatter()
        {
        }

        public string ConvertToString(OrderReport report)
        {
            var stringToOutput = ConvertHeader(report) + ConvertOrderSummary(report.GetOrderSummary()) + ConvertTable(report.GetTable());
            if(report is InvoiceReport)
            {
                stringToOutput += ConvertItemsList(((InvoiceReport)report).GetItemList());
            }
            return stringToOutput;
        }

        private string ConvertHeader(OrderReport report)
        {
            return $"Your {report.GetTitle().ToLower()} has been generated:\n";
        }

        private string ConvertOrderSummary(OrderSummary orderSummary)
        {
            return $"Name: {orderSummary.Name} " +
            $"Address: {orderSummary.Address} " +
            $"Due Date: {orderSummary.DueDate.ToString("dd MMM yyyy")} " +
            $"Order #: {orderSummary.OrderNumber.ToString("D4")}\n";
        }

        private string ConvertTable(ReportTable table)
        {
            var stringToOutput = " ," + String.Join(",", table.Header) + "\n";
            foreach (var row in table.Body)
            {
                stringToOutput += row.Key + ",";
                foreach (var number in row.Value)
                {
                    stringToOutput += (number == 0 ? "-" : number.ToString()) + ",";
                }
                stringToOutput = stringToOutput.Remove(stringToOutput.Length - 1, 1) + "\n";
            }

            return stringToOutput;
        }

        private string ConvertItemsList(List<InvoiceItem> itemsList)
        {
            string stringToOutput = "";
            foreach (var invoiceItem in itemsList)
            {
                stringToOutput += $"{invoiceItem.Name}s," +
                                    $"{invoiceItem.Quantity} @ $" +
                                    $"{invoiceItem.PricePerItem} ppi = $" +
                                    $"{invoiceItem.TotalCost}\n";

            }

            return stringToOutput;
        }
    }
}
