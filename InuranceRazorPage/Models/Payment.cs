using InuranceRazorPage.Models;

namespace InuranceRazorPage.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CbhiId { get; set; }
        public Cbhi Cbhi { get; set; } 
    }
}
