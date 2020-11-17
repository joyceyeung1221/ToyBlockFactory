using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ItemListWithPrice
    {
        public ItemListWithPrice()
        {
        }

        public string GenerateString(OrderItemsCollection orderItems)
        {
            var stringToPrint = "";
            var shapes = orderItems.GetAllShapes();
            var shapesWithQuantityList = new List<(Block, int)>();
            foreach (var block in shapes)
            {
                var quantity = orderItems.GetQuantityByShape(block);
                shapesWithQuantityList.Add((block, quantity));
            }

            var colors = orderItems.GetAllColors();
            var colorsWithQuantitiesList = new List<(Color, int)>();
            foreach (var color in colors)
            {
                if (color.Price != 0)
                {
                    var quantity = orderItems.GetQuantityByColor(color);
                    colorsWithQuantitiesList.Add((color, quantity));
                }
            }
            foreach (var shape in shapesWithQuantityList)
            {
                var block = shape.Item1;
                var quantity = shape.Item2;
                stringToPrint += $"{block.Shape}s,{quantity} @ ${block.Price} ppi = ${quantity * block.Price}";
                if (shape != shapesWithQuantityList[^1])
                {
                    stringToPrint += "\n";
                }
            }
            if(colorsWithQuantitiesList.Count != 0)
            {
                foreach(var color in colorsWithQuantitiesList)
                {
                    var colorOption = color.Item1;
                    var quantity = color.Item2;
                    stringToPrint += $"\n{colorOption.Name} color surcharge,{quantity} @ ${colorOption.Price} ppi = ${quantity * colorOption.Price}";
                }
            }
            return stringToPrint;
        }
    }
}
