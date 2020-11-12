using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class Block
    {
        public Shape Shape { get; private set; }
        public decimal Price { get; private set; }

        public Block(Shape shape)
        {
            Shape = shape;
            Price = AssignPriceByShape(shape);

        }

        private decimal AssignPriceByShape(Shape shape)
        {
            var priceList = new Dictionary<Shape, decimal>
            {
                { Shape.Circle, (decimal)3.00 },
                { Shape.Square, (decimal)1.00 },
                { Shape.Triangle, (decimal)2.00 }
            };

            return priceList[shape];
        }
    }
}
