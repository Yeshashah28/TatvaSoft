using MissionBackend.Dto;

namespace MissionBackend.Interfaces
{
    public interface IMissionApplicationRepository
    {
        //Task<ApplyMissionRequest> GetMissionApplicationById(int id);
        Task<List<MissionApplicationDto>> MissionApplicationList();
        Task<MissionApplicationDto> MissionApplicationApprove(int id);
        Task<bool> MissionApplicationDelete(int id);
    }
}
