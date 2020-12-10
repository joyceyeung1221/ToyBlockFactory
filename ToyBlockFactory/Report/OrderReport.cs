using System;

namespace ToyBlockFactory
{
    public abstract class OrderReport
    {
        protected string _title;
        protected ReportTable _table;
        protected OrderSummary _orderSummary;

        public OrderReport(Order order)
        {
            _orderSummary = new OrderSummary(order);
        }

        public string GetTitle()
        {
            return _title;
        }

        public OrderSummary GetOrderSummary()
        {
            return _orderSummary;
        }

        public ReportTable GetTable()
        {
            return _table;
        }
    }
}
