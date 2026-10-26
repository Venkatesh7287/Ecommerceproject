using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Model;

namespace UserService.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userDbContext;

        public UserRepository(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userDbContext.users.ToListAsync();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            return await _userDbContext.users.Include(o => o.Addresses).FirstOrDefaultAsync(o => o.Id == id);
        }
        public async Task AddAsync(User user)
        {
            await _userDbContext.users.AddAsync(user);
            await _userDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(User user)
        {
            var existinguser = _userDbContext.users.Update(user);
            if(existinguser != null)
            {
                await _userDbContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
           var user = await _userDbContext.users.FindAsync(id);
            if(user != null)
            {
                _userDbContext.users.Remove(user);
                await _userDbContext.SaveChangesAsync();
            }
        }
    }
}
 