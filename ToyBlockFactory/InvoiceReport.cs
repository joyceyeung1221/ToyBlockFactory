using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class InvoiceReport : Report
    {
        private BillableItemConverter _billableItemConverter;
        private ItemListWithPrice _itemList;

        public InvoiceReport(Dictionary<Enum, decimal> priceList)
        {
            _reportName = "Invoice Report";
            _table = new ShapeQuantityTable();
            _billableItemConverter = new BillableItemConverter(priceList);
            _itemList = new ItemListWithPrice();
        }

        public override string GenerateString(Order order)
        {
            var billableItems = _billableItemConverter.GenerateBillableItems(order.OrderItems);
            var stringToOutput = _header.GenerateString(_reportName) + "\n" +
                _orderSummary.GenerateString(order) + "\n" +
                _table.GenerateString(order.OrderItems) + "\n" +
                _itemList.GenerateString(billableItems);

            return stringToOutput;


        }
    }
}
