using Microsoft.EntityFrameworkCore;

public class PortfolioContext : DbContext
{
    public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Investment>()
            .Property(i => i.PurchasePrice)
            .HasPrecision(18, 2);
    }

    public DbSet<Investment> Investments { get; set; }
}