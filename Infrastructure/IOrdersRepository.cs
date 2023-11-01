using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> GetOrders();

        Order? GetOrder(int orderId);
        void CreateOrder(Order order);
        bool UpdateOrder(Order order);
        bool DeleteOrder(int orderId);
        IEnumerable<Order> GetPaymentMethod();
        IEnumerable<Order> GetPaymentStatus();
    }
}
