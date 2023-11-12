using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IFaqRepository
    {
        void CreateQuestion(Faq question);
        void CreateAnswer(Faq answer);
        bool UpdateQuestion(int id, Faq question);
        bool UpdateAnswer(int id, Faq answer);
        bool DeleteQuestion(int id);
        bool DeleteAnswer(int id);
    }
}
