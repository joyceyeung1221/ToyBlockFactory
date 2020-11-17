using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ToyBlockFactory
{
    public class ConsoleOrderHandler : IOrderHandler
    {
        private IInputOutput _io;
        private List<OrderItem> _listOfOptions;
        private readonly Dictionary<string, int> _monthReference = new Dictionary<string, int>
            {
                { "jan" ,1},
                { "feb" ,2},
                { "mar" ,3},
                { "apr" ,4},
                { "may" ,5},
                { "jun" ,6},
                { "jul" ,7},
                { "aug" ,8},
                { "sep" ,9},
                { "oct" ,10},
                { "nov" ,11},
                { "dec" ,12},
            };

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

        private DateTime GetDueDate()
        {
            var input = GetUserInput("Your Due Date");
            var dueDate = ConvertToDate(input);
            return dueDate;
        }

        private DateTime ConvertToDate(string input)
        {
            
            Regex pattern = new Regex(@"(?<date>\d\d?) (?<month>\w\w\w) (?<year>\d\d\d\d)");
            Match match = pattern.Match(input);
            var date = Int32.Parse(match.Groups["date"].Value);
            var month = _monthReference[match.Groups["month"].Value.ToLower()];
            var year = Int32.Parse(match.Groups["year"].Value);

            var dateTime = new DateTime(year, month, date);
            return dateTime;
        }
        
        private OrderItemsCollection GetOrderItems()
        {
            var orderItems = new List<OrderItem>();
            foreach(var orderItem in _listOfOptions)
            {
                var input = GetUserInput($"the number of {orderItem.ColorOption.Name} {orderItem.Block.Shape}s");
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

        private Customer GetCustomer()
        {
            var name = GetUserInput("Your Name");
            var address = GetUserInput("Your Address");

            return new Customer(name, address);
        }

        private string GetUserInput(string request)
        {
            _io.Output($"Please input {request}:");
            return _io.Input();
        }
    }
}
