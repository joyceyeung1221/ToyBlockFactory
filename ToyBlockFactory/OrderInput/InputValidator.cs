using System;
using System.Text.RegularExpressions;

namespace ToyBlockFactory
{
    public class OrderInputValidator : IOrderInputValidator
    {
        private const int MinOrderInput = 0;
        private const int MaxOrderInput = 100;
        private const int MinCharForName = 3;
        private const int MinCharForAddress = 10;

        public bool IsValidDueDate(string input, string dateInputFormat)
        {
            DateTime date;
            var IsInDateFormat = DateTime.TryParseExact(input, dateInputFormat, null,
               System.Globalization.DateTimeStyles.AllowWhiteSpaces,
               out date);
            if (IsInDateFormat)
            {
                return date > DateTime.Today;
            }
            return false;
        }

        public bool IsValidName(string input)
        {

            Regex pattern = new Regex(@"[a-zA-Z]+?");
            Match match = pattern.Match(input);
            return match.Success && input.Length >= MinCharForName;
        }

        public bool IsValidAddress(string input)
        {

            Regex pattern = new Regex(@"[a-zA-Z0-9_][a-zA-Z0-9_ ,.]+?");
            Match match = pattern.Match(input);

            return match.Success && input.Length >= MinCharForAddress;
        }

        public bool IsValidQuantity(string input)
        {
            int quantity;
            var IsInNumberFormat = Int32.TryParse(input, out quantity);
            if (IsInNumberFormat)
            {
                return (quantity >= MinOrderInput && quantity < MaxOrderInput);
            }
            return false;
        }
    }
}
