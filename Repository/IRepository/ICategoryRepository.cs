using Project.Models;

namespace Project.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateAsync(Category cat);
        public Task<Category> UpdateAsync(Category cat);
        public Task<Category> GetAsync(int id);
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<bool> DeleteAsync(int id);
    }
}
