using MissionBackend.Data;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace MissionBackend.Repositories
{
    public class MissionSkillRepository : IMissionSkillRepository
    {
        private readonly AppDbContext _context;

        public MissionSkillRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMissionSkill(MissionSkillDto mission)
        {
            var newmission = new MissionSkill
            {
                SkillName = mission.SkillName,
                Status = mission.Status,
                Action = "add",
            };
            _context.MissionSkill.Add(newmission);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMissionSkill(int id)
        {
            var MissionExists = await _context.MissionSkill.FindAsync(id);
            if (MissionExists == null) return false;

            _context.MissionSkill.Remove(MissionExists);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<MissionSkillDto> GetMissionSkillById(int id)
        {
            var mission = await _context.MissionSkill.FindAsync(id);
            if (mission == null) return null;
            var getmission = new MissionSkillDto
            {
                Id = mission.Id,
                SkillName = mission.SkillName,
                Status = mission.Status,
            };
            return (getmission);
        }

        public async Task<List<MissionSkillDto>> GetAllMissionSkill()
        {
            var missions = await _context.MissionSkill.Select(m => new MissionSkillDto
            {
                Id = m.Id,
                SkillName = m.SkillName,
                Status = m.Status,
            }).ToListAsync();
            return missions;

        }

        public async Task<bool> UpdateMissionSkill(MissionSkillDto mission)
        {

            var missionexists = await _context.MissionSkill.FindAsync(mission.Id);
            if (missionexists == null) return false;

            missionexists.SkillName = mission.SkillName;
            missionexists.Status = mission.Status;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
