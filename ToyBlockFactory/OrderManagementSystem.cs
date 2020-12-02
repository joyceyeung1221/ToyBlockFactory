using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderManagementSystem
    {
        private IOrderHandler _orderHandler;
        private IPresenter _presenter;
        private List<OrderReport> _listOfReports;
        private int _lastOrderNumber;

        public OrderManagementSystem(IOrderHandler orderHandler, IPresenter presenter, List<OrderReport> listOfReports)
        {
            _orderHandler = orderHandler;
            _presenter = presenter;
            _listOfReports = listOfReports;
            _lastOrderNumber = 0;
        }

        public void Run()
        {
            //var order = _orderHandler.CreateOrder(_lastOrderNumber + 1);
            //foreach (var report in _listOfReports)
            //{
            //    _presenter.Print(report.GenerateString(order));
            //}
        }
    }
}
