using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Repository.IRepository;

namespace Project.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductRepository(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            _dbContext = dbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Product> Create(Product prod)
        {
            var prodToReturn = await _dbContext.AddAsync(prod);
            await _dbContext.SaveChangesAsync();
            return prodToReturn.Entity;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var obj = await _dbContext.Product.FirstOrDefaultAsync(u => u.Id == id);

            if (obj == null)
            {
                return false;
            }

            if (!string.IsNullOrEmpty(obj.ImageUrl))
            {
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('/'));

                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }

            }
            _dbContext.Product.Remove(obj);
            await _dbContext.SaveChangesAsync();
            return true;

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
                entityToUpdate.ImageUrl = prod.ImageUrl;
                entityToUpdate.Price = prod.Price;
                entityToUpdate.SpecialTag = prod.SpecialTag;
                entityToUpdate.CategoryId = prod.CategoryId;
                _dbContext.Product.Update(entityToUpdate);
                await _dbContext.SaveChangesAsync();
                return entityToUpdate;
            }
            await _dbContext.SaveChangesAsync();
            return new Product();
        }
    }
}
