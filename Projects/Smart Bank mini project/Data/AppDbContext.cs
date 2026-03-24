using Microsoft.EntityFrameworkCore;
using SmartBankMiniProject.Models;

namespace SmartBankMiniProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Account> Accounts { get; set; }
    }
}
