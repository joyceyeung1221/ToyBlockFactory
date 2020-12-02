using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class PaintingReport : OrderReport
    {
        public PaintingReport(Order order) : base(order)
        {
            _table = new OrderTableGenerator().Generate(order.OrderItems);
            _title = "Painting Report";
        }
    }
}
