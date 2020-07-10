using System.Linq;

namespace SportStore.Models
{
    public interface IOrderRepository
    {
        public IQueryable<Order> Orders { get; }
        public Order GetOrderById(int orderId);
        public void SaveOrder(Order order);
    }
}
