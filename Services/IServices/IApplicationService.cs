namespace YumBlazor.Services.IServices
{
    public interface IApplicationService
    {
        CategoryService CategoryService { get; }
        ProductService ProductService { get; }
    }
}
