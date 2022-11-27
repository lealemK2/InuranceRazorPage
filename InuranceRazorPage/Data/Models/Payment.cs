namespace InuranceRazorPage.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int EnrollementId { get; set; }
        public Enrollement Enrollement { get; set; } = null!;
        public decimal Amount { get; set; }
    }
}
