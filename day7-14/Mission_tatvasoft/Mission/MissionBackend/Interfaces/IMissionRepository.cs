using MissionBackend.Dto;
using MissionBackend.Models;

namespace MissionBackend.Interfaces
{
    public interface IMissionRepository
    {
        Task<MissionDto> GetMissionById(Mission mission);
        Task<List<MissionDto>> GetAllMission();
        Task<bool> AddMission(MissionDto mission);
        Task<bool> UpdateMission(MissionDto Mission);
        Task<bool> DeleteMission(int id);

        Task<List<ClientSideMissionDto>> GetClientSideMissionList(int userid);

        Task<bool> ApplyMission(ApplyMissionRequest mission);
    }
}
