using MissionBackend.Models;

namespace MissionBackend.Interfaces
{
    public interface IAuthRepository
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
