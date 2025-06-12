using MissionBackend.Data;
using MissionBackend.Dto;
using MissionBackend.Interfaces;

namespace MissionBackend.Services
{
    public class MissionApplicationService:IMissionApplicationService
    {
        private readonly AppDbContext _context;
        private readonly IMissionApplicationRepository _repo;

        public MissionApplicationService(AppDbContext context, IMissionApplicationRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        public async Task<List<MissionApplicationDto>> MissionApplicationList()
        {
            return await _repo.MissionApplicationList();
        }

        public async Task<MissionApplicationDto> MissionApplicationApprove(int id)
        {
            return await _repo.MissionApplicationApprove(id);
        }

        public async Task<bool> MissionApplicationDelete(int id)
        {
            return await _repo.MissionApplicationDelete(id);
        }
    }
}
