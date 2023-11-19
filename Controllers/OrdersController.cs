using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AutoMapper;
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
        private readonly IMapper _mapper;
        public OrdersController(IOrdersRepository ordersRepository, IMapper mapper)
            {
                _ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
                _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            }
        // GET api/orders
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var orders = await _ordersRepository.GetOrdersAsync();

            return Ok(orders);
        }
        // GET api/orders/{id}
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderDto>> GetOrder(int id)
        {
            var order = await _ordersRepository.GetOrderAsync(id);
            if (order is null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // DELETE api/orders/{id}
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var success = await _ordersRepository.DeleteOrderAsync(id);

            return success ? NoContent() : NotFound();
        }

        // POST api/orders
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult CreateOrder([FromBody] OrderForCreationDto orderForCreationDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var order = _mapper.Map<Order>(orderForCreationDto);

        //    _ordersRepository.CreateOrder(order);

        //    var orderDto = _mapper.Map<OrderDto>(order);

        //    return CreatedAtAction(nameof(GetOrder), new { id = order.Id }, orderDto);
        //}
    }
}

