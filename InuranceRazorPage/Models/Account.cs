using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace InuranceRazorPage.Models
{
    [Index(nameof(Account.Username), IsUnique = true)]
    public class Account
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Fathername { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        //public string ImagePath { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int Age { get; set; }
        public bool IsActive { get; set; }=false;
        public DateTime Dob { get; set; }
        public DateTime Createdon { get; set; }
        //Navigations
        public int? AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public int? LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public List<AccountRole> AccountRoles { get; set; }
    }
}
