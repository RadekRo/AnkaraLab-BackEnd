using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetProducts();
        Product? GetProduct(int id);
        void CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }
}
