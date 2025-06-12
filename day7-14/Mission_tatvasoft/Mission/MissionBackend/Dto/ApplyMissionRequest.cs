namespace MissionBackend.Dto
{
    public class ApplyMissionRequest
    {
        public DateTime AppliedDate { get; set; }
        public int MissionId { get; set; }

        public int UserId { get; set; }
    }
}
