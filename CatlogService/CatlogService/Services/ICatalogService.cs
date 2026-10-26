using CatalogService.Model;

namespace CatalogService.Services
{
    public interface ICatalogService
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
