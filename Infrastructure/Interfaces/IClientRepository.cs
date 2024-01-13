using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IClientRepository
    {
        Client GetClientByEmail(string email);
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client?> GetClientAsync(int id);
        Task RegisterClientAsync(Client client);
        public string GenerateJwt(Client client);
        Task<bool> UpdateClientAsync(Client client);
        Task<bool> DeleteClientAsync(int id);
       bool CheckPassword(LoginDto loginDto, Client client);
    }
}
