using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaderboardAPI.Date.Entites;

namespace LeaderboardAPI.Date.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Racer> racers { get; set; }
        public DbSet<RacerStatrs> racersStart { get; set; }
        public DbSet<Accolade> accolades { get; set; }
        public DbSet<RacerAccolade> racersAccolades { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=db25474.public.databaseasp.net; Database=db25474; User Id=db25474; Password=xT%7@h9G5Sk?; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}