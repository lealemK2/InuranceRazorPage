using InuranceRazorPage.Models;

namespace InuranceRazorPage.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CbhiId { get; set; }//////////
        public Cbhi Cbhi { get; set; } 
        public int CustomerId { get; set; }//// ///
        public Customer Customer { get; set; }
        public String PackageName { get; set; }
        public decimal AdditionalFeePerMember { get; set; }
        public decimal PackageFee { get; set; }
        public int PayableMembers { get; set; }
        public int LimitOfMembersPerPackage { get; set; }
        public int AdditionalMembers { get; set; }
    }
}
