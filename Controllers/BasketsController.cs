using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnkaraLab_BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/basket")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketsController(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BasketDto> GetBasket(int id)
        {
            var basket= _basketRepository.GetBasket(id);
            if (basket is null)
            {
                return NotFound();
            }
            return Ok(basket);
        }

        [HttpDelete("api/basket/delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteBasket(int id)
        {
            var basketToDelete = _basketRepository.DeleteBasket(id);
            if (basketToDelete == false)
            {
                return NotFound("There is no such item");
            }
            return Ok(basketToDelete);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult CreateBasket([FromBody] BasketForCreationDto basketForCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var basket = _mapper.Map<Basket>(basketForCreationDto);

            _basketRepository.CreateBasket(basket);

            var basketDto = _mapper.Map<BasketDto>(basket);

            return CreatedAtAction(nameof(GetBasket), new { id = basket.Id }, basketDto);
        }
    }
}
