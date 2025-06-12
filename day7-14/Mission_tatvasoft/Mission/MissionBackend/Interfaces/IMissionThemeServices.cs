using MissionBackend.Dto;
using MissionBackend.Models;

namespace MissionBackend.Interfaces
{
    public interface IMissionThemeServices
    {
        Task<MissionThemeDto> GetMissionThemeById(int id);
        Task<List<MissionThemeDto>> GetAllMissionTheme();
        Task<bool> AddMissionTheme(MissionThemeDto Mission);
        Task<bool> UpdateMissionTheme(MissionThemeDto Mission);
        Task<bool> DeleteMissionTheme(int id);
    }
}
