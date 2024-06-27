using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PersonalPortfolio
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Experience> Experiences { get; set;}
        public DbSet<Skill> Skills { get; set;}
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Experience>()
                .Property(a => a.Category)
                .HasConversion(new EnumToStringConverter<CategoryEnum>());
        }
    }
}