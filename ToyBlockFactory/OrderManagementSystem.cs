using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderManagementSystem
    {
        private IOrderHandler _orderHandler;
        private ReportOutput _reportOutput;
        private OrderReportFactory _reportFactory;
        private int _lastOrderNumber;

        public OrderManagementSystem(IOrderHandler orderHandler, ReportOutput reportOutput, OrderReportFactory reportFactory)
        {
            _orderHandler = orderHandler;
            _reportOutput = reportOutput;
            _reportFactory = reportFactory;
            _lastOrderNumber = 0;
        }

        public void Run()
        {
            var order = _orderHandler.CreateOrder();
            order.AssignOrderNumber(_lastOrderNumber + 1);
            UpdateLastOrderNumber();
            var reports = _reportFactory.CreateReports(order);
            foreach (var report in reports)
            {
                _reportOutput.Print(report);
            }
        }

        private void UpdateLastOrderNumber()
        {
            _lastOrderNumber += 1;
        }
    }
}
