using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IFaqRepository
    {
        IEnumerable<Faq> GetFaqs();
        Faq? GetFaq(int id);
        void CreateFaq(Faq faq);
        bool UpdateFaq(Faq faq);
        bool DeleteFaq(int id);
    }
}
