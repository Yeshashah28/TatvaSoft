using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MissionBackend.Models
{
    public class MissionApplication
    {
        [Key]
        public int Id { get; set; }
        public int MissionId { get; set; }
        public int UserId { get; set; }

        public DateTime AppliedDate { get; set; }

        public bool Status { get; set; }


        [ForeignKey(nameof(MissionId))]
        public virtual Mission Mission { get; set; }


        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
