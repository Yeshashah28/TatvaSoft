using MissionBackend.Dto;
using MissionBackend.Models;

namespace MissionBackend.Interfaces
{
    public interface IUserService
    {

        Task<UserDto> GetByIdAsync(int id);
        Task<List<UserDto>> GetAllAsync();
        //Task<UserDto> CreateAsync(UserDto user);
        Task<bool> UpdateAsync(int id, UserDto user);
        Task<bool> DeleteAsync(int id);

        Task<User> AuthenticateAsync(string email, string password);


    }

}
