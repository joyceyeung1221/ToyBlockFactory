using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public class ConsoleOrderHandler
    {
        private IIO _io;
        private List<OrderItem> _listOfOptions;

        public ConsoleOrderHandler(IIO io, List<OrderItem> listOfOptions)
        {
            _io = io;
            _listOfOptions = listOfOptions;
        }

        //public Order CreateOrder()
        //{
        //}
    }
}
