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
            var io = new Mock<IInputOutput>();
            io.SetupSequence(x => x.Input())
                .Returns("Name")
                .Returns("Address")
                .Returns("10 Jun 2020")
                .Returns("1");

            var color = new Color("Red", (decimal)1.00);
            var block = new Block(Shape.Circle);
            var listOfOptions = new List<OrderItem>
            {
                new OrderItem(block, color)
            };

            var orderHandler = new ConsoleOrderHandler(io.Object, listOfOptions);
            var order = orderHandler.CreateOrder();
            var orderItems = order.OrderItems;

            Assert.Equal(1, orderItems.GetNumberOfItems());
            Assert.Equal(1, orderItems.GetQuantityByShape(block));
            Assert.Equal(1, orderItems.GetQuantityByColor(color));
        }

        [Theory]
        [InlineData("01/01/2020")]
        [InlineData("abc")]
        [InlineData("")]
        [InlineData("40 Jan 2020")]
        [InlineData("30 Jai 2020")]
        public void ShouldRequireUserInputOfTheDueDateUntilDateInCorrectFormatIsReceived(string userIncorrectInput)
        {
            var io = new Mock<IInputOutput>();
            io.SetupSequence(x => x.Input())
                .Returns("Name")
                .Returns("Address")
                .Returns(userIncorrectInput)
                .Returns("10 Jun 2020")
                .Returns("1");

            var color = new Color("Red", (decimal)1.00);
            var block = new Block(Shape.Circle);
            var listOfOptions = new List<OrderItem>
            {
                new OrderItem(block, color)
            };

            var orderHandler = new ConsoleOrderHandler(io.Object, listOfOptions);
            var order = orderHandler.CreateOrder();
            var expectedDate = new DateTime(2020,06,10);
            var resultDate = order.DueDate;

            io.Verify(x => x.Output("Please input Your Due Date in DD MMM YYYY format: "), Times.Exactly(2));
            Assert.True(resultDate.Equals(expectedDate));
        }

        [Theory]
        [InlineData("01/01/2020")]
        [InlineData("1")]
        [InlineData("")]
        public void ShouldRequireUserInputOfCustomerNameUntilNameInCorrectFormatIsReceived(string userIncorrectInput)
        {
            var io = new Mock<IInputOutput>();
            io.SetupSequence(x => x.Input())
                .Returns(userIncorrectInput)
                .Returns("Name")
                .Returns("Address")
                .Returns("10 Jun 2020")
                .Returns("1");

            var color = new Color("Red", (decimal)1.00);
            var block = new Block(Shape.Circle);
            var listOfOptions = new List<OrderItem>
            {
                new OrderItem(block, color)
            };

            var orderHandler = new ConsoleOrderHandler(io.Object, listOfOptions);
            var order = orderHandler.CreateOrder();

            io.Verify(x => x.Output("Please input Your Name: "), Times.Exactly(2));
        }


        [Theory]
        [InlineData("1")]
        [InlineData("a a")]
        [InlineData("")]
        public void ShouldRequireUserInputOfCustomerAddressUntilAddressInCorrectFormatIsReceived(string userIncorrectInput)
        {
            var io = new Mock<IInputOutput>();
            io.SetupSequence(x => x.Input())
                .Returns("Name")
                .Returns(userIncorrectInput)
                .Returns("1 Avenue")
                .Returns("10 Jun 2020")
                .Returns("1");

            var color = new Color("Red", (decimal)1.00);
            var block = new Block(Shape.Circle);
            var listOfOptions = new List<OrderItem>
            {
                new OrderItem(block, color)
            };

            var orderHandler = new ConsoleOrderHandler(io.Object, listOfOptions);
            var order = orderHandler.CreateOrder();

            io.Verify(x => x.Output("Please input Your Address: "), Times.Exactly(2));
        }
    }
}
