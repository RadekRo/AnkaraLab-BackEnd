using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IBasketRepository
    {
        Task<IEnumerable<Basket>> GetBasketsAsync(int clientId);
        Task<Basket?> GetBasketAsync(int id);
        Task CreateBasketAsync(Basket basket);
        Task <bool> UpdateBasketAsync(Basket basket);
        Task<bool> DeleteBasketAsync(int id);
    }
}
