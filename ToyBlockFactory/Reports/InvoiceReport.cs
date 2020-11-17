using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class InvoiceReport : Report
    {
        private ItemListWithPrice _itemList;

        public InvoiceReport()
        {
            _reportName = "Invoice Report";
            _table = new ShapeQuantityTable();
            _itemList = new ItemListWithPrice();
        }

        public override string GenerateString(Order order)
        {
            var stringToOutput = _header.GenerateString(_reportName) + "\n" +
                _orderSummary.GenerateString(order) + "\n" +
                _table.GenerateString(order.OrderItems) + "\n" +
                _itemList.GenerateString(order.OrderItems);

            return stringToOutput;
        }
    }
}
