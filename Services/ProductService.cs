using Project.Data;
using Project.Repository.IRepository;
using Project.Services.IServices;

namespace Project.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> Create(Product prod)
        {
            var productToReturn = await _unitOfWork.ProductRepository.Create(prod);
            await _unitOfWork.SaveAsync();
            return productToReturn;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _unitOfWork.ProductRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _unitOfWork.ProductRepository.GetAll();
        }

        public async Task<Product> GetById(int id)
        {
            return await _unitOfWork.ProductRepository.GetById(id);
            
        }

        public async Task<Product> Update(Product prod)
        {
            var prodToUpdate = await _unitOfWork.ProductRepository.Update(prod);
            await _unitOfWork.SaveAsync();
            return prodToUpdate;
        }
    }
}
