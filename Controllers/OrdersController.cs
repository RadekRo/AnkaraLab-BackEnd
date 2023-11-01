﻿using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AnkaraLab_BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/orders")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _ordersRepository;
        public OrdersController(IOrdersRepository ordersRepository)
            {
                _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
            }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<OrderDto>> GetOrders()
        {
            var orders = _ordersRepository.GetOrders();

            return Ok(orders);
        }
        [HttpGet("{orderId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDto> GetOrder(int orderId)
        {
            var order = _ordersRepository.GetOrder(orderId);
            if (order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // DELETE api/orders/{id}
        [HttpDelete("{orderId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteOrder(int orderId)
        {
            var success = _ordersRepository.DeleteOrder(orderId);

            return success ? NoContent() : NotFound();
        }
    }
}

