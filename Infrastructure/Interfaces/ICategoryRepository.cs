using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
        void CreateCategory(Category category);
        bool UpdateCategory(Category category);

    }
}
