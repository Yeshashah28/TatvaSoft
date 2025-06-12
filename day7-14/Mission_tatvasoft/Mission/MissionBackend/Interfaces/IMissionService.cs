using MissionBackend.Dto;
using MissionBackend.Models;

namespace MissionBackend.Interfaces
{
    public interface IMissionService
    {
        Task<MissionDto> GetMissionById(int id);
        Task<List<MissionDto>> GetAllMission();
        Task<bool> AddMission(MissionDto Mission);

        Task<bool> UpdateMission(MissionDto Mission);

        Task<bool> DeleteMission(int id);

        Task<bool> ApplyMission(ApplyMissionRequest mission);

        Task<List<ClientSideMissionDto>> GetClientSideMissionList(int userid);
    }
}
