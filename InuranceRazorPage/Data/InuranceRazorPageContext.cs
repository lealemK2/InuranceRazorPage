using InuranceRazorPage.Models;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Data
{
    public class InuranceRazorPageContext : DbContext
    {
        public InuranceRazorPageContext (DbContextOptions<InuranceRazorPageContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; } = default!;
        public DbSet<Address> Addresses { get; set; } = default!;
        public DbSet<Location> Locations { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Account>()
        //        .HasOne(b => b.Location)
        //        .WithMany(a => a.Accounts)
        //        .HasForeignKey(a => a.LocationId);
        //}
    }
}
