using AnkaraLab_BackEnd.WebAPI.Domain;

namespace AnkaraLab_BackEnd.WebAPI.Infrastructure
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly AnkaraLabDbContext _dbContext;
        public OrdersRepository(AnkaraLabDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public void CreateOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
        public Order? GetOrder(int id)
        {
            return _dbContext.Orders.SingleOrDefault(o => o.Id == id);
        }
        public bool DeleteOrder(int id)
        {
            var order = _dbContext.Orders.SingleOrDefault(o => o.Id == id);

            if (order is null)
            {
                return false;
            }
            _dbContext.Orders.Remove(order);
            _dbContext.SaveChanges();

            return true;
        }
        public bool UpdateOrder(Order order)
        {
            var orderFromDb = _dbContext.Orders.SingleOrDefault(o => o.Id == order.Id);

            if (orderFromDb is null)
            {
                return false;
            }
            orderFromDb.DeliveryAddress = order.DeliveryAddress;
            orderFromDb.InvoiceAddress = order.InvoiceAddress;
            orderFromDb.PaymentMethod = order.PaymentMethod;
            orderFromDb.PaymentStatus = order.PaymentStatus;
            
            _dbContext.SaveChanges();
            return true;
        }
        public IEnumerable<Order> GetOrders()
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
    }
}
