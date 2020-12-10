using System;
namespace ToyBlockFactory
{
    public class OrderManagementSystemFactory
    {
        public static OrderManagementSystem Create(OrderItemsFactory orderItemFactory, string[] args)
        {
            var orderItemsList = orderItemFactory.Create();
            var orderInputValidator = new OrderInputValidator();
            var io = new ConsoleIO();
            var reportOutput = new ReportOutput(new ConsoleReportParser(new ConsoleTableParser()), io);
            var reportFactory = new OrderReportsFactory();
            ICreateOrder orderTaker;

            if (args.Length > 0)
            {
                var filePath = args[0];
                orderTaker = new CSVOrderTaker(new CSVInputReader(filePath), orderItemsList, orderInputValidator);
            }
            else
            {
                orderTaker = new ConsoleOrderTaker(io, orderItemsList, orderInputValidator);
            }
            return new OrderManagementSystem(orderTaker, reportOutput, reportFactory);

        }
    }
}
