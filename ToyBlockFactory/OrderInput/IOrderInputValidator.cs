using System;
namespace ToyBlockFactory
{
    public interface IInputValidator
    {
        public bool IsValidDate(string input);
        bool IsValidName(string input);
        bool IsValidAddress(string input);
        bool IsValidQuantity(string input);

    }
}
