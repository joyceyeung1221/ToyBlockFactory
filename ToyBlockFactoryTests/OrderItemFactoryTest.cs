using System;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class OrderItemFactoryTest
    {
        public OrderItemFactoryTest()
        {
        }

        [Fact]
        public void ShouldReturnAListConsistsNineProductItems()
        {
            var factory = new OrderItemFactory();
            var result = factory.CreateOrderItems();

            Assert.Equal(9, result.Count);

        }
    }
}
