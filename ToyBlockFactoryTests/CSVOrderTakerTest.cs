using System;
using System.Collections.Generic;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class CSVOrderTakerTest
    {
        private string[] standardCSVHeaders = new string[]
        {
            "first name","address","due date","red squares","blue Squares","yellow squares","red triangles","blue triangles","yellow triangles","red circles","blue circles","yellow circles"
        };

        private List<string[]> csvBodyWithOneOrder = new List<string[]>
        {
            new string[]
            {
                "Test Name","Test Address","19-Jan-21","1","2","3","4","5","6","7","8","9"
            }

        };

        [Fact]
        public void ShouldCreateAnOrderWithCorrectCustomerDetails_WhenValidInputReceived()
        {
            var productsList = new List<OrderItem>();
            var inputReader = new MockInputReader(standardCSVHeaders, csvBodyWithOneOrder);
            var orderInputValidator = new MockOrderInputValidator();
            var orderTaker = new CSVOrderTaker(inputReader, productsList, orderInputValidator);

            var orders = orderTaker.CreateOrder();
            var result = orders[0];
            var resultorderItems = result.OrderItems;

            Assert.IsType<Order>(result);
            Assert.Equal("Test Name", result.Customer.Name);
            Assert.Equal("Test Address", result.Customer.Address);
        }

        [Fact]
        public void ShouldCreateAnOrderWithCorrectDueDate_WhenValidInputReceived()
        {
            var productsList = new List<OrderItem>();
            var csvBody = new List<string[]>();
            var inputReader = new MockInputReader(standardCSVHeaders,csvBody);
            var orderInputValidator = new MockOrderInputValidator();
            var orderTaker = new CSVOrderTaker(inputReader, productsList, orderInputValidator);

            var orders = orderTaker.CreateOrder();
            var result = orders[0];
            var expectedDueDate = new DateTime(2021, 01, 19);


            Assert.True(result.DueDate.Equals(expectedDueDate));
        }

        [Fact]
        public void ShouldCreateAnOrderWithCorrectNumberAndQuantityOfOrderItems_WhenValidInputReceived()
        {
            var red = new Color("Red", (decimal)1.00);
            var yellow = new Color("Yellow", (decimal)0.00);
            var blue = new Color("Blue", (decimal)0.00);


            var circle = new Block("Circle", (decimal)3.00);
            var square = new Block("Square", (decimal)1.00);
            var triangle = new Block("Triangle", (decimal)2.00);

            var productsList = new List<OrderItem>
            {
                new OrderItem(circle,red),
                new OrderItem(circle,yellow),
                new OrderItem(circle,blue),
                new OrderItem(square,red),
                new OrderItem(square,yellow),
                new OrderItem(square,blue),
                new OrderItem(triangle,red),
                new OrderItem(triangle,yellow),
                new OrderItem(triangle,blue)
            };

            var inputReader = new MockInputReader(standardCSVHeaders,csvBodyWithOneOrder);
            var orderInputValidator = new MockOrderInputValidator();
            var orderTaker = new CSVOrderTaker(inputReader, productsList, orderInputValidator);

            Order result = orderTaker.CreateOrder();

            Assert.Equal(9, result.OrderItems.GetNumberOfItems());
            Assert.Equal(1, result.OrderItems.GetQuantityByShapeAndColor(square,red));
            Assert.Equal(2, result.OrderItems.GetQuantityByShapeAndColor(square,blue));
            Assert.Equal(3, result.OrderItems.GetQuantityByShapeAndColor(square,yellow));
            Assert.Equal(4, result.OrderItems.GetQuantityByShapeAndColor(triangle,red));
            Assert.Equal(5, result.OrderItems.GetQuantityByShapeAndColor(triangle,blue));
            Assert.Equal(6, result.OrderItems.GetQuantityByShapeAndColor(triangle,yellow));
            Assert.Equal(7, result.OrderItems.GetQuantityByShapeAndColor(circle,red));
            Assert.Equal(8, result.OrderItems.GetQuantityByShapeAndColor(circle,blue));
            Assert.Equal(9, result.OrderItems.GetQuantityByShapeAndColor(circle,yellow));
        }


        [Fact]
        public void ShouldThrowInvalidInputExceptionWithCorrectMessage_WhenInvalidCustomerNameReceived()
        {
            var productsList = new List<OrderItem>();
            var inputReader = new MockInputReader(standardCSVHeaders,csvBodyWithOneOrder);
            var orderInputValidator = new MockOrderInputValidator();
            orderInputValidator.SetReturnToFalse("name");
            var orderTaker = new CSVOrderTaker(inputReader, productsList, orderInputValidator);
            Action act = () => orderTaker.CreateOrder();

            var exception = Assert.Throws<InvalidInputException>(act);
            Assert.Equal("Test Name is an invalid input - Name should start with alphabet letter and with the minimal length of 3 characters.", exception.Message);

        }

        [Fact]
        public void ShouldThrowInvalidInputExceptionWithCorrectMessage_WhenInvalidCustomerAddressReceived()
        {
            var productsList = new List<OrderItem>();
            var inputReader = new MockInputReader(standardCSVHeaders,csvBodyWithOneOrder);
            var orderInputValidator = new MockOrderInputValidator();
            orderInputValidator.SetReturnToFalse("address");
            var orderTaker = new CSVOrderTaker(inputReader, productsList, orderInputValidator);
            Action act = () => orderTaker.CreateOrder();

            var exception = Assert.Throws<InvalidInputException>(act);
            Assert.Equal("Test Address is an invalid input - Address should have the minimal length of 10 characters.", exception.Message);

        }

        [Fact]
        public void ShouldThrowInvalidInputException_WhenInvalidDueDateInputReceived()
        {
            var productsList = new List<OrderItem>();
            var inputReader = new MockInputReader(standardCSVHeaders,csvBodyWithOneOrder);
            var orderInputValidator = new MockOrderInputValidator();
            orderInputValidator.SetReturnToFalse("dueDate");
            var orderTaker = new CSVOrderTaker(inputReader, productsList, orderInputValidator);
            Action act = () => orderTaker.CreateOrder();

            var exception = Assert.Throws<InvalidInputException>(act);
            Assert.Equal("19-Jan-21 is an invalid input - Date could not be in the past and should be in DD-MMM-YY format.", exception.Message);

        }

        [Fact]
        public void ShouldThrowInvalidInputException_WhenInvalidQuantityInputReceived()
        {
            var productsList = new OrderItemFactory().CreateOrderItems();
            var inputReader = new MockInputReader(standardCSVHeaders,csvBodyWithOneOrder);
            var orderInputValidator = new MockOrderInputValidator();
            orderInputValidator.SetReturnToFalse("quantity");
            var orderTaker = new CSVOrderTaker(inputReader, productsList, orderInputValidator);
            Action act = () => orderTaker.CreateOrder();

            var exception = Assert.Throws<InvalidInputException>(act);
            Assert.Equal("8 is an invalid input - Quantity should be recorded in round number and within the range of 1 - 100.", exception.Message);

        }

        [Fact]
        public void ShouldCreateMultipleOrders_WhenMultipleOrderDetailsRowsAreReceived()
        {
            var csvBodyWithTwoOrders = new List<string[]>
            {
                new string[]
                {
                    "Test Name","Test Address","19-Jan-21","1","2","3","4","5","6","7","8","9"
                },
                new string[]
                {
                    "Test Name","Test Address","19-Jan-21","1","2","3","4","5","6","7","8","9"
                },
            };
            var productsList = new OrderItemFactory().CreateOrderItems();
            var orderInputValidator = new MockOrderInputValidator();
            var inputReader = new MockInputReader(standardCSVHeaders, csvBodyWithTwoOrders);
            var orderTaker = new CSVOrderTaker(inputReader, productsList, orderInputValidator);
            var result =  orderTaker.CreateOrder();

            Assert.Equal(2, result.Count);
        }
    }
}
