using FootbalApp.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace FootbalApp
    
{
    public class FootballDbContext :DbContext
    {
        public FootballDbContext(DbContextOptions options) : base(options)  
        {

        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                        .HasOne(x => x.Team)
                        .WithMany(x => x.TeamPlayers)
                        .HasForeignKey(x => x.TeamId);



        }
    }
}
