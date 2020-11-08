using System;
namespace ToyBlockFactory
{
    public abstract class Report
    {
        protected string _reportName;
        protected ITable _table;
        protected Header _header;
        protected OrderSummary _orderSummary;

        public Report()
        {
            _header = new Header();
            _orderSummary = new OrderSummary();
        }

        public abstract string GenerateString(Order order);
    }
}
