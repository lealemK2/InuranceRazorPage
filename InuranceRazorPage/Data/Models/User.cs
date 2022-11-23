namespace InuranceRazorPage.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Fathername { get; set; } = null!;
        public string Lastname { get; set; }=null!;
        public string Role { get; set; }=null!;
        public string CbhiId { get; set; }=null!;
        public string Gender { get; set; }=null!;
        public string Dob { get; set; }=null!;
        public string Username { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
    }
}
