using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using AnkaraLab_BackEnd.WebAPI.Migrations;
using Microsoft.EntityFrameworkCore;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class NewsletterRepository : INewsletterRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        public NewsletterRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Newsletter>> GetNewslettersAsync()
        {
            var query = _dbContext.Newsletters.AsQueryable();

            return await query.ToListAsync();
        }

        public async Task<Newsletter?> GetNewsletterAsync(int id)
        {
            return await _dbContext.Newsletters.SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task AddNewsletterAsync(Newsletter newsletter)
        {
            _dbContext.Newsletters.Add(newsletter);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteNewsletterAsync(int id)
        {
            var newsletter = await _dbContext.Newsletters.SingleOrDefaultAsync(f => f.Id == id);

            if (newsletter is null)
            {
                return false;
            }
            _dbContext.Newsletters.Remove(newsletter);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
