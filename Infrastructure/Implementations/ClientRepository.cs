using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AnkaraLab_BackEnd.WebAPI.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        private readonly IPasswordHasher<Client> _passwordHasher;
        public ClientRepository(AnkaraLabDbContext dbContext, IPasswordHasher<Client> passwordHasher)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _passwordHasher = passwordHasher;
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
    }
}
