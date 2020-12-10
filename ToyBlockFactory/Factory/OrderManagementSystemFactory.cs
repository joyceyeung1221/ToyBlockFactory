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
            OrderReportsFactory orderReportFactory;
            ICreateOrder orderTaker;
            ReportOutput reportOutput;

            if (args.Length > 0)
            {
                var filePath = args[0];
                orderReportFactory = new OrderReportsFactory(OutputChannel.CSV);
                reportOutput = new ReportOutput(new CSVReportParser(), new CSVReportPrinter());
                orderTaker = new CSVOrderTaker(new CSVInputReader(filePath), orderItemsList, orderInputValidator);
            }
            else
            {
                orderReportFactory = new OrderReportsFactory(OutputChannel.Console);
                reportOutput = new ReportOutput(new ConsoleReportParser(new ConsoleTableParser()), io);
                orderTaker = new ConsoleOrderTaker(io, orderItemsList, orderInputValidator);
            }
            return new OrderManagementSystem(orderTaker, reportOutput, orderReportFactory);

        }
    }
}
