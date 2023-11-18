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
        private readonly ILogger<BasketsController> _logger;
        public BasketsController(IBasketRepository basketRepository, IMapper mapper, ILogger<BasketsController> logger)
        {
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("{clientId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<BasketDto>> GetBaskets(int clientId)
        {
            var baskets = _basketRepository.GetBaskets(clientId);
            _logger.LogInformation("Estabilished connection with database. Retrieved all items for client: {clientId}.", clientId);

            return Ok(baskets);
        }

        [HttpDelete("delete/{id:int}")]
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

            return CreatedAtAction(nameof(GetBaskets), new { id = basket.Id }, basketDto);
        }

        [HttpPut("/new")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult AddBasket([FromBody] BasketDto basket)
        {
            var basketDb = new Basket
            {
                ClientId = basket.ClientId,
                ProductId = basket.ProductId,
                Quantity = basket.Quantity,
                OrderId = basket.OrderId
            };

            _basketRepository.CreateBasket(basketDb);
            return Ok(basketDb);
        }
    }
}
