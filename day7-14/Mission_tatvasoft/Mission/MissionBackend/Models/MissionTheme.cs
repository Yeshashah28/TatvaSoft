using System.ComponentModel.DataAnnotations;

namespace MissionBackend.Models
{
    public class MissionTheme
    {
        [Key]
        public int Id { get; set; }
        public string ThemeName { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
    }
}
