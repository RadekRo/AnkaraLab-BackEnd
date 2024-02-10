using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface INewsletterRepository
    {
        Task<IEnumerable<Newsletter>> GetNewslettersAsync();
        Task<Newsletter?> GetNewsletterAsync(int id);
        Task AddNewsletterAsync(Newsletter newsletter);
        Task<bool> DeleteNewsletterAsync(int id);
    }
}
