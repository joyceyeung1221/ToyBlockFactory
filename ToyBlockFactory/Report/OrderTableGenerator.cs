using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class OrderTableGenerator
    {
        public ReportTable Generate(OrderItemsCollection orderItems)
        {
            var colors = orderItems.GetAllColors();
            var blocks = orderItems.GetAllShapes();

            var table = new ReportTable(ConvertColorToString(colors));

            table.ConstructTableBody(orderItems, blocks, colors);

            return table;
        }

        private List<string> ConvertColorToString(List<Color> listToConvert)
        {
            var list = new List<string>();
            foreach(var element in listToConvert)
            {
                list.Add(element.Name);
            }
            return list;
        }


    }
}
