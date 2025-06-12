using MissionBackend.Models;

namespace MissionBackend.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
