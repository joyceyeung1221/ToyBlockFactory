using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ToyBlockFactory
{
    public class ConsoleOrderTaker : ICreateOrder
    {
        private IInputOutput _io;
        private List<OrderItem> _listOfOptions;
        private OrderInputValidator _orderInputValidator;
        private string _dateInputFormat = "dd MMM yyyy";
        private const string nameRequest = "Your Name";
        private const string addressRequest = "Your Address";
        private const string dueDateRequest = "Your Due Date in DD MMM YYYY format";

        public ConsoleOrderTaker(IInputOutput io, List<OrderItem> orderItemsList, OrderInputValidator orderInputValidator)
        {
            _io = io;
            _listOfOptions = orderItemsList;
            _orderInputValidator = orderInputValidator;
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
            var name = GetValidUserInput(nameRequest);
            var address = GetValidUserInput(addressRequest);

            return new Customer(name, address);
        }

        private DateTime GetDueDate()
        {
            string input = GetValidUserInput(dueDateRequest);
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
                var input = GetValidUserInput($"the number of {orderItem.ColorOption.Name} {orderItem.Block.Shape}s");
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

        private string GetValidUserInput(string request)
        {
            string input;
            do
            {
                _io.Print($"Please input {request}: ");
                input  = _io.Input();
            } while (!IsValidOrderInput(input, request));

            return input;
        }

        private bool IsValidOrderInput(string input, string request)
        {
            switch (request)
            {
                case nameRequest:
                    return _orderInputValidator.IsValidName(input);
                case addressRequest:
                    return _orderInputValidator.IsValidAddress(input);
                case dueDateRequest:
                    return _orderInputValidator.IsValidDate(input);
                default:
                    return _orderInputValidator.IsValidQuantity(input);
            }
        }
    }
}
