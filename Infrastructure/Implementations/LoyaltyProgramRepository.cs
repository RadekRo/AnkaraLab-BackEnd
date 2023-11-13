using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class LoyaltyProgramRepository : ILoyaltyProgramRepository

    {
        private readonly AnkaraLabDbContext _dbContext;
        public LoyaltyProgramRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        
        public void AddLoyaltyProgram(LoyaltyProgram loyaltyProgram)
        {
                _dbContext.LoyaltyPrograms.Add(loyaltyProgram);
                _dbContext.SaveChanges();
            }
            public bool DeleteLoyaltyProgram(int id)
            {
                var loyaltyProgram = _dbContext.LoyaltyPrograms.SingleOrDefault(lp => lp.Id == id);

                if (loyaltyProgram is null)
                {
                    return false;
                }
                _dbContext.LoyaltyPrograms.Remove(loyaltyProgram);
                _dbContext.SaveChanges();

                return true;
            }
            

            public IEnumerable<LoyaltyProgram> GetFaqs()
            {
                var query = _dbContext.LoyaltyPrograms.AsQueryable();

                return query.ToList();
            }
            public bool UpdateLoyaltyProgram(LoyaltyProgram loyaltyProgram)
            {
                var loyaltyProgramFromDb = _dbContext.LoyaltyPrograms.SingleOrDefault(f => f.Id == loyaltyProgram.Id);

                if (loyaltyProgramFromDb is null)
                {
                    return false;
                }
            


                _dbContext.SaveChanges();
                return true;
            }

        public IEnumerable<LoyaltyProgram> GetLoyaltyPrograms()
        {
            throw new NotImplementedException();
        }

        public LoyaltyProgram GetLoyaltyProgramById(int id)
        {
            throw new NotImplementedException();
        }
    }
 }

