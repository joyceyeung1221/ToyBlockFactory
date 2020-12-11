using System;

namespace ToyBlockFactory
{
    public class Block
    {
        public string Shape { get; private set; }
        public decimal Price { get; private set; }

        public Block(string shape, decimal price)
        {
            Shape = shape;
            Price = price;

        }
    }
}
