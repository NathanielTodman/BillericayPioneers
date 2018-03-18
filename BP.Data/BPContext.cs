using Microsoft.EntityFrameworkCore;
namespace BP.Data
{
    public class BPContext : DbContext
    {
        public BPContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SQL6001.site4now.net;Initial Catalog=DB_A33A5B_bp;User Id=DB_A33A5B_bp_admin;Password=Todman86;");

            }
        }

        public BPContext(DbContextOptions<BPContext> options) : base (options)
        {

        }

        public DbSet<User> Users { get; set; }
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
