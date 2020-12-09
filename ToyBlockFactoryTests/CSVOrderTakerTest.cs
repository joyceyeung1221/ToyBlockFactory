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
        private IOrderInputValidator orderInputValidator = new OrderInputValidator();

        [Fact]
        public void ShouldCreateAnOrderWithCorrectCustomerDetails_WhenValidInputReceived()
        {
            var productsList = new List<OrderItem>();
            var inputReader = new MockInputReader(standardCSVHeaders);
            var orderTaker = new CSVOrderTaker(inputReader, productsList, orderInputValidator);

            var result = orderTaker.CreateOrder();
            var resultorderItems = result.OrderItems;

            Assert.IsType<Order>(result);
            Assert.Equal("Test Name", result.Customer.Name);
            Assert.Equal("1 May Street", result.Customer.Address);
        }

        [Fact]
        public void ShouldCreateAnOrderWithCorrectDueDate_WhenValidInputReceived()
        {
            var productsList = new List<OrderItem>();
            var csvBody = new List<string[]>();
            var inputReader = new MockInputReader(standardCSVHeaders);
            var orderTaker = new CSVOrderTaker(inputReader, productsList, orderInputValidator);

            var result = orderTaker.CreateOrder();
            var expectedDueDate = new DateTime(2021, 01, 19);


            Assert.True(result.DueDate.Equals(expectedDueDate));
        }

        [Fact]
        public void ShouldCreateAnOrderWithCorrectNumberAndQuantityOfOrderItems_WhenValidInputReceived()
        {
            var csvBody = new List<string[]>
            {
                new string[]
                {
                    "Test Name","1 May Street","19-Jan-21","1","2","3","4","5","6","7","8","9"
                }

            };

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

            var inputReader = new MockInputReader(standardCSVHeaders);
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
            var inputReader = new MockInputReader(standardCSVHeaders);
            var orderInputValidator = new MockOrderInputValidator();
            orderInputValidator.SetReturnToFalse("name");
            var orderTaker = new CSVOrderTaker(inputReader, productsList, orderInputValidator);
            Action act = () => orderTaker.CreateOrder();

            var exception = Assert.Throws<InvalidInputException>(act);
            Assert.Equal("Invalid first name - Name should start with alphabet letter and with the minimal length of 3.", exception.Message);

        }

        //[Fact]
        //public void ShouldThrowInvalidInputException_WhenInvalidCSVHeadersIsReceived()
        //{

        //}

        //[Fact]
        //public void ShouldThrowInvalidDueDateException_WhenInvalidCustomerDetailsInputReceived()
        //{

        //}

        //[Fact]
        //public void ShouldThrowIncorrectOrderItemException_WhenInvalidCustomerDetailsInputReceived()
        //{

        //}

        //[Fact]
        //public void ShouldCreateMultipleOrders_WhenMultipleOrderDetailsRowsAreReceived()
        //{

        //}

    }

    public class MockOrderInputValidator : IOrderInputValidator
    {
        private bool _isValidName = true;
        private bool _isValidAddress = true;
        private bool _isValidDueDate = true;
        private bool _isValidQuantity = true;

        public void SetReturnToFalse(string field)
        {
            switch (field)
            {
                case "name":
                    _isValidName = false;
                    break;
                case "address":
                    _isValidAddress = false;
                    break;
                case "date":
                    _isValidDueDate = false;
                    break;
                case "quantity":
                    _isValidQuantity = false;
                    break;
                default:
                    break;
            }
        }

        public bool IsValidAddress(string input)
        {
            return _isValidAddress;
        }

        public bool IsValidDate(string input)
        {
            return _isValidDueDate;
        }

        public bool IsValidName(string input)
        {
            return _isValidName;
        }

        public bool IsValidQuantity(string input)
        {
            return _isValidQuantity;
        }
    }

    public class MockInputReader : IInputReader
    {
        private string[] _header;
        private List<string[]> _csvBody = new List<string[]>
        {
            new string[]
            {
                "Test Name","1 May Street","19-Jan-21","1","2","3","4","5","6","7","8","9"
            }

        };

        public MockInputReader(string[] header)
        {
            _header = header;
        }

        public List<string[]> GetInput()
        {
            var input = new List<string[]>
            {
                _header

            };
            input.AddRange(_csvBody);
            return input;
        }
    }
}
