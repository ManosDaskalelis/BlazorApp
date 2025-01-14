namespace Project.Repository.IRepository
{
    public interface ICartRepository
    {
        public Task<bool> UpdateCartAsync(string userId, int product, int updatedBy)
    }
}
