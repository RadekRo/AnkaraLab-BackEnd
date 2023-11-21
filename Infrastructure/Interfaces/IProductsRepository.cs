using AnkaraLab_BackEnd.WebAPI.Domain;
using Microsoft.Identity.Client;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IProductsRepository
    {
        Task<Product?> GetProductAsync(int id);
        Task CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
    }
}
