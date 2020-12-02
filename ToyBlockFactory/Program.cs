using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderItemsList = new OrderItemFactory().CreateOrderItems();
            var reportFactory = new OrderReportFactory();
            var io = new ConsoleIO();
            IReportPrinter printer = (IReportPrinter)io;
            var reportOutput = new ReportOutput(new ConsoleReportFormatter(), printer);

            var managementSystem = new OrderManagementSystem(new ConsoleOrderHandler(io, orderItemsList), reportOutput, reportFactory);
            managementSystem.Run();
        }
    }
}
