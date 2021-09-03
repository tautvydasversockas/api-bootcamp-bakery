using System;
using System.Collections.Generic;

namespace Api.Orders.Dto
{
    public sealed record CreateOrderDto(
        DeliveryDetailsDto DeliveryDetails,
        IReadOnlyCollection<CreateOrderItemDto> Items);

    public sealed record CreateOrderItemDto(
        Guid ProductId,
        int NumberOrdered);

    public sealed record OrderDto(
        Guid Id, 
        OrderStatusDto Status, 
        DeliveryDetailsDto DeliveryDetails,
        IReadOnlyCollection<OrderItemDto> Items);

    public sealed record OrderItemDto(
        Guid Id, 
        Guid ProductId, 
        int NumberOrdered);

    public sealed record DeliveryDetailsDto(
        string Name, 
        string Address, 
        DateTime DeliveryTime);

    public enum OrderStatusDto
    {
        New,
        Accepted,
        Rejected
    }
}
