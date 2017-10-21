using Investips.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Investips.Persistence
{
    public class InvestipsDbContext : DbContext
    {
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<WidgetShape> WidgetShapes { get; set; }
        public DbSet<Chart> Charts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public InvestipsDbContext(DbContextOptions<InvestipsDbContext> options)
            : base((DbContextOptions) (DbContextOptions) options)
        {
                //Database.EnsureCreated();
                //Database.EnsureDeleted();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PortfolioSecurity>().HasKey(ps =>
                new { ps.PortfolioId, ps.SecurityId });

            modelBuilder.Entity<UserRole>().HasKey(ur => new {ur.UserId, ur.RoleId});

        }
    }
}
