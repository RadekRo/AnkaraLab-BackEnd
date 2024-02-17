using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;

namespace AnkaraLab_BackEnd.WebAPI.Controllers
{
    [ApiController]
    [Route("api/client")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ClientsController> _logger;
        public ClientsController(IClientRepository clientRepository, IMapper mapper, ILogger<ClientsController> logger)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
        {
            var clients = await _clientRepository.GetClientsAsync();
            _logger.LogInformation("Estabilished connection with database. Retrieved all clients:");
            return Ok(clients);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientDto>> GetClient(int id)
        {
            var client = await _clientRepository.GetClientAsync(id);
            if (client is null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpGet("shippingData/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClientForShippingDto>> GetClientShippingDetails(int id)
        {
            var clientForShipping = await _clientRepository.GetClientAsync(id);
            _mapper.Map<ClientForShippingDto>(clientForShipping);
            if (clientForShipping is null)
            {
                return NotFound();
            }
            return Ok(clientForShipping);
        }

        [HttpDelete("delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteClient(int id)
        {
            var clientToDelete = await _clientRepository.DeleteClientAsync(id);
            if (clientToDelete == false)
            {
                return NotFound("There is no such item");
            }
            return Ok(clientToDelete);
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterClient([FromBody] ClientForRegistrationDto clientForRegistrationDto)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var client = _mapper.Map<Client>(clientForRegistrationDto);

            if (client is null)
            {
                return BadRequest("Client is null");
            }

            await _clientRepository.RegisterClientAsync(client);

            //var clientDto = _mapper.Map<ClientDto>(client);
            //return CreatedAtAction(nameof(GetClient), new { id = client.Id }, clientDto);
            return Ok();
        }

        [HttpPost("update/{id:int}")]
        public async Task<ActionResult> UpdateClient([FromBody] ClientForUpdateDto clientForUpdateDto, int id, string street, string houseNumber, string apartamentNumber, string city, string zipCode, string country)
        {
            var client = _mapper.Map<Client>(clientForUpdateDto);

            if (client is null)
            {
                return BadRequest("Client is null");
            }
            await _clientRepository.UpdateClientAsync(id, street, houseNumber, apartamentNumber, city, zipCode, country);
            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> LoginClient([FromBody] LoginDto loginDto)
        {
            var clientFromDb = await _clientRepository.GetClientByEmailAsync(loginDto.Email);

            if (clientFromDb != null)
            {
                if (_clientRepository.CheckPassword(loginDto, clientFromDb))
                {
                    string token = _clientRepository.GenerateJwt(clientFromDb);
                    return Ok(token);
                }
                return Unauthorized(new { message = "Błędne hasło" });
            }
            else
            {
                return NotFound(new { message = "Nie ma takiego użytkownika" });
            }
        }

    }
}

