using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AnkaraLab_BackEnd.WebAPI.Migrations;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class BasketRepository : IBasketRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        public BasketRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public void CreateBasket(Basket basket)
        {
            _dbContext.Baskets.Add(basket);
            _dbContext.SaveChanges();
        }

        public bool DeleteBasket(int id)
        {
            var basket = _dbContext.Baskets.SingleOrDefault(b => b.Id == id);

            if (basket is null)
            {
                return false;
            }
            _dbContext.Baskets.Remove(basket);
            _dbContext.SaveChanges();

            return true;
        }

        public Basket? GetBasket(int id)
        {
            return _dbContext.Baskets.SingleOrDefault(b => b.Id == id);
        }

        public IEnumerable<Basket> GetBaskets(int clientId)
        {
            var query = _dbContext.Baskets
                            .Where(b => b.ClientId == clientId)
                            .AsQueryable();

            return query.ToList();
        }

        public bool UpdateBasket(Basket basket)
        {
            var basketFromDb = _dbContext.Baskets.SingleOrDefault(b => b.Id == basket.Id);

            if (basketFromDb is null)
            {
                return false;
            }
            basketFromDb.ClientId = basket.ClientId;
            basketFromDb.ProductId = basket.ProductId;
            basketFromDb.Quantity = basket.Quantity;
            basketFromDb.OrderId = basket.OrderId;


            _dbContext.SaveChanges();
            return true;
        }
    }
}
