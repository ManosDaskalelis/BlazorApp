using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Repository.IRepository;

namespace Project.Repository
{
    public class CartRepository : ICartRepository
    {
        private ApplicationDbContext _dbContext;

        public CartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> UpdateCartAsync(string userId, int productId, int updateBy)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return false;
            }

            var cart = await _dbContext.Cart.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    ProductId = productId,
                    Count = updateBy
                };

                await _dbContext.Cart.AddAsync(cart);
            }
            else
            {
                cart.Count += updateBy;
                if (cart.Count <= 0)
                {
                    _dbContext.Cart.Remove(cart);
                }
            }

            return await _dbContext.SaveChangesAsync() > 0;
        }


        public async Task<IEnumerable<Cart>> GetAllAsync(string? userId)
        {
            return await _dbContext.Cart.Where(u => u.UserId == userId).Include(u => u.Product).ToListAsync();
        }

        public async Task<int> GetTotalCountAsync(string? userId)
        {
            int cartCount = 0;
            var cartItems = await _dbContext.Cart.Where(u => u.UserId == userId).ToListAsync();

            foreach (var item in cartItems)
            {
                cartCount += item.Count;
            }
            return cartCount;
        }

        public async Task<bool> ClearCartAsync(string? userId)
        {
            var cart = await _dbContext.Cart.Where(u => u.UserId == userId).ToListAsync();
            _dbContext.Cart.RemoveRange(cart);
            return await _dbContext.SaveChangesAsync() > 0;
        }

    }
}
