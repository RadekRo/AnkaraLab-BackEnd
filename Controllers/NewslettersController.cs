using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
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
    }
}