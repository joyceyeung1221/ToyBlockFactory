using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class BillableItemConverter
    {
        private Dictionary<Enum, decimal> _priceList;

        public BillableItemConverter(Dictionary<Enum, decimal> priceList)
        {
            _priceList = priceList;
        }

        public List<BillableItem> GenerateBillableItems(OrderItemsCollection orderItems)
        {
            var billableItemsList = new List<BillableItem>();
            var shapesList = orderItems.GetShapes();
            var colorLists = orderItems.GetColors();
            Dictionary<Enum, int> itemList = new Dictionary<Enum, int>();
            foreach (var shape in shapesList)
            {
                var quantity = orderItems.GetQuantityByShape(shape);
                itemList.Add(shape, quantity);

            }
            foreach (var color in colorLists)
            {
                var quantity = orderItems.GetQuantityByColor(color);
                itemList.Add(color, quantity);

            }
            foreach (var chargableItem in _priceList)
            {
                var type = chargableItem.Key;
                if (itemList.ContainsKey(type))
                {
                    var name = ConvertToName(type);
                    var quantity = itemList[type];
                    var individualCost = chargableItem.Value;
                    var billableItem = new BillableItem(name, quantity, individualCost);
                    billableItemsList.Add(billableItem);
                }
            }
            return billableItemsList;
        }

        private string ConvertToName(Enum type)
        {
            if(type.ToString() == Color.Red.ToString())
            {
                return "Red color surcharge";
            }
            return type.ToString()+"s";
        }
    }
}
