using System;
namespace ToyBlockFactory
{
    public interface IOrderHandler
    {
        Order CreateOrder(int orderNumber);
    }
}
