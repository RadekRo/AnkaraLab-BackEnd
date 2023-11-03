using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure
{
    public class BasketItemsRepository : IBasketItemsRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        public BasketItemsRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public void AddItem(BasketItems basketItem)
        {
            _dbContext.BasketItems.Add(basketItem);
        }

        public IEnumerable<BasketItems> GetItems(int clientId)
        {
            var query = _dbContext.BasketItems.AsQueryable().Where(b => b.ClientId == clientId);
            return query.ToList();
        }

        public void RemoveItem(BasketItems basketItem)
        {
            _dbContext.Remove(basketItem);
        }

        public bool UpdateItem(BasketItems basketItem)
        {
            var basketItemFromDb = _dbContext.BasketItems.SingleOrDefault(b => b.Id == basketItem.Id);
            if (basketItemFromDb == null) 
            { 
                return false; 
            }
            basketItemFromDb.Product = basketItem.Product;
            basketItemFromDb.Quantity = basketItem.Quantity;
            basketItemFromDb.ClientId = basketItem.ClientId;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
