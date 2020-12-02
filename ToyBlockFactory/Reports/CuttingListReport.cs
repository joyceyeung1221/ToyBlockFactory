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
            ConstructTableBody(table, orderItems, blocks);

            return table;
        }

        private void ConstructTableBody(ReportTable table, OrderItemsCollection orderItems, List<Block> blocks)
        {
            foreach (var block in blocks)
            {
                var quantities = GetQuantities(orderItems, block);
                table.AddRow(block.Shape.ToString(), quantities);
            }
        }

        private List<int> GetQuantities(OrderItemsCollection orderItems, Block block)
        {
            var quantities = new List<int>();
            quantities.Add(orderItems.GetQuantityByShape(block));

            return quantities;
        }
    }
}



