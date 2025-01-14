using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Repository.IRepository;

namespace Project.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category obj)
        {
            await _dbContext.Category.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _dbContext.Category.FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                _dbContext.Category.Remove(obj);
                return (await _dbContext.SaveChangesAsync()) > 0;
            }
            return false;
        }

        public async Task<Category> GetAsync(int id)
        {
            var obj = await _dbContext.Category.FirstOrDefaultAsync(u => u.Id == id);
            if (obj == null)
            {
                return new Category();
            }
            return obj;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Category.ToListAsync();
        }

        public async Task<Category> UpdateAsync(Category obj)
        {
            var objFromDb = await _dbContext.Category.FirstOrDefaultAsync(u => u.Id == obj.Id);
            if (objFromDb is not null)
            {
                objFromDb.Name = obj.Name;
                _dbContext.Category.Update(objFromDb);
                await _dbContext.SaveChangesAsync();
                return objFromDb;
            }
            return obj;
        }
    }
}