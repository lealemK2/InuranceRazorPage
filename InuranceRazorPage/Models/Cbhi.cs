namespace InuranceRazorPage.Models
{
    public class Cbhi
    {
        public int Id { get; set; }
        public String BaseCbhi { get; set; }
        public int TotalAdults { get; set; }
        public int TotalMembers { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPaid { get; set; }
        //navigations
        public int PackageId { get; set; }
        public Package Package { get; set; }
        public int NthTracker { get; set; }
    }
}
