using System;
namespace ToyBlockFactory
{
    public class Block
    {
        public Shape Shape { get; private set; }
        public Color Color { get; private set; }

        public Block(Shape shape, Color color)
        {
            Shape = shape;
            Color = color;
        }
    }
}
