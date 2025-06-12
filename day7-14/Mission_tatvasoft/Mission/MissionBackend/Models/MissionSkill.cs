using System.ComponentModel.DataAnnotations;

namespace MissionBackend.Models
{
    public class MissionSkill
    {

        [Key]
        public int Id { get; set; }
        public string SkillName { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
    }
}
