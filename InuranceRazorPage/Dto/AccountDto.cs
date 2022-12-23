using InuranceRazorPage.Models;

namespace InuranceRazorPage.Dto
{
    public class AccountDto
    {
        public string Firstname { get; set; } = null!;
        public string Fathername { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime Dob { get; set; }
        public int RoleId { get; set; }
        //public Address Address { get; set; } = null!;
        public String Subcity { get; set; } = null!;
        //public Location Location { get; set; } = null!;
    }
}
