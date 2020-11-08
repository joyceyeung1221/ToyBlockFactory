using System;
namespace ToyBlockFactory
{
    public class BillableItem
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal IndividualCost { get; private set; }

        public BillableItem(string name, int quantity, decimal individualCost)
        {
            Name = name;
            Quantity = quantity;
            IndividualCost = individualCost;
        }
    }
}
