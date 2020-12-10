using System;

namespace ToyBlockFactory
{
    public class OrderItem
    {
        public Block Block { get; private set; }
        public Color ColorOption { get; private set; }
        public int Quantity { get; private set; }

        public OrderItem(Block block, Color color)
        {
            Block = block;
            ColorOption = color;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

        public string GetDisplayName()
        {
            return $"{ColorOption.Name} {Block.Shape}";
        }
    }
}
