using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category?> GetCategoryAsync(int id);
        Task CreateCategoryAsync(Category category);
        Task <bool> UpdateCategoryAsync(Category category);
        Task <bool> DeleteCategoryAsync(int id);
    }
}
