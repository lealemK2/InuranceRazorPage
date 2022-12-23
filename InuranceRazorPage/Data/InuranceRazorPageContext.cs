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
        //public DbSet<Location> Locations { get; set; } = default!;
        public DbSet<Role> Roles { get; set; } = default!;
        //public DbSet<AccountRole> AccountRoles { get; set; } = default!;
        //Woredarange,  subcity,  subcityRange,office
        public DbSet<WoredaRange> WoredaRanges { get; set; } = default!;
        public DbSet<Subcity> Subcities { get; set; } = default!;
        public DbSet<SubcityRange> SubcityRanges { get; set; } = default!;
        public DbSet<Location> Locations { get; set; } = default!;

        
    }
}
