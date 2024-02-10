using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnkaraLab_BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/newsletter")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class NewslettersController : ControllerBase
    {
        private readonly INewsletterRepository _newsletterRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<NewslettersController> _logger;
        public NewslettersController(INewsletterRepository newsletterRepository, IMapper mapper, ILogger<NewslettersController> logger)
        {
            _newsletterRepository = newsletterRepository ?? throw new ArgumentNullException(nameof(newsletterRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddNewsletter([FromBody] NewsletterForCreationDto newsletterForCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newsletter = _mapper.Map<Newsletter>(newsletterForCreationDto);

            await _newsletterRepository.AddNewsletterAsync(newsletter);

            var newsletterDto = _mapper.Map<NewsletterDto>(newsletter);

            return CreatedAtAction(nameof(GetNewsletter), new { id = newsletter.Id }, newsletterDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NewsletterDto>> GetNewsletter(int id)
        {
            var newsletter = await _newsletterRepository.GetNewsletterAsync(id);
            if (newsletter is null)
            {
                return NotFound();
            }
            return Ok(newsletter);
        }

        [HttpDelete("delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteNewsletter(int id)
        {
            var newsletterToDelete = await _newsletterRepository.DeleteNewsletterAsync(id);
            if (newsletterToDelete == false)
            {
                return NotFound("There is no such item");
            }
            return Ok(newsletterToDelete);
        }
    }
}