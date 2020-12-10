using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class CuttingListReport : OrderReport
    {
        private const string ColumnHeader = "Quantity";

        public CuttingListReport(Order order) : base(order)
        {
            _title = "Cutting List";
            _table = GenerateShapeQuanitityTable(order.OrderItems);
        }

        private ReportTable GenerateShapeQuanitityTable(OrderItemsCollection orderItems)
        {
            var blocks = orderItems.GetAllShapes();
            var table = new ReportTable(new List<string> { ColumnHeader });
            table = ConstructTableBody(table, orderItems, blocks);

            return table;
        }

        private ReportTable ConstructTableBody(ReportTable table, OrderItemsCollection orderItems, List<Block> blocks)
        {
            foreach (var block in blocks)
            {
                var quantities = new List<int> { orderItems.GetQuantityByShape(block) };
                table.AddRow(block.Shape.ToString(), quantities);
            }
            return table;
        }
    }
}



