using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace PersonalPortfolio
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Experience> Experiences { get; set;}
            public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
            {
            }
    }
}