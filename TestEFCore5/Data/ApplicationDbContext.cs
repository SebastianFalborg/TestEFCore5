using Microsoft.EntityFrameworkCore;
using TestEFCore5.Models;

namespace MitGymnastik.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<GymnastGroup> GymnastGroups { get; set; }
        public DbSet<FloorRoutine> FloorRoutines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}