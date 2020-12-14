using System;
using ToyBlockFactory;

namespace ToyBlockFactoryTests
{
    public class MockOrderInputValidator : IOrderInputValidator
    {
        private bool _isValidName = true;
        private bool _isValidAddress = true;
        private bool _isValidDueDate = true;
        private bool _isValidQuantity = true;

        public void SetReturnToFalse(string field)
        {
            switch (field)
            {
                case "name":
                    _isValidName = false;
                    break;
                case "address":
                    _isValidAddress = false;
                    break;
                case "dueDate":
                    _isValidDueDate = false;
                    break;
                case "quantity":
                    _isValidQuantity = false;
                    break;
                default:
                    break;
            }
        }

        public bool IsValidAddress(string input)
        {
            return _isValidAddress;
        }


        public bool IsValidName(string input)
        {
            return _isValidName;
        }

        public bool IsValidQuantity(string input)
        {
            return _isValidQuantity;
        }

        public bool IsValidDueDate(string input, string dateInputFormat)
        {
            return _isValidDueDate;
        }
    }
}
