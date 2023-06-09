using AutoMapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public UserRepository(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersAsync()
        {
            var users = await userManager.Users.ToListAsync();
            return users;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsersByRoleAsync(string role)
        {
            var users = await userManager.GetUsersInRoleAsync(role);
            return users;
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user == null)
                return false;

            var result = await userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
