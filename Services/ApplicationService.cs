using Project.Repository.IRepository;
using Project.Services.IServices;

namespace Project.Services
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
