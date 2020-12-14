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
            table.ConstructTableBody(orderItems, blocks);

            return table;
        }
    }
}



