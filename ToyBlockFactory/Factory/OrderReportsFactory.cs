using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderReportsFactory
    {
        public List<OrderReport> Create(Order order)
        {
            return new List<OrderReport>
            {
                new InvoiceReport(order),
                new CuttingListReport(order),
                new PaintingReport(order)
            };
        }
    }
}
