using System;
using System.Collections.Generic;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class CSVOrderTakerTest
    {
        public CSVOrderTakerTest()
        {
        }

        [Fact]
        public void ShouldCreateAnOrderWithCorrectCustomerDetails_WhenValidInputReceived()
        {
            //var square = new Block("Square", (decimal)1.00);
            //var red = new Color("Red", (decimal)3.00);
            var orderItemsList = new List<OrderItem>();

            var inputReader = new StubInputReader();
            var orderTaker = new CSVOrderTaker(inputReader, orderItemsList);

            var result = orderTaker.CreateOrder();
            var resultorderItems = result.OrderItems;

            Assert.IsType<Order>(result);
            Assert.Equal("Test Name", result.Customer.Name);
            Assert.Equal("1 May Street", result.Customer.Address);
            //Assert.Equal(1, result.OrderItems.GetQuantityByShape(square));
            //Assert.Equal(1, result.OrderItems.GetQuantityByColor(red));
        }
    }

    public class StubInputReader : IInputReader
    {
        private string[] standardHeaders = new string[]
        {
            "first name","address","due date","red squares","blue Squares","yellow squares","red triangles","blue triangles","yellow triangles","red circles","blue circles","yellow circles"
        };

        public List<string[]> GetInput()
        {
            return new List<string[]>
            {
                standardHeaders,
                new string[]
                {
                    "Test Name","1 May Street","19-Jan-19","1","","","","","","","",""
                }
            };
        }
    }
}
