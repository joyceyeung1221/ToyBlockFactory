﻿using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ReportFactory
    {
        public ReportFactory()
        {
        }

        public List<OrderReport> CreateReports(Order order)
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
