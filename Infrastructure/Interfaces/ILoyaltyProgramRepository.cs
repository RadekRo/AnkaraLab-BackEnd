using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
   

public interface ILoyaltyProgramRepository
    {
        Task<IEnumerable<LoyaltyProgram>> GetLoyaltyProgramsAsync();
        Task<LoyaltyProgram> GetLoyaltyProgramByIdAsync(int id);
        Task AddLoyaltyProgramAsync(LoyaltyProgram loyaltyProgram);
        Task<bool> UpdateLoyaltyProgramAsync(LoyaltyProgram loyaltyProgram);
        Task<bool> DeleteLoyaltyProgramAsync(int id);
    }
}

