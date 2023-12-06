using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly AnkaraLabDbContext _dbContext;

        public ProductsRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task CreateProductAsync(Product product)
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);

            if (product is null)
            {
                return false;
            }
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId) 
        { 
            var products = _dbContext.Products.Where(p => p.CategoryId == categoryId).AsQueryable();

        return await products.ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int id)
        {
            return await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Product?> GetRandomProductAsync()
        {
            var count = await _dbContext.Products.CountAsync();

            if (count == 0)
            {
                return null;
            }

            var randomIndex = new Random().Next(0, count);
            var randomProduct = await _dbContext.Products
                .Skip(randomIndex)
                .FirstOrDefaultAsync();

            return randomProduct;
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            var query = _dbContext.Products.AsQueryable();
            query = query.Where(p => p.CategoryId == categoryId);
            return query.ToList();
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var productFromDb = await _dbContext.Products.SingleOrDefaultAsync(p => p.Id == product.Id);

            if (productFromDb is null)
            {
                return false;
            }
            productFromDb.Size = product.Size;
            productFromDb.Description = product.Description;
            productFromDb.Price = product.Price;
            productFromDb.Deadline = product.Deadline;
            productFromDb.IsAvaliable = product.IsAvaliable;
            productFromDb.PhotoHeight = product.PhotoHeight;
            productFromDb.PhotoWidth = product.PhotoWidth;
            productFromDb.CategoryId = product.CategoryId;

            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
