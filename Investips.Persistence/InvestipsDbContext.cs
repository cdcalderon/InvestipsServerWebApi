using Investips.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Investips.Persistence
{
    public class InvestipsDbContext : DbContext
    {
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<WidgetMultipointShape> WidgetMultipointShapes { get; set; }
        public DbSet<WidgetShape> WidgetShapes { get; set; }
        public InvestipsDbContext(DbContextOptions<InvestipsDbContext> options)
            : base((DbContextOptions) (DbContextOptions) options)
        {
                //Database.EnsureCreated();
                //Database.EnsureDeleted();
        }

        protected override void OnModelCreating(ModelBuilder modelBulder)
        {
            modelBulder.Entity<PortfolioSecurity>().HasKey(ps =>
                new { ps.PortfolioId, ps.SecurityId });

            modelBulder.Entity<SecurityWidgetShape>().HasKey(sw =>
                new { sw.SecurityId, sw.WidgetShapeId});
        }
    }
}
