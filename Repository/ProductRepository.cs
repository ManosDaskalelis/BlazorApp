using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Create(Product prod)
        {
            var prodToReturn = await _dbContext.AddAsync(prod);
            return prodToReturn.Entity;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _dbContext.Product.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _dbContext.Product.Remove(obj);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _dbContext.Product.Include(x => x.Category).ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
            var prodToReturn = await _dbContext.Product.FirstOrDefaultAsync(c => c.Id == id);
            if (prodToReturn == null)
            {
                return new Product();
            }
            return prodToReturn;
        }

        public async Task<Product> Update(Product prod)
        {
            var entityToUpdate = await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == prod.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.Name = prod.Name;
                _dbContext.Product.Update(entityToUpdate);
                return entityToUpdate;
            }
            return new Product();
        }
    }
}
