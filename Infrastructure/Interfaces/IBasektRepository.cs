using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IBasektRepository
    {
        Basket? GetBasket(int id);
        void CreateBaskeq(Basket basket);
        bool UpdateBasket(Basket basket);
        bool DeleteBasket(int id);
    }
}
