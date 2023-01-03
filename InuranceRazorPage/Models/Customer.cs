using InuranceRazorPage.Models;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Models
{
    [Index(nameof(Customer.LoginCbhi), IsUnique = true)]
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Fathername { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Phone { get; set; } = null!;
        //public string ImagePath { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Relation { get; set; }= null!;
        public bool IsAdditional { get; set; }
        public bool IsDisabled { get; set; }
        public string LoginCbhi { get; set; } = null!;
        public DateTime Createdon { get; set; }
        //navigations
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;
        public int CbhiId { get; set; }
        public Cbhi Cbhi { get; set; } = null!;

    }
}
