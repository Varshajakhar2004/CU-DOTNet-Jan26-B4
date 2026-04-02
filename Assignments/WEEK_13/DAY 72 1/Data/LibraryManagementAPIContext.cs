using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Data
{
    public class LibraryManagementAPIContext : DbContext
    {
        public LibraryManagementAPIContext (DbContextOptions<LibraryManagementAPIContext> options)
            : base(options)
        {
        }

        public DbSet<LibraryManagementAPI.Models.Book> Book { get; set; } = default!;
    }
}
