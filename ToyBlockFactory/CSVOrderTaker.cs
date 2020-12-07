using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class CSVOrderTaker : ICreateOrder
    {
        private List<OrderItem> _listOfOptions;
        private IInputReader _inputReader;
        private string _dateInputFormat = "dd-MMM-yy";

        public CSVOrderTaker(IInputReader inputReader, List<OrderItem> orderItemsList)
        {
            _listOfOptions = orderItemsList;
            _inputReader = inputReader;
        }

        public Order CreateOrder()
        {
            var orderInput = _inputReader.GetInput();
            string[] headers = orderInput[0];
            var orderDetails = orderInput[1];

            var nameIndex = Array.IndexOf(headers, "first name");
            var name = orderDetails[nameIndex];
            var addressIndex = Array.IndexOf(headers, "address");
            var address = orderDetails[addressIndex];
            var customer = new Customer(name, address);
            var dueDateIndex = Array.IndexOf(headers, "due date");
            var dueDate = DateTime.ParseExact(orderDetails[dueDateIndex], _dateInputFormat, null,
               System.Globalization.DateTimeStyles.AllowWhiteSpaces);
            var orderItems = new OrderItemsCollection(new List<OrderItem>());

            return new Order(dueDate, customer, orderItems);

        }
    }
}
