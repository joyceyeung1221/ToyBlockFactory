using System;
using ToyBlockFactory;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace ToyBlockFactoryTests
{
    public class ConsoleOrderHandlerTest
    {
        private DateTime _testDueDate = DateTime.Today.AddDays(1);
        private string _testName = "David";
        private string _testAddress = "1 May Avenue";

        [Fact]
        public void ShouldOrderContainCorrectOrderItems()
        {
            var io = new Mock<IInputOutput>();
            io.SetupSequence(x => x.Input())
                .Returns(_testName)
                .Returns(_testAddress)
                .Returns(_testDueDate.ToString("dd MMM yyyy"))
                .Returns("1");

            var color = TestData.Colors[0];
            var block = TestData.Blocks[0];
            var listOfOptions = new List<OrderItem>
            {
                new OrderItem(block, color)
            };

            var orderHandler = new ConsoleOrderHandler(io.Object, listOfOptions);
            var order = orderHandler.CreateOrder();
            order.AssignOrderNumber(1);
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
                .Returns(_testName)
                .Returns(_testAddress)
                .Returns(userIncorrectInput)
                .Returns(_testDueDate.ToString("dd MMM yyyy"))
                .Returns("1");

            var color = TestData.Colors[0];
            var block = TestData.Blocks[0];
            var listOfOptions = new List<OrderItem>
            {
                new OrderItem(block, color)
            };

            var orderHandler = new ConsoleOrderHandler(io.Object, listOfOptions);
            var order = orderHandler.CreateOrder();
            order.AssignOrderNumber(1);
            var expectedDate = DateTime.Today.AddDays(1);
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
                .Returns(_testName)
                .Returns(_testAddress)
                .Returns(_testDueDate.ToString("dd MMM yyyy"))
                .Returns("1");

            var color = TestData.Colors[0];
            var block = TestData.Blocks[0];
            var listOfOptions = new List<OrderItem>
            {
                new OrderItem(block, color)
            };

            var orderHandler = new ConsoleOrderHandler(io.Object, listOfOptions);
            var order = orderHandler.CreateOrder();
            order.AssignOrderNumber(1);

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
                .Returns(_testName)
                .Returns(userIncorrectInput)
                .Returns(_testAddress)
                .Returns(_testDueDate.ToString("dd MMM yyyy"))
                .Returns("1");

            var color = TestData.Colors[0];
            var block = TestData.Blocks[0];
            var listOfOptions = new List<OrderItem>
            {
                new OrderItem(block, color)
            };

            var orderHandler = new ConsoleOrderHandler(io.Object, listOfOptions);
            var order = orderHandler.CreateOrder();
            order.AssignOrderNumber(1);

            io.Verify(x => x.Output("Please input Your Address: "), Times.Exactly(2));
        }
    }
}
