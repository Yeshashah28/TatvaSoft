using MissionBackend.Data;
using MissionBackend.Interfaces;
using MissionBackend.Dto;

namespace MissionBackend.Services
{
    public class CommonService : ICommonService
    {
        private readonly AppDbContext _context;
        private readonly ICommonRepository _repo;

        public CommonService(AppDbContext context, ICommonRepository repo)
        {
            _context = context;
            _repo = repo;
        }

        public List<DropDownResponseDto> CountryList() => _repo.CountryList();

        public List<DropDownResponseDto> CityList(int countryId) => _repo.CityList(countryId);

        public List<DropDownResponseDto> MissionCountryList() => _repo.MissionCountryList();

        public List<DropDownResponseDto> MissionCityList() => _repo.MissionCityList();

        public List<DropDownResponseDto> MissionThemeList() => _repo.MissionThemeList();

        public List<DropDownResponseDto> MissionSkillList() => _repo.MissionSkillList();

        public List<DropDownResponseDto> MissionTitleList() => _repo.MissionTitleList();
    }
}
