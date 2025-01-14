namespace Project.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public CategoryRepository CategoryRepository { get; }
        public ProductRepository ProductRepository { get; }
        public CartRepository CartRepository { get; }

        Task<bool> SaveAsync();
    }
}
