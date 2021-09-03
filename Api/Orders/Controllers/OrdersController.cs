using Api.Orders.Domain;
using Api.Orders.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Orders.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public sealed class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrdersController(IOrderRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var order = _repository.GetById(id);
            if (order == null)
                return NotFound();

            var orderDto = _mapper.Map<OrderDto>(order);
            return Ok(orderDto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        public IActionResult Create(CreateOrderDto requestDto)
        {
            var deliveryDetails = _mapper.Map<DeliveryDetails>(requestDto.DeliveryDetails);
            var order = Order.Create(Guid.NewGuid(), deliveryDetails);

            foreach (var (productId, numberOdered) in requestDto.Items)
                order.AddProduct(productId, numberOdered);

            _repository.Add(order);

            return CreatedAtRoute("GetById", new { order.Id }, order.Id);
        }
    }
}
