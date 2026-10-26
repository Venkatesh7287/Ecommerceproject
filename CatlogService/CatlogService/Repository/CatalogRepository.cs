using CatalogService.Data;
using CatalogService.Model;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Repository
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly CatalogDBContext _catalogDBContext;
        public CatalogRepository(CatalogDBContext context)
        {
            _catalogDBContext = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _catalogDBContext.products.ToListAsync();
        }

        public async Task<Product?> GetProductIdAsync(int id)
        {
            return await _catalogDBContext.products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _catalogDBContext.products.AddAsync(product);
            await _catalogDBContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
             _catalogDBContext.products.Update(product);
            await _catalogDBContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _catalogDBContext.products.FindAsync(id);
            if (product != null)
            {
                _catalogDBContext.products.Remove(product);

                await _catalogDBContext.SaveChangesAsync();
            }
        }
    }
}
