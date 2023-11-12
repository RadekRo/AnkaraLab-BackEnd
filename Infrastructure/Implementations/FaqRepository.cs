using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class FaqRepository : IFaqRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        public FaqRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void CreateFaq(Faq faq)
        {
            _dbContext.Faqs.Add(faq);
            _dbContext.SaveChanges();
        }
        public bool DeleteFaq(int id)
        {
            var faq = _dbContext.Faqs.SingleOrDefault(f => f.Id == id);

            if (faq is null)
            {
                return false;
            }
            _dbContext.Faqs.Remove(faq);
            _dbContext.SaveChanges();

            return true;
        }
        public Faq? GetFaq(int id)
        {
            return _dbContext.Faqs.SingleOrDefault(f => f.Id == id);
        }

        public IEnumerable<Faq> GetFaqs()
        {
            var query = _dbContext.Faqs.AsQueryable();

            return query.ToList();
        }
        public bool UpdateFaq(Faq faq)
        {
            var faqFromDb = _dbContext.Faqs.SingleOrDefault(f => f.Id == faq.Id);

            if (faqFromDb is null)
            {
                return false;
            }
            faqFromDb.Answer = faq.Answer;
            faqFromDb.Question = faq.Question;


            _dbContext.SaveChanges();
            return true;
        }
    }
}
