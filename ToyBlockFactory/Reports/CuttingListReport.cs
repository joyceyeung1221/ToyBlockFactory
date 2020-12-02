using System;
using System.Collections.Generic;
using ToyBlockFactory.Reports.ReportComponents;

namespace ToyBlockFactory
{
    public class CuttingListReport : OrderReport
    {
        private const string ColHeaderForTable = "Quantity";

        public CuttingListReport(Order order) : base(order)
        {
            _table = GenerateShapeQuanitityTable(order.OrderItems);
            _title = "Cutting List";
        }

        private ReportTable GenerateShapeQuanitityTable(OrderItemsCollection orderItems)
        {
            var blocks = orderItems.GetAllShapes();
            var table = new ReportTable(new List<string> { ColHeaderForTable });
            ConstructTableBody(table, orderItems, blocks);

            return table;
        }

        private void ConstructTableBody(ReportTable table, OrderItemsCollection orderItems, List<Block> blocks)
        {
            foreach (var block in blocks)
            {
                var quantities = GetQuantityByShape(orderItems, block);
                table.AddRow(block.Shape.ToString(), quantities);
            }
        }

        private List<int> GetQuantityByShape(OrderItemsCollection orderItems, Block block)
        {
            var quantities = new List<int>();
            quantities.Add(orderItems.GetQuantityByShape(block));

            return quantities;
        }
    }
}



