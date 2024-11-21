using YumBlazor.Data;

namespace YumBlazor.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<Category> Create(Category cat);
        public Task<Category> Update(Category cat);
        public Task<Category> GetById(int id);
        public Task<IEnumerable<Category>> GetAll();
        public Task<bool> DeleteAsync(int id);
    }
}
