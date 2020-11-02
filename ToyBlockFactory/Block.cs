using System;
namespace ToyBlockFactory
{
    public class Block : IInvoiceItem
    {
        public Shape Shape { get; private set; }
        public Color Color { get; private set; }

        public Block(Shape shape, Color color)
        {
            Shape = shape;
            Color = color;
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public double GetPrice()
        {
            throw new NotImplementedException();
        }
    }
}
