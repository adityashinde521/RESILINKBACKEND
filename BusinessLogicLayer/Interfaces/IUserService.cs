using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(string id);
        Task<IEnumerable<UserDto>> GetUsersByRoleAsync(string role);
        Task<bool> DeleteUserAsync(string id);
    }
}
