using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IBasketRepository
    {
        IEnumerable<Basket> GetBaskets();
        Basket? GetBasket(int id);
        void CreateBasket(Basket basket);
        bool UpdateBasket(Basket basket);
        bool DeleteBasket(int id);
    }
}
