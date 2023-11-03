using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IBasketItemsRepository
    {
        public void AddItem(BasketItems basketItems);
        public void RemoveItem(BasketItems basketItems);
        public IEnumerable<BasketItems> GetItems(int clientId);
        public bool UpdateItem(BasketItems basketItems);

    }
}
