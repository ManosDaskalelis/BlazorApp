using Project.Data;

namespace Project.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<Product> Create(Product prod);
        public Task<Product> Update(Product prod);
        public Task<Product> GetById(int id);
        public Task<IEnumerable<Product>> GetAll();
        public Task<bool> DeleteAsync(int id);
    }
}
