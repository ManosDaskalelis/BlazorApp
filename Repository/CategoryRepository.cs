using Microsoft.EntityFrameworkCore;
using YumBlazor.Data;
using YumBlazor.Repository.IRepository;

namespace YumBlazor.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> Create(Category cat)
        {
            var catToReturn = await _dbContext.AddAsync(cat);
            return catToReturn.Entity;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _dbContext.Category.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _dbContext.Category.Remove(obj);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext.Category.ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            var catToReturn = await _dbContext.Category.FirstOrDefaultAsync(c => c.Id == id);
            if (catToReturn == null)
            {
                return new Category();
            }
            return catToReturn;
        }

        public async Task<Category> Update(Category cat)
        {
            var entityToUpdate = await _dbContext.Category.FirstOrDefaultAsync(x => x.Id == cat.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.Name = cat.Name;
                _dbContext.Category.Update(entityToUpdate);
                return entityToUpdate;
            }
            return new Category();
        }
    }
}