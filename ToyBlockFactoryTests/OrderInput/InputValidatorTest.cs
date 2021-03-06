﻿using System;
using ToyBlockFactory;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class InputValidatorTest
    {
        private OrderInputValidator _validator;
        private string _dateInputFormat = "dd MMM yyyy";

        public InputValidatorTest()
        {
            _validator = new OrderInputValidator();
        }

        [Theory]
        [InlineData("01/01/2020")]
        [InlineData("abc")]
        [InlineData("")]
        [InlineData("40 Jan 2020")]
        [InlineData("30 Jai 2020")]
        public void ShouldReturnFalse_WhenInvalidDateInputReceived(string userIncorrectInput)
        {
            var result = _validator.IsValidDueDate(userIncorrectInput, _dateInputFormat);

            Assert.False(result);
        }

        [Fact]
        public void ShouldReturnTrue_WhenInvalidDateInputReceived()
        {
            var tomorrowDate = DateTime.Today.AddDays(1).ToString("dd MMM yyyy");
            var result = _validator.IsValidDueDate(tomorrowDate, _dateInputFormat);

            Assert.True(result);
        }

        [Fact]
        public void ShouldReturnFalse_WhenPastDateReceivedAsDueDate()
        {
            var result = _validator.IsValidDueDate("1 Nov 2000", _dateInputFormat);

            Assert.False(result);
        }

        [Theory]
        [InlineData("Ab")]
        [InlineData("A")]
        [InlineData("")]
        public void ShouldReturnFalse_WhenNameIsLessThan3Characters(string userIncorrectInput)
        {
            var result = _validator.IsValidName(userIncorrectInput);

            Assert.False(result);
        }

        [Theory]
        [InlineData("01/01/2020")]
        [InlineData("111")]
        public void ShouldReturnFalse_WhenNameDoesNotContainCharacter(string userIncorrectInput)
        {
            var result = _validator.IsValidName(userIncorrectInput);

            Assert.False(result);
        }


        [Theory]
        [InlineData("1 A St")]
        [InlineData("xxxxxxxx")]
        [InlineData("")]
        public void ShouldReturnFalse_WhenAddressIsLessThan10Characters(string userIncorrectInput)
        {
            var result = _validator.IsValidAddress(userIncorrectInput);

            Assert.False(result);
        }

        [Theory]
        [InlineData("1 Garden Street")]
        [InlineData("1/5 Garden Street")]
        public void ShouldReturnTrue_WhenAddressInCorrectFormatIsReceived(string userIncorrectInput)
        {
            var result = _validator.IsValidAddress(userIncorrectInput);

            Assert.True(result);
        }
    }
}