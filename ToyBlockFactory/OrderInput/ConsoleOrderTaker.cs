using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ConsoleOrderTaker : ICreateOrder
    {
        private IInputOutput _io;
        private List<OrderItem> _productsList;
        private IOrderInputValidator _orderInputValidator;
        private const string DateInputFormat = "dd MMM yyyy";
        private const string NameRequest = "Your Name";
        private const string AddressRequest = "Your Address";
        private const string DueDateRequest = "Your Due Date in DD MMM YYYY format";

        public ConsoleOrderTaker(IInputOutput io, List<OrderItem> productsList, IOrderInputValidator orderInputValidator)
        {
            _io = io;
            _productsList = productsList;
            _orderInputValidator = orderInputValidator;
        }

        public List<Order> CreateOrder()
        {
            var orders = new List<Order>();
            var customer = GetCustomer();
            var dueDate = GetDueDate();
            var orderItems = GetOrderItems();
            var order =  new Order(dueDate, customer, orderItems);
            orders.Add(order);

            return orders;
        }

        private Customer GetCustomer()
        {
            var name = GetValidUserInput(NameRequest);
            var address = GetValidUserInput(AddressRequest);

            return new Customer(name, address);
        }

        private DateTime GetDueDate()
        {
            string input = GetValidUserInput(DueDateRequest);
            return ConvertToDate(input);
        }

        private DateTime ConvertToDate(string input)
        {
            return DateTime.ParseExact(input, DateInputFormat, null,
               System.Globalization.DateTimeStyles.AllowWhiteSpaces);
        }

        private OrderItemsCollection GetOrderItems()
        {
            var orderItems = new List<OrderItem>();
            foreach(var item in _productsList)
            {
                var input = GetValidUserInput($"the number of {item.GetDisplayName().ToLower()}s");
                var quantity = Int32.Parse(input);
                if ( quantity > 0)
                {
                    item.SetQuantity(quantity);
                    orderItems.Add(item);
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
                case NameRequest:
                    return _orderInputValidator.IsValidName(input);
                case AddressRequest:
                    return _orderInputValidator.IsValidAddress(input);
                case DueDateRequest:
                    return _orderInputValidator.IsValidDueDate(input, DateInputFormat);
                default:
                    return _orderInputValidator.IsValidQuantity(input);
            }
        }
    }
}
