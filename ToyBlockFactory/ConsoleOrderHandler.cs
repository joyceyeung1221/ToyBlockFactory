using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ConsoleOrderHandler : IOrderHandler
    {
        private IInputOutput _io;
        private List<OrderItem> _listOfOptions;
        private string _dateInputFormat = "dd MMM yyyy";
        private int _minOrderInput = 0;
        private int _maxOrderInput = 100;
        private int _minCharForName = 3;
        private int _minCharForAddress = 10;

        public ConsoleOrderHandler(IInputOutput io, List<OrderItem> orderItemsList)
        {
            _io = io;
            _listOfOptions = orderItemsList;
        }

        public Order CreateOrder()
        {
            var customer = GetCustomer();
            var dueDate = GetDueDate();
            var orderItems = GetOrderItems();

            return new Order(dueDate, customer, orderItems);
        }

        private Customer GetCustomer()
        {
            var name = GetValidUserInput("Your Name", IsValidName);
            var address = GetValidUserInput("Your Address", IsValidAddress);

            return new Customer(name, address);
        }

        private DateTime GetDueDate()
        {
            string input = GetValidUserInput("Your Due Date in DD MMM YYYY format", IsValidDate);
            return ConvertToDate(input);
        }

        private DateTime ConvertToDate(string input)
        {
            return DateTime.ParseExact(input, _dateInputFormat, null,
               System.Globalization.DateTimeStyles.AllowWhiteSpaces);
        }

        private OrderItemsCollection GetOrderItems()
        {
            var orderItems = new List<OrderItem>();
            foreach(var orderItem in _listOfOptions)
            {
                var input = GetValidUserInput($"the number of {orderItem.ColorOption.Name} {orderItem.Block.Shape}s", IsValidQuantity);
                var quantity = Int32.Parse(input);
                if ( quantity > 0)
                {
                    orderItem.SetQuantity(quantity);
                    orderItems.Add(orderItem);
                }
            }
            var orderItemsCollection = new OrderItemsCollection(orderItems);
            return orderItemsCollection;
        }

        private string GetValidUserInput(string request, Func<string, bool> IsValidInput)
        {
            string input;
            do
            {
                _io.Output($"Please input {request}: ");
                input  = _io.Input();
            } while (!IsValidInput(input));
            return input;
        }

        private bool IsValidDate(string input)
        {
            DateTime date;
            var IsInDateFormat = DateTime.TryParseExact(input, _dateInputFormat, null,
               System.Globalization.DateTimeStyles.AllowWhiteSpaces,
               out date);
            if (IsInDateFormat)
            {
                return date > DateTime.Today;
            }
            return false;
        }

        private bool IsValidName(string input)
        {

            Regex pattern = new Regex(@"[a-zA-Z]+?");
            Match match = pattern.Match(input);
            return match.Success && input.Length >= _minCharForName;
        }

        private bool IsValidAddress(string input)
        {

            Regex pattern = new Regex(@"[a-zA-Z0-9_][a-zA-Z0-9_ ,.]+?");
            Match match = pattern.Match(input);

            return match.Success && input.Length >= _minCharForAddress;
        }

        private bool IsValidQuantity(string input)
        {
            int quantity;
            var IsInNumberFormat = Int32.TryParse(input, out quantity);
            if (IsInNumberFormat)
            {
                return (quantity >= _minOrderInput && quantity < _maxOrderInput);
            }
            return false;
        }
    }
}
