using System;
using System.Collections.Generic;
using System.Linq;

namespace ToyBlockFactory
{
    public class CSVOrderTaker : ICreateOrder
    {
        private List<OrderItem> _productsList;
        private IInputReader _inputReader;
        private IOrderInputValidator _orderInputValidator;
        private string _dateInputFormat = "dd-MMM-yy";
        private string[] _csvFileHeaders;

        public CSVOrderTaker(IInputReader inputReader, List<OrderItem> productsList, IOrderInputValidator orderInputValidator)
        {
            _productsList = productsList;
            _inputReader = inputReader;
            _orderInputValidator = orderInputValidator;
        }

        public Order CreateOrder()
        {
            var orderInput = _inputReader.GetInput();
            SetCSVFileHeaders(orderInput);
            var orderDetails = orderInput[1];

            var customer = GetCustomer(orderDetails);
            var dueDate = GetDueDate(orderDetails);
            var orderItems = GetOrderItems(orderDetails);

            return new Order(dueDate, customer, orderItems);

        }

        private DateTime GetDueDate(string[] orderDetails)
        {
            var dueDateIndex = Array.IndexOf(_csvFileHeaders, "due date");
            return DateTime.ParseExact(orderDetails[dueDateIndex], _dateInputFormat, null,
               System.Globalization.DateTimeStyles.AllowWhiteSpaces);
        }

        private Customer GetCustomer(string[] orderDetails)
        {
            var nameIndex = Array.IndexOf(_csvFileHeaders, "first name");
            var name = orderDetails[nameIndex];
            if (_orderInputValidator.IsValidName(name))
            {
                throw (new InvalidInputException("Date is not in correct format"));
            }
            var addressIndex = Array.IndexOf(_csvFileHeaders, "address");
            var address = orderDetails[addressIndex];

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
                    var quantity = Int32.Parse(inputForItem);
                    item.SetQuantity(quantity);
                    orderItems.Add(item);
                }
            }
            return new OrderItemsCollection(orderItems);
        }

    }
}
