using Microsoft.EntityFrameworkCore;

namespace BP.Data
{
    public class BPContext : DbContext
    {
        public BPContext(DbContextOptions<BPContext> options) : base (options)
        {

        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Performance> Performances { get; set; }
        public DbSet<Scoring> ScoringSystem { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
