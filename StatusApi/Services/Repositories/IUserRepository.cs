using StatusApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace StatusApi.Services.Repositories
{
    
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(UserCreateDto user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }

}