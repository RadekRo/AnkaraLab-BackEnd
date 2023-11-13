using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
   

public interface ILoyaltyProgramRepository
    {
        IEnumerable<LoyaltyProgram> GetLoyaltyPrograms();
        LoyaltyProgram GetLoyaltyProgramById(int id);
        void AddLoyaltyProgram(LoyaltyProgram loyaltyProgram);
        bool UpdateLoyaltyProgram(LoyaltyProgram loyaltyProgram);
        bool DeleteLoyaltyProgram(int id);
    }
}

