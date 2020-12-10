using System;
using ToyBlockFactory;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace ToyBlockFactoryTests
{
    public class ConsoleOrderTakerTest
    {
        private DateTime _testDueDate = DateTime.Today.AddDays(1);
        private string _testName = "David";
        private string _testAddress = "1 May Avenue";

        [Fact]
        public void ShouldCreateOrderContainsCorrectCustomerDueDateAndNumberOfOrderItemsWithQuantity_WhenValidInputReceived()
        {
            var io = new Mock<IInputOutput>();
            io.SetupSequence(x => x.Input())
                .Returns(_testName)
                .Returns(_testAddress)
                .Returns(_testDueDate.ToString("dd MMM yyyy"))
                .Returns("1")
                .Returns("3")
                .Returns("0");

            var color = TestData.Colors[0];
            var block = TestData.Blocks[0];
            var color1 = TestData.Colors[1];
            var block1 = TestData.Blocks[1];
            var color2 = TestData.Colors[2];
            var block2 = TestData.Blocks[2];
            var listOfOptions = new List<OrderItem>
            {
                new OrderItem(block, color),
                new OrderItem(block1, color1),
                new OrderItem(block2, color2),
            };

            var orderHandler = new ConsoleOrderTaker(io.Object, listOfOptions, new OrderInputValidator());
            var orders = orderHandler.CreateOrder();
            var result = orders[0];
            var orderItems = result.OrderItems;

            Assert.Equal(_testName, result.Customer.Name);
            Assert.Equal(_testAddress, result.Customer.Address);
            Assert.Equal(_testDueDate, result.DueDate);
            Assert.Equal(2, orderItems.GetNumberOfItems());
            Assert.Equal(1, orderItems.GetQuantityByShapeAndColor(TestData.Blocks[0], TestData.Colors[0]));
            Assert.Equal(3, orderItems.GetQuantityByShapeAndColor(TestData.Blocks[1], TestData.Colors[1]));
        }
    }
}
