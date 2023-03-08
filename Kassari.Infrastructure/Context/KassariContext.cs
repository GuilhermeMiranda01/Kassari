using KassariV2.Entities;
using Microsoft.EntityFrameworkCore;

namespace KassariV2.Context
{
    public class KassariContext : DbContext
    {
        public KassariContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
    }
}
