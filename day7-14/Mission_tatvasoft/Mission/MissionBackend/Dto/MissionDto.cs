using MissionBackend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MissionBackend.Dto
{
    public class MissionDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string MissionTitle { get; set; }
        public int MissionThemeId { get; set; }
        public string MissionDescription { get; set; }

        [JsonPropertyName("totalSheets")]
        public int TotalSeats { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string MissionImages { get; set; }
        public string MissionSkillId { get; set; }

        public string? MissionThemeName { get; set; }
    }

}

