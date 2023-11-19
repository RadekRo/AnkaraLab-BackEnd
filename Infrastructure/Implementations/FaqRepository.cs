using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class FaqRepository : IFaqRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        public FaqRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task CreateFaqAsync(Faq faq)
        {
            _dbContext.Faqs.Add(faq);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> DeleteFaqAsync(int id)
        {
            var faq = await _dbContext.Faqs.SingleOrDefaultAsync(f => f.Id == id);

            if (faq is null)
            {
                return false;
            }
            _dbContext.Faqs.Remove(faq);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<Faq?> GetFaqAsync(int id)
        {
            return await _dbContext.Faqs.SingleOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Faq>> GetFaqsAsync()
        {
            var query = _dbContext.Faqs.AsQueryable();

            return await query.ToListAsync();
        }
        public async Task<bool> UpdateFaqAsync(Faq faq)
        {
            var faqFromDb = await _dbContext.Faqs.SingleOrDefaultAsync(f => f.Id == faq.Id);

            if (faqFromDb is null)
            {
                return false;
            }
            faqFromDb.Answer = faq.Answer;
            faqFromDb.Question = faq.Question;


            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
