using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderItemsList = new OrderItemFactory().CreateOrderItems();
            var orderInputValidator = new OrderInputValidator();
            var io = new ConsoleIO();
            var orderTaker = new ConsoleOrderTaker(io, orderItemsList, orderInputValidator);
            var reportOutput = new ReportOutput(new ConsoleReportParser(new ConsoleTableParser()), io);
            var reportFactory = new OrderReportFactory();

            var managementSystem = new OrderManagementSystem(orderTaker, reportOutput, reportFactory);
            managementSystem.Run();
        }
    }
}
