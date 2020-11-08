using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ItemListWithPrice
    {
        public ItemListWithPrice()
        {
        }

        public string GenerateString(List<BillableItem> billableItems)
        {
            var stringToPrint = "";
            foreach(var billableItem in billableItems)
            {
                stringToPrint += $"{billableItem.Name},{billableItem.Quantity} @ ${billableItem.IndividualCost} ppi = ${billableItem.Quantity * billableItem.IndividualCost}";
                if (billableItem != billableItems[^1])
                {
                    stringToPrint += "\n";
                }
            }
            return stringToPrint;
        }
    }
}
