using System;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class OrderItemFactoryTest
    {
        [Fact]
        public void ShouldReturnAListConsistsNineProductItems()
        {
            var factory = new OrderItemsFactory();
            var result = factory.Create();

            Assert.Equal(9, result.Count);

        }
    }
}
