using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Catalog.Repository;
using Catalog.Entities;
using System;
using System.Linq;
using Catalog.Repositories;
using Catalog.Dtos;
using Catalog;
namespace Catalog.Controllers
{

    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRePository orderRePository;

        public OrderController(IOrderRePository _orderRepository)
        {
            this.orderRePository = _orderRepository;
        }

        [HttpGet]
        public IEnumerable<OrderDto> GetOrders()
        {
            var orders = orderRePository.GetOrders().Select(item => item.OsDto());
            return orders;
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetOrder(int id)
        {
            var order = orderRePository.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }
            return order.OsDto();
        }

        [HttpPost]
        public ActionResult<OrderDto> CreateOrder(CreateOrderDto orderDto)
        {
            Order order = new()
            {
                Id = new Random().Next(),
                OrderName = orderDto.OrderName,
                OrdePrice = orderDto.OrdePrice,
                CreatedDate = DateTimeOffset.UtcNow
            };
            orderRePository.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, order.OsDto());
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrder(int id, UpdateOrderDto orderDto)
        {
            var existingItem = orderRePository.GetOrder(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Order updateOrder = existingItem with
            { // with expression
                OrderName = orderDto.OrderName,
                OrdePrice = orderDto.OrdePrice
            };
            orderRePository.UpdateOrder(updateOrder);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            var existingItem = orderRePository.GetOrder(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            orderRePository.DeleteOrder(id);
            return NoContent();
        }
    }
}