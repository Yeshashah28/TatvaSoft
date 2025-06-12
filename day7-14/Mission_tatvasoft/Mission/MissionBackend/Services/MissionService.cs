using Microsoft.EntityFrameworkCore;
using MissionBackend.Data;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;
using MissionBackend.Repositories;

namespace MissionBackend.Services
{
    public class MissionService:IMissionService
    {
        private readonly AppDbContext _context;
        private readonly IMissionRepository _repo;

        public MissionService(AppDbContext context, IMissionRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        public async Task<MissionDto> GetMissionById(int id)
        {
            var existingmission = await _context.Mission.FirstOrDefaultAsync(m => m.Id == id);
            if (existingmission == null)
            {
                return null;
            }
            return await _repo.GetMissionById(existingmission);
        }

        public async Task<List<MissionDto>> GetAllMission()
        {
            return await _repo.GetAllMission();
        }

        public async Task<bool> AddMission(MissionDto mission)
        {
            var missionexists = await _context.Mission.FirstOrDefaultAsync(m => m.Id == mission.Id);
            if (missionexists != null)
            {
                return false;
            }
            return await _repo.AddMission(mission);
        }

        public async Task<bool> UpdateMission(MissionDto mission)
        {
            return await _repo.UpdateMission(mission);
        }

        public async Task<bool> DeleteMission(int id)
        {
            return await _repo.DeleteMission(id);
        }

        public async Task<List<ClientSideMissionDto>> GetClientSideMissionList(int userid)
        {
            return await _repo.GetClientSideMissionList(userid);
        }

        public async Task<bool> ApplyMission(ApplyMissionRequest mission)
        {
            return await _repo.ApplyMission(mission);
        }
    }
}
