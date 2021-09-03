using System;

namespace Api.Orders.Domain
{
    public interface IOrderRepository
    {
        public Order? GetById(Guid id);
        public void Add(Order order);
    }
}
