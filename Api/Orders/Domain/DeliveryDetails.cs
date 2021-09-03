using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;

namespace Api.Orders.Domain
{
    public sealed class DeliveryDetails : ValueObject
    {
        public string Name { get; }
        public string Address { get; }
        public DateTime DeliveryTime { get; }

        public DeliveryDetails(string name, string address, DateTime deliveryTime)
        {
            name = name.Trim();
            if (name == string.Empty)
                throw new ArgumentException("Name must be present.");

            address = address.Trim();
            if (address == string.Empty)
                throw new ArgumentException("Address must be present.");

            Name = name;
            Address = address;
            DeliveryTime = deliveryTime;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name.ToLower();
            yield return Address.ToLower();
            yield return DeliveryTime;
        }
    }
}
