namespace YumBlazor.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public CategoryRepository CategoryRepository { get; }
        public ProductRepository ProductRepository { get; }

        Task<bool> SaveAsync();
    }
}
