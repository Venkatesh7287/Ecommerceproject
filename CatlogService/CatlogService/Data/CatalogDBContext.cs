using CatalogService.Model;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data
{
    public class CatalogDBContext : DbContext
    {
        public CatalogDBContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Product> products { get; set; }
    }
}
