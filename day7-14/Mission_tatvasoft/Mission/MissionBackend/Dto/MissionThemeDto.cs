using System.Text.Json.Serialization;

namespace MissionBackend.Dto
{
    public class MissionThemeDto
    {
        public int Id { get; set; }

        public string ThemeName { get; set; }

        public string Status { get; set; }

    }
}
