using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LoanAPI.Models;

namespace WebAPIDemo02.Data
{
    public class WebAPIDemo02Context : DbContext
    {
        public WebAPIDemo02Context (DbContextOptions<WebAPIDemo02Context> options)
            : base(options)
        {
        }

        public DbSet<LoanAPI.Models.Loan> Loan { get; set; } = default!;
    }
}
