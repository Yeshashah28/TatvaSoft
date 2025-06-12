using MissionBackend.Dto;

namespace MissionBackend.Interfaces
{
    public interface IMissionSkillRepository
    {
        Task<MissionSkillDto> GetMissionSkillById(int id);
        Task<List<MissionSkillDto>> GetAllMissionSkill();
        Task<bool> AddMissionSkill(MissionSkillDto Mission);
        Task<bool> UpdateMissionSkill(MissionSkillDto Mission);
        Task<bool> DeleteMissionSkill(int id);
    }
}
