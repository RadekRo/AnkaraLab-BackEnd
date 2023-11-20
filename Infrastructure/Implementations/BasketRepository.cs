using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AnkaraLab_BackEnd.WebAPI.Migrations;
using Microsoft.EntityFrameworkCore;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class BasketRepository : IBasketRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        public BasketRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task CreateBasketAsync(Basket basket)
        {
            _dbContext.Baskets.Add(basket);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteBasketAsync(int id)
        {
            var basket = await _dbContext.Baskets.SingleOrDefaultAsync(b => b.Id == id);

            if (basket is null)
            {
                return false;
            }
            _dbContext.Baskets.Remove(basket);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Basket?> GetBasketAsync(int id)
        {
            return await _dbContext.Baskets.SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Basket>> GetBasketsAsync(int clientId)
        {
            var query = _dbContext.Baskets
                            .Where(b => b.ClientId == clientId)
                            .AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<bool> UpdateBasketAsync(Basket basket)
        {
            var basketFromDb = await _dbContext.Baskets.SingleOrDefaultAsync(b => b.Id == basket.Id);

            if (basketFromDb is null)
            {
                return false;
            }
            basketFromDb.ClientId = basket.ClientId;
            basketFromDb.ProductId = basket.ProductId;
            basketFromDb.Quantity = basket.Quantity;
            basketFromDb.OrderId = basket.OrderId;


            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
