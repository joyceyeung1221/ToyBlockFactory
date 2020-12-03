using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderManagementSystem
    {
        private ICreateOrder _orderTaker;
        private ReportOutput _reportOutput;
        private OrderReportFactory _reportFactory;
        private int _lastOrderNumber;

        public OrderManagementSystem(ICreateOrder orderTaker, ReportOutput reportOutput, OrderReportFactory reportFactory)
        {
            _orderTaker = orderTaker;
            _reportOutput = reportOutput;
            _reportFactory = reportFactory;
            _lastOrderNumber = 0;
        }

        public void Run()
        {
            var order = _orderTaker.CreateOrder();
            AssignOrderNumber(order);
            var reports = _reportFactory.CreateReports(order);
            PrintReports(reports);
        }

        private void PrintReports(List<OrderReport> reports)
        {
            foreach (var report in reports)
            {
                _reportOutput.Print(report);
            }
        }

        private void AssignOrderNumber(Order order)
        {
            order.SetOrderNumber(_lastOrderNumber + 1);
            UpdateLastOrderNumber();
        }

        private void UpdateLastOrderNumber()
        {
            _lastOrderNumber += 1;
        }
    }
}
