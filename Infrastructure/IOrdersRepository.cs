using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> GetOrders();

        Order? GetOrder(int id);
        void CreateOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(int id);
        IEnumerable<Order> GetPaymentMethod();
        IEnumerable<Order> GetPaymentStatus();
    }
}
