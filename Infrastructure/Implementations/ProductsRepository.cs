using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
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
        public void CreateProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public bool DeleteProduct(int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product is null)
            {
                return false;
            }
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();

            return true;
        }
        public IEnumerable<Product> GetProductByCategory(int categoryId) 
        { 
            var products = _dbContext.Products.Where(p => p.CategoryId == categoryId).AsQueryable();

        return products.ToList();
        }

        public Product? GetProduct(int id)
        {
            return _dbContext.Products.SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            var query = _dbContext.Products.AsQueryable();
            query = query.Where(p => p.CategoryId == categoryId);
            return query.ToList();
        }

        public bool UpdateProduct(Product product)
        {
            var productFromDb = _dbContext.Products.SingleOrDefault(p => p.Id == product.Id);

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
            productFromDb.Category = product.Category;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
