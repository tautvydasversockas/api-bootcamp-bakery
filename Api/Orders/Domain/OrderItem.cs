using CSharpFunctionalExtensions;
using System;

namespace Api.Orders.Domain
{
    public sealed class OrderItem : Entity<Guid>
    {
        public Guid OrderId { get; }
        public Guid ProductId { get; }
        public int NumberOrdered { get; private set; }

        internal OrderItem(Guid id, Guid orderId, Guid productId, int numberOrdered)
        {
            if (numberOrdered < 1)
                throw new ArgumentException("Number should be higher than 0.");

            Id = id;
            OrderId = orderId;
            ProductId = productId;
            NumberOrdered = numberOrdered;
        }

        public void AddProduct(int numberOrdered)
        {
            if (numberOrdered < 1)
                throw new ArgumentException("Number should be higher than 0.");

            NumberOrdered += numberOrdered;
        }
    }
}
