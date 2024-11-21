using YumBlazor.Data;

namespace YumBlazor.Services.IServices
{
    public interface IProductService
    {
        public Task<Product> Create(Product prod);
        public Task<Product> Update(Product prod);
        public Task<Product> GetById(int id);
        public Task<IEnumerable<Product>> GetAll();
        public Task<bool> DeleteAsync(int id);
    }
}
