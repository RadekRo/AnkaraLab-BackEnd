using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnkaraLab_BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/products")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;
        public ProductsController(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet("getProductByCategory/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProductByCategory(int categoryId)
        {
            var product = _productsRepository.GetProductByCategory(categoryId);
            if (categoryId == 0) 
            {
                return BadRequest(); 
            }
            if (product == null) 
            {
                return NotFound();
            }
            return Ok(product);
        }
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProductDto>> GetProducts()
        {
            var products = _productsRepository.GetProducts();
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

            return Ok(productsDto);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductDto> GetProduct(int id) 
        {
            var product = _productsRepository.GetProduct(id);
            if (product is null) 
            { 
                return NotFound(); 
            }
            return Ok(product);
        }

    }
}
