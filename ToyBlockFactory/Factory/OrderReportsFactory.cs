using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderReportsFactory
    {
        private OutputChannel _outputChannel;

        public OrderReportsFactory(OutputChannel outputChannel)
        {
            _outputChannel = outputChannel;
        }

        public List<OrderReport> Create(Order order)
        {
            if(_outputChannel == OutputChannel.CSV)
            {
                return new List<OrderReport>
                {
                    new InvoiceReport(order)
                };
            }
            return new List<OrderReport>
            {
                new InvoiceReport(order),
                new CuttingListReport(order),
                new PaintingReport(order)
            };
        }
    }
}
