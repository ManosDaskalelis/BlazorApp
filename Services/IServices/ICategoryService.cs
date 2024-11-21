using YumBlazor.Data;
using YumBlazor.DTO;

namespace YumBlazor.Services.IServices
{
    public interface ICategoryService
    {
        public Task<CategoryReadOnlyDTO> Create(CategoryInsertDTO cat);
        public Task<CategoryReadOnlyDTO> Update(CategoryUpdateDTO cat);
        public Task<CategoryReadOnlyDTO> GetById(int id);
        public Task<IEnumerable<CategoryReadOnlyDTO>> GetAll();
        public Task<bool> DeleteAsync(int id);
    }
}
