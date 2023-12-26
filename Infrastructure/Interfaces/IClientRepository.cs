using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client?> GetClientAsync(int id);
        Task RegisterClientAsync(Client client);
        public string GenerateJwt(LoginDto dto);
        Task<bool> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(int id);
    }
}
