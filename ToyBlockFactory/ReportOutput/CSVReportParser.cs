using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class CSVReportParser : IReportParser
    {
        private readonly List<string> _itemNames = new List<string>
        {
            "square",
            "triangle",
            "circle",
            "red color surcharge"
        };

        public string FormatToString(OrderReport report)
        {
            var stringToOutput = GetCSVHeader();
            stringToOutput += ConstructDataRow(report);

            return stringToOutput;
        }

        private string ConstructDataRow(OrderReport report)
        {
            string stringToOutput =
                "\n" + ConvertOrderSummary(report.GetOrderSummary()) +
                ConvertItemsList(((InvoiceReport)report).GetItemList());

            return stringToOutput;
        }

        private string ConvertOrderSummary(OrderSummary orderSummary)
        {
            string stringToOutput =
                $"\"{orderSummary.Name}\"" + "," +
                $"\"{orderSummary.Address}\"" + "," +
                $"\"{orderSummary.DueDate.ToString("dd-MMM-yy")}\"" + "," +
                $"\"{orderSummary.OrderNumber.ToString("D4")}\"" + ",";

            return stringToOutput;
        }

        private string ConvertItemsList(List<InvoiceItem> itemsList)
        {
            var stringToOutput = "";
            foreach (var name in _itemNames)
            {
                if(itemsList.Exists(x => x.Name.ToLower() == name))
                {
                    var item = itemsList.Find(x => x.Name.ToLower() == name);
                    stringToOutput += $"\"${item.TotalCost}\"" + GetDelimiter(name);
                }
            }
            return stringToOutput;
        }

        private string GetCSVHeader()
        {
            var stringToOutput = "\"first name\",\"address\",\"due date\",\"order number\",";
            stringToOutput += GetItemsHeader();

            return stringToOutput;
        }

        private string GetItemsHeader()
        {
            var stringToOutput = "";
            foreach(var name in _itemNames)
            {
                stringToOutput += $"\"{name}s\"" + GetDelimiter(name);
            }
            return stringToOutput;
        }

        private string GetDelimiter(string name)
        {
            return name != _itemNames[^1] ? "," : "";

        }
    }
}
