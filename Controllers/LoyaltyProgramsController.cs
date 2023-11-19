using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnkaraLab_BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/loyaltyprograms")]
    public class LoyaltyProgramsController : ControllerBase
    {
        private readonly ILoyaltyProgramRepository _repository;
        private readonly IMapper _mapper;

        public LoyaltyProgramsController(ILoyaltyProgramRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLoyaltyPrograms()
        {
            var loyaltyPrograms = await _repository.GetLoyaltyProgramsAsync();
            var loyaltyProgramDtos = _mapper.Map<IEnumerable<LoyaltyProgramDto>>(loyaltyPrograms);
            return Ok(loyaltyProgramDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLoyaltyProgramById(int id)
        {
            var loyaltyProgram = await _repository.GetLoyaltyProgramByIdAsync(id);
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
            await _repository.AddLoyaltyProgramAsync(loyaltyProgram);
            return Ok(loyaltyProgramDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLoyaltyProgram(int id, LoyaltyProgramDto loyaltyProgramDto)
        {
            var existingLoyaltyProgram = await _repository.GetLoyaltyProgramByIdAsync(id);
            if (existingLoyaltyProgram == null)
            {
                return NotFound();
            }

            _mapper.Map(loyaltyProgramDto, existingLoyaltyProgram);
            await _repository.UpdateLoyaltyProgramAsync(existingLoyaltyProgram);
            return Ok(loyaltyProgramDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoyaltyProgram(int id)
        {
            var existingLoyaltyProgram = await _repository.GetLoyaltyProgramByIdAsync(id);
            if (existingLoyaltyProgram == null)
            {
                return NotFound();
            }

            await _repository.DeleteLoyaltyProgramAsync(id);
            return NoContent();
        }
    }
 }