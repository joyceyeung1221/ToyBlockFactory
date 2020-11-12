using System;
namespace ToyBlockFactory
{
    public interface ITable
    {
        string GenerateString(OrderItemsCollection orderItems);
    }
}
