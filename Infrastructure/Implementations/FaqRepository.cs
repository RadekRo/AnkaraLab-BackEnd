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
        public void CreateAnswer(Faq answer)
        {
            _dbContext.Faqs.Add(answer);
            _dbContext.SaveChanges();
        }

        public void CreateQuestion(Faq question)
        {
            _dbContext.Faqs.Add(question);
            _dbContext.SaveChanges();
        }

        public bool DeleteAnswer(int id)
        {
            var answer = _dbContext.Faqs.SingleOrDefault(a => a.Id == id);

            if (answer is null)
            {
                return false;
            }
            _dbContext.Faqs.Remove(answer);
            _dbContext.SaveChanges();

            return true;
        }

        public bool DeleteQuestion(int id)
        {
            var question = _dbContext.Faqs.SingleOrDefault(q => q.Id == id);

            if (question is null)
            {
                return false;
            }
            _dbContext.Faqs.Remove(question);
            _dbContext.SaveChanges();

            return true;
        }

        public bool UpdateAnswer(int id, Faq answer)
        {
            throw new NotImplementedException();
        }

        public bool UpdateQuestion(int id, Faq question)
        {
            throw new NotImplementedException();
        }
    }
}
