using System;
namespace ToyBlockFactory
{
    public class Customer
    {
        public string Name { get; private set; }
        public string Address { get; private set; }

        public Customer(string name, string address)
        {
            Name = name;
            Address = address;
        }
    }
}
