using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        public CategoryRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public void CreateCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
        }

        public bool UpdateCategory(Category category)
        {
            var categoryFromDb = _dbContext.Categories.SingleOrDefault(c  => c.Id == category.Id);
            if (categoryFromDb is null)
            {
                return false;
            }
            categoryFromDb.Name = category.Name;
            categoryFromDb.Description = category.Description;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
