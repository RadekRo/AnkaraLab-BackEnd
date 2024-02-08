using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        Task<Client?> GetClientByEmailAsync(string email);
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client?> GetClientAsync(int id);
        Task<ClientForShippingDto> GetClientShippingDetailsAsync(int id);
        Task RegisterClientAsync(Client client);
        Task UpdateClientAsync(Client? client);
        Task<bool> DeleteClientAsync(int id);
        public string GenerateJwt(Client client);
        bool CheckPassword(LoginDto loginDto, Client client);
    }
}
