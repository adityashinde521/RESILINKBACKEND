using AutoMapper;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await userRepository.GetUsersAsync();
            var userDtoList = mapper.Map<IEnumerable<UserDto>>(users);
            return userDtoList;
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            var userDto = mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<IEnumerable<UserDto>> GetUsersByRoleAsync(string role)
        {
            var users = await userRepository.GetUsersByRoleAsync(role);
            var userDtoList = mapper.Map<IEnumerable<UserDto>>(users);
            return userDtoList;
        }

        public Task<bool> DeleteUserAsync(string id)
        {
            return userRepository.DeleteUserAsync(id);
        }
    }
}
