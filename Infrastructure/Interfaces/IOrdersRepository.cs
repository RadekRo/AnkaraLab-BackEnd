using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order?> GetOrderAsync(int id);
        void CreateOrder(Order order);
        bool UpdateOrder(Order order);
        Task<bool> DeleteOrderAsync(int id);
        IEnumerable<Order> GetPaymentMethod();
        IEnumerable<Order> GetPaymentStatus();
    }
}
