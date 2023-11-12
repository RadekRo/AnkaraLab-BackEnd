using AnkaraLab_BackEnd.WebAPI.Domain;
using Microsoft.Identity.Client;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IProductsRepository
    {
        Product? GetProduct(int id);
        void CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
        IEnumerable<Product> GetProductsByCategory(int categoryId);
    }
}
