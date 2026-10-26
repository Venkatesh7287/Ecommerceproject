using CatalogService.Model;

namespace CatalogService.Repository
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetProductIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
    }
}
