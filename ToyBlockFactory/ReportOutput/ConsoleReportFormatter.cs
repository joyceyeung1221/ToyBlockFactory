using System;
using ConsoleTables;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ConsoleReportFormatter : IReportFormatter
    {
        private ITableFormatter _tableFormatter;

        public ConsoleReportFormatter(ITableFormatter tableFormatter)
        {
            _tableFormatter = tableFormatter;
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
            return _tableFormatter.ConvertTable(table);
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
