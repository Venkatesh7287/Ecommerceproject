using Microsoft.EntityFrameworkCore;
using UserService.Model;

namespace UserService.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
        public DbSet<Address> addresses { get; set; }
    }
}
