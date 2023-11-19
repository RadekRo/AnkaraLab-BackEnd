using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class LoyaltyProgramRepository : ILoyaltyProgramRepository

    {
        private readonly AnkaraLabDbContext _dbContext;
        public LoyaltyProgramRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        
        public async Task AddLoyaltyProgramAsync(LoyaltyProgram loyaltyProgram)
        {
                _dbContext.LoyaltyPrograms.Add(loyaltyProgram);
                await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> DeleteLoyaltyProgramAsync(int id)
            {
                var loyaltyProgram = await _dbContext.LoyaltyPrograms.SingleOrDefaultAsync(lp => lp.Id == id);

            if (loyaltyProgram is null)
                {
                    return false;
                }
                _dbContext.LoyaltyPrograms.Remove(loyaltyProgram);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            

            public async Task<IEnumerable<LoyaltyProgram>> GetFaqsAsync()
            {
                var query = _dbContext.LoyaltyPrograms.AsQueryable();

                return await query.ToListAsync();
            }
            public async Task<bool> UpdateLoyaltyProgramAsync(LoyaltyProgram loyaltyProgram)
            {
                var loyaltyProgramFromDb = await _dbContext.LoyaltyPrograms.SingleOrDefaultAsync(f => f.Id == loyaltyProgram.Id);

            if (loyaltyProgramFromDb is null)
                {
                    return false;
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }

        public async Task<IEnumerable<LoyaltyProgram>> GetLoyaltyProgramsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<LoyaltyProgram> GetLoyaltyProgramByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
 }

