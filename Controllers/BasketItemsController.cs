using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnkaraLab_BackEnd.WebAPI.Controllers
{
    [ApiController]

    [Route("api/basket")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]

    public class BasketItemsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBasketItemsRepository _basketItemsRepository;
        public BasketItemsController(IBasketItemsRepository basketItemsRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _basketItemsRepository = basketItemsRepository ?? throw new ArgumentNullException(nameof(basketItemsRepository));
        }

        [HttpPost]
        
        public IActionResult AddItemToBasket([FromBody] BasketItemsDto basketItemsDto) 
        {
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState); 
            }
            var basketItem = _mapper.Map<BasketItems>(basketItemsDto);
            _basketItemsRepository.AddItem(basketItem);
            return Ok();
        }
        

    }
}
