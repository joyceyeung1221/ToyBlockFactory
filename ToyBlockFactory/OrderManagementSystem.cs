using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderManagementSystem
    {
        private IOrderHandler _orderHandler;
        private IPresenter _presenter;
        private List<Report> _listOfReports;

        public OrderManagementSystem(IOrderHandler orderHandler, IPresenter presenter, List<Report> listOfReports)
        {
            _orderHandler = orderHandler;
            _presenter = presenter;
            _listOfReports = listOfReports;
        }

        public void Run()
        {
            var order = _orderHandler.CreateOrder();
            foreach(var report in _listOfReports)
            {
                _presenter.Print(report.GenerateString(order));
            }
        }
    }
}
