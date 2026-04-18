using Microsoft.EntityFrameworkCore;
using NorthwindCatalog.Services.Models;

namespace NorthwindCatalog.Services.Models
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext()
        {
        }

        public NorthwindContext(DbContextOptions<NorthwindContext> options)
            : base(options)
        {
        }

    //    public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning Move connection string to appsettings.json for security
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.\\sqlexpress;Initial Catalog=Northwind;Integrated Security=True;Encrypt=True;TrustServerCertificate=True"
                );
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ReorderLevel).HasDefaultValue((short)0);

                entity.Property(e => e.UnitPrice)
                      .HasDefaultValue(0m)
                      .HasColumnType("decimal(10,2)");

                entity.Property(e => e.UnitsInStock).HasDefaultValue((short)0);
                entity.Property(e => e.UnitsOnOrder).HasDefaultValue((short)0);

                entity.HasOne(d => d.Category)
                      .WithMany(p => p.Products)
                      .HasForeignKey(d => d.CategoryId)
                      .HasConstraintName("FK_Products_Categories");
            });
        }


    }
}