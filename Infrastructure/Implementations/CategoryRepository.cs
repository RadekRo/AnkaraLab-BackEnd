﻿using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        public CategoryRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task CreateCategoryAsync(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);

            if (category is null)
            {
                return false;
            }
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Category?> GetCategoryAsync(int id)
        {
            return await _dbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var query = _dbContext.Categories.AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            var categoryFromDb = await _dbContext.Categories.SingleOrDefaultAsync(c => c.Id == category.Id);
            if (categoryFromDb is null)
            {
                return false;
            }
            categoryFromDb.Name = category.Name;
            categoryFromDb.Description = category.Description;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
