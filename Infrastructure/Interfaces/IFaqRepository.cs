using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IFaqRepository
    {
        Task<IEnumerable<Faq>> GetFaqsAsync();
        Task<Faq?> GetFaqAsync(int id);
        void CreateFaq(Faq faq);
        bool UpdateFaq(Faq faq);
        Task<bool> DeleteFaqAsync(int id);
    }
}
