using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InuranceRazorPage.Models
{
    [Index(nameof(Account.Username), IsUnique = true)]
    public class Account
    {
        public int Id { get; set; }
        [StringLength(25, MinimumLength = 3)]
        public string Firstname { get; set; } = null!;
        [StringLength(25, MinimumLength = 3)]
        public string Fathername { get; set; } = null!;
        [StringLength(25, MinimumLength = 3)]
        public string Lastname { get; set; } = null!;
        [StringLength(25, MinimumLength = 6)]
        public string Username { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        //public string ImagePath { get; set; } = null!;
        [RegularExpression("(^[0-9]{4}[0-9]{6})", ErrorMessage = "Use Ethiopian phone format 09********")]//"[0-9]{4}[0-9]{6}"
        
        public string Phone { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public bool IsActive { get; set; } = false;
        public DateTime Dob { get; set; }
        public DateTime Createdon { get; set; }
        //Navigations
        public int? AddressId { get; set; }
        public Address Address { get; set; } = null!;

        public int RoleId { get; set; }
        public Role role { get; set; }
    }
}
