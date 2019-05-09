using Microsoft.EntityFrameworkCore;
using TiburonTest.Domain.Models;

namespace TiburonTest.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<SurveyUser> SurveyUsers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ForSqlServerUseIdentityColumns();
            modelBuilder.Entity<SurveyUser>().ToTable("SurveyUsers");
            modelBuilder.Entity<SurveyUser>().HasKey(u => u.Id);
            modelBuilder.Entity<SurveyUser>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<SurveyUser>().Property(u => u.Gender).IsRequired();
            modelBuilder.Entity<SurveyUser>().Property(u => u.PhoneBrands).IsRequired();

        }
    }
}
