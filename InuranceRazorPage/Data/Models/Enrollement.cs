namespace InuranceRazorPage.Data.Models
{
    public class Enrollement
    {
        public int Id { get; set; }
        public int CbhiId { get; set; }
        public Cbhi Cbhi { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsPaid { get; set; }
        public bool IsExpired { get; set; }
        public int PackageId { get; set; }
        public Package Package { get; set; }=null!;
    }
}
