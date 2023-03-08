using Kassari.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KassariV2.Entities
{
    [Table("Users")]
    public class Users : BaseEntity
    {
        [Column(TypeName = "varchar(75)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string Username { get; set; }

        [Column(TypeName = "varchar(75)")]
        public string Password { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }

        [ForeignKey("Profiles")]
        public int ProfileId { get; set; }
    }
}
