using System;
using System.Collections.Generic;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class BillableItemConverterTest
    {
        public BillableItemConverterTest()
        {
        }

        [Theory]
        [InlineData()]
        public void ShouldReturnListOfInvoiceItems_WhenInputItemMatchesWithIndividualCostListItem()
        {
            var orderItems = new Dictionary<Block, int>
            {
                {new Block(Shape.Circle, Color.Red),2 },
                {new Block(Shape.Circle, Color.Yellow),3 },
                {new Block(Shape.Square, Color.Blue),1 },
                {new Block(Shape.Triangle, Color.Yellow),2 }
            };
            var orderItemsCollection = new OrderItemsCollection(orderItems);

            var priceList = new Dictionary<Enum, decimal>
            {
                { Shape.Circle, (decimal)3.00},
                { Shape.Square, (decimal)1.00},
                { Shape.Triangle, (decimal)2.00},
                { Color.Red, (decimal)1.00}
            };

            var billableItemConverter = new BillableItemConverter(priceList);

            var result = billableItemConverter.GenerateBillableItems(orderItemsCollection);
            Assert.IsType<List<BillableItem>>(result);
            Assert.Equal(4, result.Count);
            Assert.Equal("Circles", result[0].Name);
            Assert.Equal(5, result[0].Quantity);
            Assert.Equal((decimal)3.00, result[0].IndividualCost);
            Assert.Equal("Squares", result[1].Name);
            Assert.Equal(1, result[1].Quantity);
            Assert.Equal((decimal)1.00, result[1].IndividualCost);
            Assert.Equal("Triangles", result[2].Name);
            Assert.Equal(2, result[2].Quantity);
            Assert.Equal((decimal)2.00, result[2].IndividualCost);
            Assert.Equal("Red color surcharge", result[3].Name);
            Assert.Equal(2, result[3].Quantity);
            Assert.Equal((decimal)1.00, result[3].IndividualCost);
        }
    }
}
