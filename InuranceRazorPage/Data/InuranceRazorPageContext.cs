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
        public DbSet<Location> Locations { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        public DbSet<AccountRole> AccountRoles { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountRole>()
                .HasOne(b => b.Role)
                .WithMany(a => a.AccountRoles)
                .HasForeignKey(a => a.RoleId);

            modelBuilder.Entity<AccountRole>()
                .HasOne(b => b.Account)
                .WithMany(a => a.AccountRoles)
                .HasForeignKey(a => a.AccountId);
        }
    }
}
