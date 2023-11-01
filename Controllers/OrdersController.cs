using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure;
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
        public ActionResult<IEnumerable<OrderDto>> GetOrders()
        {
            var orders = _ordersRepository.GetOrders();

            return Ok(orders);
        }
        // GET api/orders/{id}
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<OrderDto> GetOrder(int id)
        {
            var order = _ordersRepository.GetOrder(id);
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
        public IActionResult DeleteOrder(int id)
        {
            var success = _ordersRepository.DeleteOrder(id);

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

