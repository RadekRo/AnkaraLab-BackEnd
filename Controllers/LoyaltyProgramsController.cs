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
        public IActionResult GetLoyaltyPrograms()
        {
            var loyaltyPrograms = _repository.GetLoyaltyPrograms();
            var loyaltyProgramDtos = _mapper.Map<IEnumerable<LoyaltyProgramDto>>(loyaltyPrograms);
            return Ok(loyaltyProgramDtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetLoyaltyProgramById(int id)
        {
            var loyaltyProgram = _repository.GetLoyaltyProgramById(id);
            if (loyaltyProgram == null)
            {
                return NotFound();
            }

            var loyaltyProgramDto = _mapper.Map<LoyaltyProgramDto>(loyaltyProgram);
            return Ok(loyaltyProgramDto);
        }

        [HttpPost]
        public IActionResult AddLoyaltyProgram(LoyaltyProgramDto loyaltyProgramDto)
        {
            var loyaltyProgram = _mapper.Map<LoyaltyProgram>(loyaltyProgramDto);
            _repository.AddLoyaltyProgram(loyaltyProgram);
            return Ok(loyaltyProgramDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLoyaltyProgram(int id, LoyaltyProgramDto loyaltyProgramDto)
        {
            var existingLoyaltyProgram = _repository.GetLoyaltyProgramById(id);
            if (existingLoyaltyProgram == null)
            {
                return NotFound();
            }

            _mapper.Map(loyaltyProgramDto, existingLoyaltyProgram);
            _repository.UpdateLoyaltyProgram(existingLoyaltyProgram);
            return Ok(loyaltyProgramDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLoyaltyProgram(int id)
        {
            var existingLoyaltyProgram = _repository.GetLoyaltyProgramById(id);
            if (existingLoyaltyProgram == null)
            {
                return NotFound();
            }

            _repository.DeleteLoyaltyProgram(id);
            return NoContent();
        }
    }
 }