using Api.Orders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Orders.Infrastructure
{
    public sealed class OrderRepository : IOrderRepository
    {
        private readonly List<Order> _orders = new();

        public void Add(Order order)
        {
            if (_orders.Contains(order))
                throw new InvalidOperationException("Order is already stored.");

            _orders.Add(order);
        }

        public Order? GetById(Guid id)
        {
            return _orders.SingleOrDefault(order => order.Id == id);
        }
    }
}
