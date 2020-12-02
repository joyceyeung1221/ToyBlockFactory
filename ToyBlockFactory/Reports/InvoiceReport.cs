using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class InvoiceReport : OrderReport
    {
        private List<InvoiceItem> _invoiceItemsList;

        public InvoiceReport(Order order) : base(order)
        {
            _title = "Invoice Report";
            _invoiceItemsList = GenerateItemList(order.OrderItems);
            _table = new OrderTableGenerator().Generate(order.OrderItems);
        }

        public List<InvoiceItem> GetItemList()
        {
            return _invoiceItemsList;
        }

        private List<InvoiceItem> GenerateItemList(OrderItemsCollection orderItems)
        {
            var itemsList = new List<InvoiceItem>();
            var blocks = orderItems.GetAllShapes();
            foreach (var block in blocks)
            {
                var name = block.Shape.ToString();
                var quantity = orderItems.GetQuantityByShape(block);
                var pricePerItem = block.Price;
                var totalCost = quantity * block.Price;
                var invoiceItem = new InvoiceItem(name,quantity,pricePerItem,totalCost);

                itemsList.Add(invoiceItem);
            }

            var colors = orderItems.GetAllColors();
            foreach (var color in colors)
            {
                if (color.Price != 0)
                {
                    var name = color.Name + " " + "color surcharge";
                    var quantity = orderItems.GetQuantityByColor(color);
                    var pricePerItem = color.Price;
                    var totalCost = quantity * color.Price;
                    var invoiceItem = new InvoiceItem(name, quantity, pricePerItem, totalCost);
                    itemsList.Add(invoiceItem);
                }
            }

            return itemsList;
        }
    }
}
