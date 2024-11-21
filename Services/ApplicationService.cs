using YumBlazor.Repository.IRepository;
using YumBlazor.Services.IServices;

namespace YumBlazor.Services
{
    public class ApplicationService: IApplicationService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CategoryService CategoryService => new(_unitOfWork);
        public ProductService ProductService => new(_unitOfWork);
    }
}
