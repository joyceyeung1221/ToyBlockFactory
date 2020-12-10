using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class CSVOrderTaker : ICreateOrder
    {
        private List<OrderItem> _productsList;
        private IInputReader _inputReader;
        private IOrderInputValidator _orderInputValidator;
        private const string DateInputFormat = "dd-MMM-yy";
        private string[] _csvFileHeaders;

        public CSVOrderTaker(IInputReader inputReader, List<OrderItem> productsList, IOrderInputValidator orderInputValidator)
        {
            _productsList = productsList;
            _inputReader = inputReader;
            _orderInputValidator = orderInputValidator;
        }

        public List<Order> CreateOrder()
        {
            var orders = new List<Order>();

            var orderInput = _inputReader.GetInput();
            SetCSVFileHeaders(orderInput);

            for(var i = 1; i < orderInput.Count; i++)
            {
                var order = ConvertRowDataToOrder(orderInput, i);
                orders.Add(order);
            }
            return orders;
        }

        private Order ConvertRowDataToOrder(List<string[]> orderInput, int i)
        {
            var orderDetails = orderInput[i];

            var customer = GetCustomer(orderDetails);
            var dueDate = GetDueDate(orderDetails);
            var orderItems = GetOrderItems(orderDetails);

            var order = new Order(dueDate, customer, orderItems);
            return order;
        }

        private DateTime GetDueDate(string[] orderDetails)
        {
            var dueDateIndex = Array.IndexOf(_csvFileHeaders, "due date");
            var dueDate = orderDetails[dueDateIndex];
            if (!_orderInputValidator.IsValidDueDate(dueDate, DateInputFormat))
            {
                throw (new InvalidInputException($"{dueDate} is an invalid input - Date could not be in the past and should be in DD-MMM-YY format."));
            }
            return DateTime.ParseExact(orderDetails[dueDateIndex], DateInputFormat, null,
               System.Globalization.DateTimeStyles.AllowWhiteSpaces);
        }

        private Customer GetCustomer(string[] orderDetails)
        {
            var nameIndex = Array.IndexOf(_csvFileHeaders, "first name");
            var name = orderDetails[nameIndex];
            if (!_orderInputValidator.IsValidName(name))
            {
                throw (new InvalidInputException($"{name} is an invalid input - Name should start with alphabet letter and with the minimal length of 3 characters."));
            }
            var addressIndex = Array.IndexOf(_csvFileHeaders, "address");
            var address = orderDetails[addressIndex];
            if (!_orderInputValidator.IsValidAddress(address))
            {
                throw (new InvalidInputException($"{address} is an invalid input - Address should have the minimal length of 10 characters."));
            }
            return new Customer(name, address);
        }

        private void SetCSVFileHeaders(List<string[]> orderInput)
        {
            _csvFileHeaders = orderInput[0];
        }

        private OrderItemsCollection GetOrderItems(string[] orderDetails)
        {
            var orderItems = new List<OrderItem>();
            foreach(var item in _productsList)
            {
                string optionInDisplayName = $"{item.GetDisplayName().ToLower()}s";
                var itemIndex = Array.FindIndex(_csvFileHeaders, x => x.ToLower() == optionInDisplayName);
                var inputForItem = orderDetails[itemIndex];
                if (inputForItem != "")
                {
                    if (!_orderInputValidator.IsValidQuantity(inputForItem))
                    {
                        throw (new InvalidInputException($"{inputForItem} is an invalid input - Quantity should be recorded in round number and within the range of 1 - 100."));

                    }
                    var quantity = Int32.Parse(inputForItem);
                    item.SetQuantity(quantity);
                    orderItems.Add(item);
                }
            }
            return new OrderItemsCollection(orderItems);
        }

    }
}
