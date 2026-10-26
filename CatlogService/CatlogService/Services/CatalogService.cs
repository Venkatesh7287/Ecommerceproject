using CatalogService.Model;
using CatalogService.Repository;

namespace CatalogService.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync() => await _catalogRepository.GetAllAsync();
        public async Task<Product?> GetProductByIdAsync(int id) => await _catalogRepository.GetProductIdAsync(id);
        public async Task AddProductAsync(Product product) => await _catalogRepository.AddAsync(product);
        public async Task UpdateProductAsync(Product product) => await _catalogRepository.UpdateAsync(product);
        public async Task DeleteProductAsync(int id) => await _catalogRepository.DeleteAsync(id);
    }
}
