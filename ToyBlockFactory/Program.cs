using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfProducts = new List<OrderItem>
            {
                new OrderItem(new Block(Shape.Circle), new Color("Red", (decimal)1.00)),
                new OrderItem(new Block(Shape.Circle), new Color("Yellow", (decimal)0.00)),
            };

            var listOfReports = new List<Report>
            {
                new InvoiceReport(),
                new CuttingList(),
                new PaintingReport()
            };
            var io = new ConsoleIO();
            var managementSystem = new OrderManagementSystem(new ConsoleOrderHandler(io, listOfProducts), new ConsolePresenter(io), listOfReports);
            managementSystem.Run();
        }
    }
}
