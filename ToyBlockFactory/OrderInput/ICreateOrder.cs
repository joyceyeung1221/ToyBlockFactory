using System;
using System.Collections.Generic;

namespace ToyBlockFactory
{
    public interface ICreateOrder
    {
        List<Order> CreateOrder();
    }
}
