using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IProductsRepository
    {
        IEnumerable <Product> GetProducts(int categoryId);
        Product? GetProduct(int id);
        void CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);

        
    }
}
