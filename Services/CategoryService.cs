using Microsoft.VisualBasic;
using YumBlazor.Data;
using YumBlazor.DTO;
using YumBlazor.Repository.IRepository;
using YumBlazor.Services.IServices;

namespace YumBlazor.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CategoryReadOnlyDTO> Create(CategoryInsertDTO cat)
        {
            var category = new Category
            {
                Name = cat.Name
            };
            await _unitOfWork.CategoryRepository.Create(category);
            await _unitOfWork.SaveAsync();

            var categoryToReturn = new CategoryReadOnlyDTO
            {
                Id = category.Id,
                Name = category.Name,
            };
            return categoryToReturn;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await _unitOfWork.CategoryRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<CategoryReadOnlyDTO>> GetAll()
        {

            var response = new List<CategoryReadOnlyDTO>();
            var categories = await _unitOfWork.CategoryRepository.GetAll();
            foreach (var category in categories)
            {
                response.Add(new CategoryReadOnlyDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                });
            }
            return response;
        }

        public async Task<CategoryReadOnlyDTO> GetById(int id)
        {
            var category = await _unitOfWork.CategoryRepository.GetById(id);
            var categoryToReturn = new CategoryReadOnlyDTO
            {
                Id = category.Id,
                Name = category.Name,
            };
            return categoryToReturn;
        }

        public async Task<CategoryReadOnlyDTO> Update(CategoryUpdateDTO cat)
        {
            var categoryToUpdate = new Category
            {
                Id = cat.Id,
                Name = cat.Name,
            };
            var category = await _unitOfWork.CategoryRepository.GetById(categoryToUpdate.Id);

            await _unitOfWork.CategoryRepository.Update(categoryToUpdate);

            var categoryToReturn = new CategoryReadOnlyDTO
            {
                Id = categoryToUpdate.Id,
                Name = categoryToUpdate.Name,
            };
            await _unitOfWork.SaveAsync();
            return categoryToReturn;
        }
    }
}
