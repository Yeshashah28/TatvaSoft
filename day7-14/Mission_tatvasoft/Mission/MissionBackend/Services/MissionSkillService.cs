using MissionBackend.Data;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MissionBackend.Services
{
    public class MissionSkillService : IMissionSkillService
    {
        private readonly AppDbContext _context;
        private readonly IMissionSkillRepository _repo;

        public MissionSkillService(AppDbContext context, IMissionSkillRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        public async Task<bool> AddMissionSkill(MissionSkillDto mission)
        {
            var missionexists = await _context.MissionSkill.FirstOrDefaultAsync(u => u.SkillName == mission.SkillName);
            if (missionexists != null)
            {
                return false;
            }
            return await _repo.AddMissionSkill(mission);
        }

        public async Task<bool> DeleteMissionSkill(int id) => await _repo.DeleteMissionSkill(id);

        public async Task<MissionSkillDto> GetMissionSkillById(int id) => await _repo.GetMissionSkillById(id);
        public async Task<List<MissionSkillDto>> GetAllMissionSkill() => await _repo.GetAllMissionSkill();

        public async Task<bool> UpdateMissionSkill(MissionSkillDto mission)
        {
            var missionexists = await _repo.GetMissionSkillById(mission.Id);
            if (missionexists == null) return false;
            return await _repo.UpdateMissionSkill(mission);
        }
    }
}
