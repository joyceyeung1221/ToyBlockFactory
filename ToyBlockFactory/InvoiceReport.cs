using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class InvoiceReport : Report
    {

        public InvoiceReport(Dictionary<Enum, decimal> priceList)
        {
            _reportName = "Invoice Report";
            _table = new ShapeQuantityTable();
        }

        public override string GenerateString(Order order)
        {
            var stringToOutput = _header.GenerateString(_reportName) + "\n" +
                _orderSummary.GenerateString(order) + "\n";

            return stringToOutput;


        }
    }
}
