using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace InuranceRazorPage.Models
{
    [Index(nameof(Account.Username), IsUnique = true)]
    public class Account
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!; 
        public string Username { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;

    }
}
