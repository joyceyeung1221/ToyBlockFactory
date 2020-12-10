using System;
namespace ToyBlockFactory
{
    public interface IOrderInputValidator
    {
        public bool IsValidDueDate(string input, string dateInputFormat);
        bool IsValidName(string input);
        bool IsValidAddress(string input);
        bool IsValidQuantity(string input);

    }
}
