using Kassari.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KassariV2.Entities
{
    [Table("Task")]
    public class Tasks : BaseEntity
    {

        [Column(TypeName = "varchar(300)")]
        public string Description { get; set; }

        [ForeignKey("Users")]
        public int AssignedUserId { get; set; }
        [ForeignKey("Users")]
        public int CreatorId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime Deadline { get; set; }
        public int Priority { get; set; }
    }
}
