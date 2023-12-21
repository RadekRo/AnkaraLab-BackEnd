using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client?> GetClientAsync(int id);
        Task RegisterClientAsync(Client client);
        Task<bool> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(int id);
    }
}
