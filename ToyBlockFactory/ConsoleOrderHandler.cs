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
            Match input;
            DateTime dueDate = new DateTime();
            do
            {
                input = GetUserInput("Your Due Date in DD MMM YYYY format", MatchWithDatePattern);
                dueDate = ConvertToDate(input);
                if (!dueDate.Equals(new DateTime()))
                {
                    break;
                }

            } while (true);

            return dueDate;
        }

        private DateTime ConvertToDate(Match matchResult)
        {
            var month = matchResult.Groups["month"].Value.ToLower();
            var day = matchResult.Groups["date"].Value;
            var year = matchResult.Groups["year"].Value;
            DateTime date;
            if (DateTime.TryParse($"{day} {month} {year}", out date))
            {
                return date;
            }
            return new DateTime();
        }

        private Match MatchWithDatePattern(string input)
        {
            
            Regex pattern = new Regex(@"(?<date>\d\d?) (?<month>\w\w\w) (?<year>\d\d\d\d)");
            Match match = pattern.Match(input);

            return match;
        }

        private Match MatchWithNumberPattern(string input)
        {

            Regex pattern = new Regex(@"\d+?");
            Match match = pattern.Match(input);

            return match;
        }

        private Match MatchWithCharacterPattern(string input)
        {

            Regex pattern = new Regex(@"[a-zA-Z]+?");
            Match match = pattern.Match(input);

            return match;
        }

        private Match MatchWithAddressPattern(string input)
        {

            Regex pattern = new Regex(@"[a-zA-Z0-9_][a-zA-Z0-9_ ][a-zA-Z0-9_ ][a-zA-Z0-9_ ][a-zA-Z0-9_ ]+?");
            Match match = pattern.Match(input);

            return match;
        }

        private OrderItemsCollection GetOrderItems()
        {
            var orderItems = new List<OrderItem>();
            foreach(var orderItem in _listOfOptions)
            {
                var input = GetUserInput($"the number of {orderItem.ColorOption.Name} {orderItem.Block.Shape}s",MatchWithNumberPattern);
                var quantity = Int32.Parse(input.Value);
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
            var name = GetUserInput("Your Name",MatchWithCharacterPattern);
            var address = GetUserInput("Your Address",MatchWithAddressPattern);

            return new Customer(name.Value, address.Value);
        }

        private Match GetUserInput(string request, Func<string,Match> MatchWithRegex)
        {
            Match matchResult;
            do
            {
                _io.Output($"Please input {request}: ");
                var input = _io.Input();
                matchResult = MatchWithRegex(input);
            } while (!matchResult.Success);
            return matchResult;
        }
    }
}
