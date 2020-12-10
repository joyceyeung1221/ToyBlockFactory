using System;

namespace ToyBlockFactory
{
    public class InvoiceItem
    {
        public string Name { get; }
        public int Quantity { get; }
        public decimal PricePerItem { get; }
        public decimal TotalCost { get; }

        public InvoiceItem(string name, int quantity, decimal ppi, decimal totalCost)
        {
            Name = name;
            Quantity = quantity;
            PricePerItem = ppi;
            TotalCost = totalCost;
        }
    }
}
