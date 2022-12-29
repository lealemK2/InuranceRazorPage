using InuranceRazorPage.Models;
using Microsoft.EntityFrameworkCore;

//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InuranceRazorPage.Data
{
    public class InuranceRazorPageContext : DbContext
    {
        public InuranceRazorPageContext(DbContextOptions<InuranceRazorPageContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; } = default!;
        public DbSet<Address> Addresses { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<Subcity> Subcities { get; set; } = default!;
        public DbSet<Location> Locations { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Package> Packages { get; set; } = default!;
        public DbSet<Cbhi> Cbhis { get; set; } = default!;
        public DbSet<Payment> Payments { get; set; } = default!;


    }
}
