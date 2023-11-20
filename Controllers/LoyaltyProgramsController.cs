using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnkaraLab_BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/loyaltyprograms")]
    public class LoyaltyProgramsController : ControllerBase
    {
        private readonly ILoyaltyProgramRepository _loyaltyProgramRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LoyaltyProgramsController> _logger;

        public LoyaltyProgramsController(ILoyaltyProgramRepository loyaltyProgramRepository, IMapper mapper, ILogger<LoyaltyProgramsController> logger)
        {
            _loyaltyProgramRepository = loyaltyProgramRepository ?? throw new ArgumentNullException(nameof(loyaltyProgramRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> GetLoyaltyPrograms()
        {
            var loyaltyPrograms = await _loyaltyProgramRepository.GetLoyaltyProgramsAsync();
            var loyaltyProgramDtos = _mapper.Map<IEnumerable<LoyaltyProgramDto>>(loyaltyPrograms);
            _logger.LogInformation("Estabilished connection with database. Retrieved all loyalty programs.");
            return Ok(loyaltyProgramDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoyaltyProgramById(int id)
        {
            var loyaltyProgram = await _loyaltyProgramRepository.GetLoyaltyProgramByIdAsync(id);
            if (loyaltyProgram == null)
            {
                return NotFound();
            }

            var loyaltyProgramDto = _mapper.Map<LoyaltyProgramDto>(loyaltyProgram);
            return Ok(loyaltyProgramDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddLoyaltyProgram(LoyaltyProgramDto loyaltyProgramDto)
        {
            var loyaltyProgram = _mapper.Map<LoyaltyProgram>(loyaltyProgramDto);
            await _loyaltyProgramRepository.AddLoyaltyProgramAsync(loyaltyProgram);
            return Ok(loyaltyProgramDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoyaltyProgram(int id, LoyaltyProgramDto loyaltyProgramDto)
        {
            var existingLoyaltyProgram = await _loyaltyProgramRepository.GetLoyaltyProgramByIdAsync(id);
            if (existingLoyaltyProgram == null)
            {
                return NotFound();
            }

            _mapper.Map(loyaltyProgramDto, existingLoyaltyProgram);
            await _loyaltyProgramRepository.UpdateLoyaltyProgramAsync(existingLoyaltyProgram);
            return Ok(loyaltyProgramDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoyaltyProgram(int id)
        {
            var existingLoyaltyProgram = await _loyaltyProgramRepository.GetLoyaltyProgramByIdAsync(id);
            if (existingLoyaltyProgram == null)
            {
                return NotFound();
            }

            await _loyaltyProgramRepository.DeleteLoyaltyProgramAsync(id);
            return NoContent();
        }
    }
 }