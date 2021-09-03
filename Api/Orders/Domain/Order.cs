using Api.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using static Api.Orders.Domain.OrderStatus;

namespace Api.Orders.Domain
{
    public sealed class Order : AggregateRoot<Guid>
    {
        public OrderStatus Status { get; }
        public DeliveryDetails DeliveryDetails { get; }

        private readonly List<OrderItem> _items;
        public IReadOnlyList<OrderItem> Items => _items;

        internal Order(
            Guid id, OrderStatus status, DeliveryDetails deliveryDetails, List<OrderItem> orderItems)
        {
            Id = id;
            Status = status;
            DeliveryDetails = deliveryDetails;
            _items = orderItems;
        }

        public static Order Create(Guid id, DeliveryDetails deliveryDetails)
        {
            return new Order(id, New, deliveryDetails, new List<OrderItem>());
        }

        // TODO: what if the product doesn't exist?
        public void AddProduct(Guid productId, int numberOrdered)
        {
            if (Status == Accepted)
                throw new InvalidOperationException("Can't add products to an accepted order.");

            if (Status == Rejected)
                throw new InvalidOperationException("Can't add products to a rejected order");

            var item = _items.SingleOrDefault(item => item.ProductId == productId);

            if (item == null)
            {
                item = new OrderItem(Guid.NewGuid(), Id, productId, numberOrdered);
                _items.Add(item);
            }
            else
            {
                item.AddProduct(numberOrdered);
            }
        }
    }
}
