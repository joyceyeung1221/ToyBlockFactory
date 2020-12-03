using System;
using System.Text.RegularExpressions;

namespace ToyBlockFactory
{
    public class OrderInputValidator
    {
        private string _dateInputFormat = "dd MMM yyyy";
        private int _minOrderInput = 0;
        private int _maxOrderInput = 100;
        private int _minCharForName = 3;
        private int _minCharForAddress = 10;

        public bool IsValidDate(string input)
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

        public bool IsValidName(string input)
        {

            Regex pattern = new Regex(@"[a-zA-Z]+?");
            Match match = pattern.Match(input);
            return match.Success && input.Length >= _minCharForName;
        }

        public bool IsValidAddress(string input)
        {

            Regex pattern = new Regex(@"[a-zA-Z0-9_][a-zA-Z0-9_ ,.]+?");
            Match match = pattern.Match(input);

            return match.Success && input.Length >= _minCharForAddress;
        }

        public bool IsValidQuantity(string input)
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
