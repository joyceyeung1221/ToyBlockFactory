using System;
using System.Collections.Generic;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class ItemListWithPriceTest
    {
        [Fact]
        public void ShouldPrintQuantityWithUnitPriceAndTotalCost()
        {
            var billableItemList = new List<BillableItem>
            {
                new BillableItem("Circles",5,(decimal)3.00),
                new BillableItem("Squares",1,(decimal)1.00),
                new BillableItem("Triangles",1,(decimal)2.00),
                new BillableItem("Red color surcharge",2,(decimal)1.00),
            };

            var itemList = new ItemListWithPrice();

            var expected =
                "Circles,5 @ $3 ppi = $15\n" +
                "Squares,1 @ $1 ppi = $1\n" +
                "Triangles,1 @ $2 ppi = $2\n" +
                "Red color surcharge,2 @ $1 ppi = $2";

            var result = itemList.GenerateString(billableItemList);

            Assert.Equal(expected, result);
        }
    }
}
