namespace InuranceRazorPage.Data.Models
{
    public class Enrollement
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        Account Account { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPaid { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }=null!;
    }
}
