using System;
using ToyBlockFactory;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace ToyBlockFactoryTests
{
    public class ConsoleOrderHandlerTest
    {
        [Fact]
        public void ShouldOrderContainCorrectOrderItems()
        {
            var io = new Mock<IIO>();
            io.SetupSequence(x => x.Input())
                .Returns("Name")
                .Returns("Address")
                .Returns("1");

            var listOfOptions = new List<Block>
            {
                new Block(Shape.Circle,Color.Red)
            };

            var orderHandler = new ConsoleOrderHandler(io.Object, listOfOptions);
            Order order = orderHandler.CreateOrder();
            var orderItems = order.OrderItems;
     
            Assert.Equal(1, orderItems.NumberOfItems());
            Assert.Equal(1, orderItems.GetQuantityByShape(Shape.Circle));
            Assert.Equal(1, orderItems.GetQuantityByColor(Color.Red));


        }
    }
}
