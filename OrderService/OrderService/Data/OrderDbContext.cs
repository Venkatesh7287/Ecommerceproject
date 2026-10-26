using Microsoft.EntityFrameworkCore;
using OrderService.Model;

namespace OrderService.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItem { get; set; }
    }
}
