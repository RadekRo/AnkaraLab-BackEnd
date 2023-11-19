using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure.Implementations
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        public OrdersRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task CreateOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<Order?> GetOrder(int id)
        {
            return await _dbContext.Orders.SingleOrDefaultAsync(o => o.Id == id);
        }
        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _dbContext.Orders.SingleOrDefaultAsync(o => o.Id == id);

            if (order is null)
            {
                return false;
            }
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateOrder(Order order)
        {
            var orderFromDb = await _dbContext.Orders.SingleOrDefaultAsync(o => o.Id == order.Id);

            if (orderFromDb is null)
            {
                return false;
            }
            orderFromDb.DeliveryAddress = order.DeliveryAddress;
            orderFromDb.InvoiceAddress = order.InvoiceAddress;
            orderFromDb.PaymentMethod = order.PaymentMethod;
            orderFromDb.PaymentStatus = order.PaymentStatus;

            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            var query = _dbContext.Orders.AsQueryable();

            return query.ToList();
        }
        IEnumerable<Order> IOrdersRepository.GetPaymentMethod()
        {
            return (IEnumerable<Order>)Enum.GetValues(typeof(PaymentMethodEnum.PaymentMethod)).Cast<PaymentMethodEnum.PaymentMethod>();
        }
        public IEnumerable<Order> GetPaymentStatus()
        {
            return (IEnumerable<Order>)Enum.GetValues(typeof(PaymentStatusEnum.PaymentStatus)).Cast<PaymentStatusEnum.PaymentStatus>();
        }

        public Task<IEnumerable<Order>> GetOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order?> GetOrderAsync(int id)
        {
            throw new NotImplementedException();
        }

        void IOrdersRepository.CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        bool IOrdersRepository.UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
