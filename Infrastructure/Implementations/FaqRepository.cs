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
            throw new NotImplementedException();
        }

        public void CreateQuestion(Faq question)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAnswer(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteQuestion(int id)
        {
            throw new NotImplementedException();
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
