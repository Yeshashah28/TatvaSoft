using System.Text.Json.Serialization;

namespace MissionBackend.Dto
{
    public class RegisterDto
    {
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string LastName { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("Contact")]
        public string Contact { get; set; }

        [JsonPropertyName("userType")]
        public string UserType { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
