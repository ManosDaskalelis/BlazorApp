using Project.Data;
using Project.Repository.IRepository;

namespace Project.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UnitOfWork(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public CategoryRepository CategoryRepository => new(_context);
        public ProductRepository ProductRepository => new(_context, _webHostEnvironment);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
