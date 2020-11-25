using System;
namespace ToyBlockFactory
{
    public class CuttingListReport : Report
    {
        public CuttingListReport()
        {
            _reportName = "Cutting List";
            _table = new ShapeQuantityTable();
        }

        public override string GenerateString(Order order)
        {
            var stringToOutput = _header.GenerateString(_reportName) + "\n" +
                _orderSummary.GenerateString(order) + "\n" +
                _table.GenerateString(order.OrderItems);

            return stringToOutput;
        }
    }
}



