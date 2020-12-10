using System;

namespace ToyBlockFactory
{
    class Program
    {
        static void Main(string[] args)
        {

            var orderItemFactory = new OrderItemsFactory();
            var orderManagementSystem = OrderManagementSystemFactory.Create(orderItemFactory, args);
            Run(orderManagementSystem);
        }

        private static void Run(OrderManagementSystem orderManagementSystem)
        {
            try
            {
                orderManagementSystem.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");

                Environment.Exit(0);
            }
        }
    }
}
