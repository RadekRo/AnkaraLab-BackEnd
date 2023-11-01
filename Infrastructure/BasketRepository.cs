using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure
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
            if (! _dbContext.Baskets.Contains(basket)) 
            { 
                _dbContext.Baskets.Add(basket); 
                _dbContext.SaveChanges();
            }
            
        }
        public bool DeleteBasket(Basket basket) 
        { 
            _dbContext.Baskets.Remove(basket);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
