using MissionBackend.Data;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace MissionBackend.Repositories
{
    public class MissionThemeRepository: IMissionThemeRepository
    {
        private readonly AppDbContext _context;

        public MissionThemeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddMissionTheme(MissionThemeDto mission)
        {
            var newmission= new MissionTheme
            {
                ThemeName = mission.ThemeName,
                Status = mission.Status,
                Action="add",
            };
            _context.MissionTheme.Add(newmission);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMissionTheme(int id)
        {
            var MissionExists = await _context.MissionTheme.FindAsync(id);
            if (MissionExists == null) return false;

            _context.MissionTheme.Remove(MissionExists);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<MissionThemeDto> GetMissionThemeById(int id)
        {
            var mission = await _context.MissionTheme.FindAsync(id);
            if (mission == null) return null;
            var getmission = new MissionThemeDto
            {
                Id=mission.Id,
                ThemeName = mission.ThemeName,
                Status=mission.Status,
            };
            return (getmission);
        }

        public async Task<List<MissionThemeDto>> GetAllMissionTheme()
        {
            var missions=await _context.MissionTheme.Select(m => new MissionThemeDto
            {
                Id=m.Id,
                ThemeName = m.ThemeName,
                Status=m.Status,
            }).ToListAsync();
            return missions;

        }

        public async Task<bool> UpdateMissionTheme(MissionThemeDto mission)
        {

            var missionexists = await _context.MissionTheme.FindAsync(mission.Id);
            if (missionexists == null) return false;

            missionexists.ThemeName = mission.ThemeName;
            missionexists.Status = mission.Status;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
