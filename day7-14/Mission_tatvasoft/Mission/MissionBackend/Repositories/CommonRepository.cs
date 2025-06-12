using MissionBackend.Data;
using MissionBackend.Dto;
using MissionBackend.Models;
using MissionBackend.Interfaces;

namespace MissionBackend.Repositories
{
    public class CommonRepository: ICommonRepository
    {
        private readonly AppDbContext _context;
        public CommonRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<DropDownResponseDto> CountryList()
        {
            var countries = _context.Country
                .OrderBy(c => c.CountryName)
                .Select(c => new DropDownResponseDto(c.Id, c.CountryName))
                .ToList();

            return countries;
        }

        public List<DropDownResponseDto> CityList(int countryId)
        {
            var cities = _context.City
                 .Where(c => c.CountryId == countryId)
                 .OrderBy(c => c.CityName)
                 .Select(c => new DropDownResponseDto(c.Id, c.CityName))
                 .ToList();

            return cities;
        }
     
        public List<DropDownResponseDto> MissionCountryList()
        {
            var missioncountries=_context.Mission
                .Select(m=>new DropDownResponseDto(m.CountryId,m.Country.CountryName))
                .Distinct()
                .ToList();

            return missioncountries;
        }

        public List<DropDownResponseDto> MissionCityList()
        {
            var missioncities = _context.Mission
                .Select(m => new DropDownResponseDto(m.CityId, m.City.CityName))
                .Distinct()
                .ToList();

            return missioncities;
        }

        public List<DropDownResponseDto> MissionThemeList()
        {
            var missionthemes= _context.MissionTheme
                .Where(m=>m.Status=="active")
                .Select(m => new DropDownResponseDto(m.Id, m.ThemeName))
                .Distinct()
                .ToList();

            return missionthemes;
        }

        public List<DropDownResponseDto> MissionSkillList()
        {
            var missionskills = _context.MissionSkill
                .Where(m => m.Status == "active")
                .Select(m => new DropDownResponseDto(m.Id, m.SkillName))
                .Distinct()
                .ToList();

            return missionskills;
        }

        public List<DropDownResponseDto> MissionTitleList()
        {
            var missions = _context.Mission
                .Select(m => new DropDownResponseDto(m.Id, m.MissionTitle))
                .ToList();

            return missions;
        }
    }
}
