using System;
namespace ToyBlockFactory
{
    public class Color
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }

        public Color(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

    }
}
