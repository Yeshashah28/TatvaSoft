using MissionBackend.Data;
using MissionBackend.Dto;
using Microsoft.EntityFrameworkCore;
using MissionBackend.Interfaces;

namespace MissionBackend.Repositories
{
    public class MissionApplicationRepository:IMissionApplicationRepository
    {
        private readonly AppDbContext _context;
        public MissionApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MissionApplicationDto>> MissionApplicationList()
        {
            var missionapplications= await _context.MissionApplications.Select(ma=>new MissionApplicationDto{
                Id=ma.Id,
                MissionTitle=ma.Mission.MissionTitle,
                MissionTheme=ma.Mission.MissionTheme.ThemeName,
                UserName=ma.User.Firstname,
                AppliedDate=ma.AppliedDate,
                Status=ma.Status,
            }).ToListAsync();

            return missionapplications;
        }

        public async Task<MissionApplicationDto> MissionApplicationApprove(int id)
        {
            var missionapplication = await _context.MissionApplications.Include(z => z.Mission).Include(x=>x.Mission.MissionTheme).Include(y=>y.User).FirstOrDefaultAsync(ma=>ma.Id==id);
            if (missionapplication == null)
            {
                return null;
            }
            missionapplication.Status = true;
            _context.MissionApplications.Update(missionapplication);
            await _context.SaveChangesAsync();

            var approvedmission = new MissionApplicationDto()
            {
                Id=missionapplication.Id,
                MissionTitle = missionapplication.Mission.MissionTitle,
                MissionTheme=missionapplication.Mission.MissionTheme.ThemeName,
                UserName=missionapplication.User.Firstname,
                AppliedDate=missionapplication.AppliedDate,
                Status=true,
            };
            return approvedmission;
        }

        public async Task<bool> MissionApplicationDelete(int id)
        {
            var missionexists = await _context.MissionApplications.FindAsync(id);
            if (missionexists == null)
            {
                return false;
            }
            _context.MissionApplications.Remove(missionexists);
            var mission = await _context.Mission.FindAsync(missionexists.MissionId);
            mission.TotalSheets++;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
