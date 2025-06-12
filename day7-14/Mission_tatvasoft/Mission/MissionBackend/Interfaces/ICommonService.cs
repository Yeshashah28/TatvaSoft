using MissionBackend.Dto;

namespace MissionBackend.Interfaces
{
    public interface ICommonService
    {
        List<DropDownResponseDto> CountryList();

        List<DropDownResponseDto> CityList(int countryId);

        List<DropDownResponseDto> MissionCountryList();

        List<DropDownResponseDto> MissionCityList();

        List<DropDownResponseDto> MissionThemeList();

        List<DropDownResponseDto> MissionSkillList();

        List<DropDownResponseDto> MissionTitleList();
    }
}
