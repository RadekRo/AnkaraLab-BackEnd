using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AnkaraLab_BackEnd.WebAPI.Migrations;
using Microsoft.EntityFrameworkCore;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        public ClientRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task CreateClientAsync(Client client)
        {
            _dbContext.Clients.Add(client);
            await _dbContext.SaveChangesAsync();
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
            clientFromDb.Login = client.Login;
            clientFromDb.Password = client.Password;
            clientFromDb.Name = client.Name;
            clientFromDb.Surname = client.Surname;
            clientFromDb.Newsletter = client.Newsletter;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
