using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure
{
    public class IBasketRepository
    {
        public interface ICategoryRepository
        {
            void CreateBasket(Basket basket);
            bool DeleteBasket(Basket basket);

        }
    }
}
