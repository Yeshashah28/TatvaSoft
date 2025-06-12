using System.ComponentModel.DataAnnotations;

namespace MissionBackend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Contact { get; set; }
        public string UserType{ get; set; }

        public string? ProfileImage { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }=DateTime.UtcNow;


    }
}
