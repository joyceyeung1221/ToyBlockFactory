using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ReportTable
    {
        public Dictionary<string, List<int>> Body = new Dictionary<string, List<int>>();
        public List<string> Header { get; private set; }

        public ReportTable(List<string> header)
        {
            Header = header;
        }

        public void AddRow(string header, List<int> quantities)
        {
            Body.Add( header, quantities);
        }

        public void ConstructTableBody(OrderItemsCollection orderItems, List<Block> blocks)
        {
            foreach (var block in blocks)
            {
                var quantities = new List<int> { orderItems.GetQuantityByShape(block) };
                AddRow(block.Shape.ToString(), quantities);
            }
        }

        public void ConstructTableBody(OrderItemsCollection orderItems, List<Block> blocks, List<Color> colors)
        {
            foreach (var block in blocks)
            {
                var quantities = GetBlockQuantityByColors(orderItems, colors, block);
                AddRow(block.Shape.ToString(), quantities);
            }
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
