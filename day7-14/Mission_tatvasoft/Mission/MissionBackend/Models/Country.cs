namespace MissionBackend.Models
{
    public class Country
    {

        public int Id { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<Mission> Missions { get; set; } = [];
    }
}
