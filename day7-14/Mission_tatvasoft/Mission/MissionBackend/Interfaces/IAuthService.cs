using MissionBackend.Dto;
using MissionBackend.Models;

namespace MissionBackend.Interfaces
{
    public interface IAuthService
    {
        Task<User> AuthenticateAsync(string email, string password);
        Task<RegisterDto> RegisterAsync(RegisterDto user);

    }
}
