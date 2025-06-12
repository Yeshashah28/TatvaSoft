using MissionBackend.Data;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace MissionBackend.Services
{
    public class MissionThemeServices: IMissionThemeServices
    {
        private readonly AppDbContext _context;
        private readonly IMissionThemeRepository _repo;

        public MissionThemeServices(AppDbContext context, IMissionThemeRepository repo)
        {
            _context = context;
            _repo = repo;
        }
       
        public async Task<bool> AddMissionTheme(MissionThemeDto mission)
        {
            var missionexists = await _context.MissionTheme.FirstOrDefaultAsync(u => u.ThemeName==mission.ThemeName);
            if (missionexists != null)
            {
                return false;
            }
            return await _repo.AddMissionTheme(mission);
        }

        public async Task<bool> DeleteMissionTheme(int id) => await _repo.DeleteMissionTheme(id);

        public async Task<MissionThemeDto> GetMissionThemeById(int id) => await _repo.GetMissionThemeById(id);
        public async Task<List<MissionThemeDto>> GetAllMissionTheme() => await _repo.GetAllMissionTheme();

        public async Task<bool> UpdateMissionTheme(MissionThemeDto mission)
        {
            var missionexists = await _repo.GetMissionThemeById(mission.Id);
            if (missionexists == null) return false;
            return await _repo.UpdateMissionTheme(mission);
        }
    }
}

