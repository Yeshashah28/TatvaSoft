namespace MissionBackend.Models
{
    public class LoginResponse
    {
        public int Result { get; set; }  
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
