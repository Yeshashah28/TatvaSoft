using System.Text.Json.Serialization;

namespace MissionBackend.Dto
{
    public class UserDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        // Similarly for others:
        [JsonPropertyName("firstName")]
        public string Firstname { get; set; }

        [JsonPropertyName("lastName")]
        public string Lastname { get; set; }

        [JsonPropertyName("emailAddress")]
        public string Email { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string Contact { get; set; }

        [JsonPropertyName("profileImage")]
        public string? ProfileImage { get; set; }

    }
}
