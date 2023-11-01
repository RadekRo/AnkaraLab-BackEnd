using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure
{
    public interface IOrdersRepository
    {
        IEnumerable<Order> GetOrders();
        void CreateOrder(Order order);
    }
}
