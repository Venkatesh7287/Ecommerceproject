using UserService.Model;

namespace UserService.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        //Task<IEnumerable<User>> GetByUserIdAsync(string userId);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
         
    }
}
