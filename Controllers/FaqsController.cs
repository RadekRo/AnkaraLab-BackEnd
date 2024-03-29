﻿using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnkaraLab_BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/faq")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class FaqsController : ControllerBase
    {
        private readonly IFaqRepository _faqRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<FaqsController> _logger;
        public FaqsController(IFaqRepository faqRepository, IMapper mapper, ILogger<FaqsController> logger)
        {
            _faqRepository = faqRepository ?? throw new ArgumentNullException(nameof(faqRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<FaqDto>>> GetFaqs()
        {
            var faqs = await _faqRepository.GetFaqsAsync();
            _logger.LogInformation("Estabilished connection with database. Retrieved all frequently asked questions:");
            return Ok(faqs);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FaqDto>> GetFaq(int id)
        {
            var faq = await _faqRepository.GetFaqAsync(id);
            if (faq is null)
            {
                return NotFound();
            }
            return Ok(faq);
        }

        [HttpDelete("delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteFaq(int id)
        {
            var faqToDelete = await _faqRepository.DeleteFaqAsync(id);
            if (faqToDelete == false)
            {
                return NotFound("There is no such item");
            }
            return Ok(faqToDelete);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateFaq([FromBody] FaqForCreationDto faqForCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var faq = _mapper.Map<Faq>(faqForCreationDto);

            await _faqRepository.CreateFaqAsync(faq);

            var faqDto = _mapper.Map<FaqDto>(faq);

            return CreatedAtAction(nameof(GetFaq), new { id = faq.Id }, faqDto);
        }
    }
}
