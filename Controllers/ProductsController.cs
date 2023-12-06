using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductsRepository productsRepository, IMapper mapper, ILogger<ProductsController> logger)
        {
            _productsRepository = productsRepository ?? throw new ArgumentNullException(nameof(productsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); ;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 7200)]
        [ResponseCache(CacheProfileName = "Any-7200")]
        public async Task<ActionResult<ProductDto>> GetProduct(int id) 
        {
            var product = await _productsRepository.GetProductAsync(id);
            if (product is null) 
            { 
                return NotFound(); 
            }
            return Ok(product);
        }

        [HttpGet("/api/products/byCategory/{categoryId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProductsByCategory(int categoryId)
        {
            var products = await _productsRepository.GetProductsByCategoryAsync(categoryId);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
            _logger.LogInformation("Estabilished connection with database. Retrieved all products for category: {categoryId}.", categoryId);
            return Ok(productsDto);
        }

        [HttpDelete("api/products/delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProduct(int id) 
        {
            var productToDelete = await _productsRepository.DeleteProductAsync(id);
            if (productToDelete == false) 
            {
                return NotFound("There is no such item"); 
            }
            return Ok(productToDelete);
        }

        [HttpPut("api/products/new")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto productForCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _mapper.Map<Product>(productForCreationDto);

            await _productsRepository.CreateProductAsync(product);

            var productDto = _mapper.Map<ProductDto>(product);

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, productDto);
        }

        [HttpGet("api/products/random")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetRandomProduct()
        {
            var product = await _productsRepository.GetRandomProductAsync();
            if (product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
