using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Repository.IRepository;
using System.Net;

namespace Project.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OrderHeader> CreateOrderAsync(OrderHeader order)
        {
            order.OrderDate = DateTime.Now;
            await _dbContext.OrderHeader.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<OrderHeader>> GetAllOrdersAsync(string? userId = null)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                return await _dbContext.OrderHeader.Where(u => u.UserId == userId).ToListAsync();
            }
            else
            {
                return await _dbContext.OrderHeader.ToListAsync();
            }
        }

        public async Task<OrderHeader> GetOrderAsync(int id)
        {
            return await _dbContext.OrderHeader.Include(o => o.OrderDetails).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<OrderHeader> UpdateStatusAsync(int orderId, string status)
        {
            var orderHeader = _dbContext.OrderHeader.FirstOrDefault(u => u.Id == orderId);
            if (orderHeader != null)
            {
                orderHeader.Status = status;
                await _dbContext.SaveChangesAsync();
            }
            return orderHeader;
        }
    }
}
