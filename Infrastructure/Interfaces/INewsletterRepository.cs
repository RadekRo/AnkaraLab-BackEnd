using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface INewsletterRepository
    {
        Task AddNewsletterAsync(Newsletter newsletter);
        Task<bool> DeleteNewsletterAsync(int id);
    }
}
