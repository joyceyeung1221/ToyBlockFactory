//using System;
//using ToyBlockFactory;
//using Moq;
//using Xunit;
//using System.Collections.Generic;

//namespace ToyBlockFactoryTests
//{
//    public class ConsoleOrderHandlerTest
//    {
//        [Fact]
//        public void ShouldOrderContainCorrectOrderItems()
//        {
//            var io = new Mock<IIO>();
//            io.SetupSequence(x => x.Input())
//                .Returns("Name")
//                .Returns("Address")
//                .Returns("1");

//            var color = new Color("Red",(decimal)1.00);
//            var block = new Block(Shape.Circle);
//            var listOfOptions = new List<OrderItem>
//            {
//                new OrderItem(block, color)
//            };

//            var orderHandler = new ConsoleOrderHandler(io.Object, listOfOptions);
//            var order = orderHandler.CreateOrder();
//            var orderItems = order.OrderItems;

//            Assert.Equal(1, orderItems.GetNumberOfItems());
//            Assert.Equal(1, orderItems.GetQuantityByShape(block));
//            Assert.Equal(1, orderItems.GetQuantityByColor(color));


//        }
//    }
//}
