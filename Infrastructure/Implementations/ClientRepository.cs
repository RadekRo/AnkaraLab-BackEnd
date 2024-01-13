using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AnkaraLab_BackEnd.WebAPI.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        private readonly IPasswordHasher<Client> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        public ClientRepository(AnkaraLabDbContext dbContext, IPasswordHasher<Client> passwordHasher, AuthenticationSettings authenticationSettings)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await _dbContext.Clients.SingleOrDefaultAsync(c => c.Id == id);

            if (client is null)
            {
                return false;
            }
            _dbContext.Clients.Remove(client);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Client?> GetClientByEmailAsync(string email)
        {
                return await _dbContext.Clients.SingleOrDefaultAsync(c => c.Email == email);
        }
        public bool CheckPassword(LoginDto loginDto, Client client)
        {
          var result =  _passwordHasher.VerifyHashedPassword(client, client.Password, loginDto.Password);
            if (result == PasswordVerificationResult.Success)
            {
                return true;
            }
            return false;
        }
        public async Task<Client?> GetClientAsync(int id)
        {
            return await _dbContext.Clients.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            var query = _dbContext.Clients.AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<bool> UpdateClientAsync(Client client)
        {
            var clientFromDb = await _dbContext.Clients.SingleOrDefaultAsync(c => c.Id == client.Id);

            if (clientFromDb is null)
            {
                return false;
            }
            clientFromDb.Email = client.Email;
            clientFromDb.Password = client.Password;
            clientFromDb.Name = client.Name;
            clientFromDb.Surname = client.Surname;
            clientFromDb.Newsletter = client.Newsletter;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task RegisterClientAsync(Client client)
        {
            var newClient = new Client()
            {
                Email = client.Email,
                Name = client.Name,
                Surname = client.Surname
            };
            var hashedPassword = _passwordHasher.HashPassword(newClient, client.Password);
            newClient.Password = hashedPassword;
            _dbContext.Clients.Add(newClient);
            await _dbContext.SaveChangesAsync();
        }

        public string GenerateJwt(Client client)
        {
           
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, client.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{client.Name} {client.Surname}"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.JwtKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(_authenticationSettings.JwtExpireDays);

            var token = new JwtSecurityToken(_authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
