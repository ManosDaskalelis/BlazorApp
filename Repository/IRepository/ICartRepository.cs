using Project.Data;

namespace Project.Repository.IRepository
{
    public interface ICartRepository
    {
        public Task<bool> UpdateCartAsync(string userId, int product, int updateBy);
        public Task<IEnumerable<Cart>> GetAllAsync(string? userId);
        public Task<bool> ClearCartAsync(string? userId);
        public Task<int> GetTotalCountAsync(string? userId);
    }
}
