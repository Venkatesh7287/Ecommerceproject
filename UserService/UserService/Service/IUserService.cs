using UserService.Model;

namespace UserService.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
      //  Task<IEnumerable<User>> GetUserByUserIdAsync(string userId);
        Task<User> AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);

    }
}
