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

            table = ConstructTableBody(table, orderItems, colors, blocks);

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

        private ReportTable ConstructTableBody(ReportTable table, OrderItemsCollection orderItems, List<Color> colors, List<Block> blocks)
        {
            foreach (var block in blocks)
            {
                var quantities = GetBlockQuantityByColors(orderItems, colors, block);
                table.AddRow(block.Shape.ToString(), quantities);
            }
            return table;
        }

        private List<int> GetBlockQuantityByColors(OrderItemsCollection orderItems, List<Color> colors, Block block)
        {
            var quantities = new List<int>();
            foreach (var color in colors)
            {
                quantities.Add(orderItems.GetQuantityByShapeAndColor(block, color));
            }
            return quantities;
        }
    }
}
