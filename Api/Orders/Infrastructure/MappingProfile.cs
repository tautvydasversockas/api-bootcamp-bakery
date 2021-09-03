using Api.Orders.Domain;
using Api.Orders.Dto;
using AutoMapper;

namespace Api.Orders.Infrastructure
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderStatus, OrderStatusDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<DeliveryDetails, DeliveryDetailsDto>();
            CreateMap<DeliveryDetailsDto, DeliveryDetails>();
        }
    }
}
