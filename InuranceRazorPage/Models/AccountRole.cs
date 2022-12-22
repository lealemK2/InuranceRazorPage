namespace InuranceRazorPage.Models
{
    public class AccountRole
    {
        public int Id { get; set; }
        //navigations
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
        public int AccountId { get; set; }
        public Account Account { get; set; }= null!;
    }
}
