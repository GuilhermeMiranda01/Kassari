using Kassari.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KassariV2.Entities
{
    [Table("Profile")]
    public class Profiles : BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int Id { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string ProfileName { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Description { get; set; }
    }
}
