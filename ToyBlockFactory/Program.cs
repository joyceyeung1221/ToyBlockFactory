using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderItemsList = new OrderItemFactory().CreateOrderItems();

            var listOfReports = new List<Report>
            {
                new InvoiceReport(),
                new CuttingListReport(),
                new PaintingReport()
            };

            var io = new ConsoleIO();
            var managementSystem = new OrderManagementSystem(new ConsoleOrderHandler(io, orderItemsList), new ConsolePresenter(io), listOfReports);
            managementSystem.Run();
        }
    }
}
