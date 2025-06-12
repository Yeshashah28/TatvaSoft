using Microsoft.EntityFrameworkCore;
using MissionBackend.Data;
using MissionBackend.Dto;
using MissionBackend.Interfaces;
using MissionBackend.Models;
using System.Reflection;

namespace MissionBackend.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private readonly AppDbContext _context;

        public MissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MissionDto> GetMissionById(Mission existingmission)
        {
            var mission = new MissionDto
            {
                Id = existingmission.Id,
                CountryId = existingmission.CountryId,
                CityId = existingmission.CityId,
                MissionTitle = existingmission.MissionTitle,
                MissionDescription = existingmission.MissionDescription,
                MissionThemeId = existingmission.MissionThemeId,
                MissionSkillId = existingmission.MissionSkillId,
                MissionImages = existingmission.MissionImages,
                StartDate = existingmission.StartDate,
                EndDate = existingmission.EndDate,
                TotalSeats = existingmission.TotalSheets ?? 0
            };
            return mission;
        }

        public async Task<List<MissionDto>> GetAllMission()
        {
            try
            {
                var mission = await (from m in _context.Mission
                                     join mt in _context.MissionTheme on m.MissionThemeId equals mt.Id
                                     select new MissionDto
                                     {
                                         Id = m.Id,
                                         CountryId = m.CountryId,
                                         CityId = m.CityId,
                                         MissionTitle = m.MissionTitle,
                                         MissionDescription = m.MissionDescription,
                                         MissionThemeId = m.MissionThemeId,
                                         MissionSkillId = m.MissionSkillId,
                                         MissionImages = m.MissionImages,
                                         StartDate = m.StartDate,
                                         EndDate = m.EndDate,
                                         TotalSeats = m.TotalSheets ?? 0,
                                         MissionThemeName = m.MissionTheme.ThemeName
                                     }).ToListAsync();
                return mission;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> AddMission(MissionDto mission)
        {
            try
            {

                var newmission = new Mission
                {
                    Id = mission.Id,
                    CountryId = mission.CountryId,
                    CityId = mission.CityId,
                    MissionTitle = mission.MissionTitle,
                    MissionDescription = mission.MissionDescription,
                    MissionThemeId = mission.MissionThemeId,
                    MissionSkillId = mission.MissionSkillId,
                    MissionImages = mission.MissionImages,
                    StartDate = mission.StartDate,
                    EndDate = mission.EndDate,
                    TotalSheets = mission.TotalSeats,
                };
                _context.Mission.Add(newmission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> UpdateMission(MissionDto mission)
        {

            var missionexists = await _context.Mission.FindAsync(mission.Id);
            if (missionexists == null) return false;

            missionexists.CountryId = mission.CountryId;
            missionexists.CityId = mission.CityId;
            missionexists.MissionImages = mission.MissionImages;
            missionexists.MissionDescription = mission.MissionDescription;
            missionexists.MissionTitle = mission.MissionTitle;
            missionexists.MissionThemeId = mission.MissionThemeId;
            missionexists.MissionSkillId = mission.MissionSkillId;
            missionexists.StartDate = mission.StartDate;
            missionexists.EndDate = mission.EndDate;
            missionexists.TotalSheets = mission.TotalSeats;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteMission(int id)
        {
            var MissionExists = await _context.Mission.FindAsync(id);
            if (MissionExists == null) return false;

            _context.Mission.Remove(MissionExists);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<ClientSideMissionDto>> GetClientSideMissionList(int userid)
        {
            var dateToCompare = DateTime.Now.Date.AddDays(-1);
            return await _context.Mission
                .Select(m => new ClientSideMissionDto()
                {
                    Id = m.Id,
                    MissionTitle = m.MissionTitle,
                    MissionDescription = m.MissionDescription,
                    CountryId = m.CountryId,
                    CityId = m.CityId,
                    StartDate = m.StartDate,
                    EndDate = m.EndDate,
                    TotalSheets = m.TotalSheets,
                    RegistrationDeadLine = m.RegistrationDeadLine,
                    MissionThemeId = m.MissionThemeId,
                    MissionSkillId = m.MissionSkillId,
                    MissionImages =m.MissionImages,
                    CountryName = m.Country.CountryName,
                    CityName = m.City.CityName,
                    MissionThemeName = m.MissionTheme.ThemeName,
                    MissionSkillName = string.Join(",", _context.MissionSkill
                        .Where(ms => m.MissionSkillId.Contains(ms.Id.ToString()))
                        .Select(ms => ms.SkillName)
                        .ToList()),
                    MissionStatus = m.RegistrationDeadLine < dateToCompare ? "Closed" : "Available",
                    MissionApplyStatus = _context.MissionApplications.Any(ma=>ma.MissionId==m.Id && ma.UserId==userid)?"Applied":"Apply",
                    MissionApproveStatus = _context.MissionApplications.Any(ma => ma.MissionId == m.Id && ma.UserId == userid && ma.Status) ? "Approved" : "Applied",
                    MissionDateStatus = m.EndDate <= dateToCompare ? "MissionEnd" : "MissionRunning",
                    MissionDeadLineStatus = m.RegistrationDeadLine <= dateToCompare ? "Closed" : "Running",
                    //MissionFavouriteStatus = m.MissionFavourites.Any(mf => mf.UserId == userId) ? "1" : "0",
                    //Rating = m.MissionRatings.Where(mr => mr.UserId == userId).Select(mr => mr.Rating).FirstOrDefault() ?? 0,
                }).ToListAsync();
        }

        public async Task<bool> ApplyMission(ApplyMissionRequest mission)
        {
            var missionexists = await _context.Mission.FindAsync(mission.MissionId);
            if (missionexists == null)
            {
                return false;
            }
            if (missionexists.TotalSheets == 0)
            {
                return false;
            }

            var newapplication = new MissionApplication()
            {
                MissionId=mission.MissionId,
                UserId=mission.UserId,
                AppliedDate=mission.AppliedDate
            };

            _context.MissionApplications.Add(newapplication);
            missionexists.TotalSheets--;
            await _context.SaveChangesAsync();
            return true;
        }

        
    }
}
