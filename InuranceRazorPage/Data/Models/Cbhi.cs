namespace InuranceRazorPage.Data.Models
{
    public class Cbhi
    {
        public int Id { get; set; }
        public int BaseCbhi { get; set; }
        public int AccountId { get; set; }
        //public Account Account { get; set; } = null!;//Household only
        public int TotalMembers { get; set; }
        public bool IsPayed { get; set; }
    }
}
