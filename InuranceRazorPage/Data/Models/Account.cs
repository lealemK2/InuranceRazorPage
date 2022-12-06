namespace InuranceRazorPage.Data.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public int number2 { get; set; }
    }
}
