using Project.Models;

namespace Project.Repository.IRepository
{
    public interface IOrderRepository
    {
        public Task<OrderHeader> CreateOrderAsync(OrderHeader order);
        public Task<OrderHeader> GetOrderAsync(int id);
        public Task<IEnumerable<OrderHeader>> GetAllOrdersAsync(string? userId = null );
        public Task<OrderHeader> UpdateStatusAsync(int orderId, string status);
    }
}
