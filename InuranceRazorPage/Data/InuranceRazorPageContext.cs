using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InuranceRazorPage.Models;

namespace InuranceRazorPage.Data
{
    public class InuranceRazorPageContext : DbContext
    {
        public InuranceRazorPageContext (DbContextOptions<InuranceRazorPageContext> options)
            : base(options)
        {
        }

        public DbSet<InuranceRazorPage.Models.Account> Accounts { get; set; } = default!;
    }
}
