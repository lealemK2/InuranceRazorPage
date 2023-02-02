using InuranceRazorPage.Data;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InuranceRazorPage.Pages.InsuredPerson
{
    public class renewModel : PageModel
    {
        private readonly InuranceRazorPageContext _context;

        public renewModel(InuranceRazorPageContext context)
        {
            _context = context;
        }
        public Customer Customer { get; set; }
        public string Package { get; set; }
        public DateTime D { get; set; }
        public Decimal Total { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (_context != null)
            {
                Customer = _context.Customers.Include(c => c.Cbhi).Include(c => c.Cbhi.Package)
                    .FirstOrDefault(c => c.Id == id);
            }
            if (Customer == null)
            {
                return NotFound();
            }

            Payment payment = new Payment();
            payment.CbhiId = Customer.CbhiId;
            payment.CustomerId = Customer.Id;
            payment.Date = DateTime.Now;
            payment.PackageName = Customer.Cbhi.Package.Name;
            payment.PackageFee = Customer.Cbhi.Package.Price;
            payment.AdditionalFeePerMember = Customer.Cbhi.Package.AdditionalFeePerAdult;
            payment.PayableMembers = Customer.Cbhi.PayableMembers;
            payment.AdditionalMembers = Customer.Cbhi.AdditionalMembers;
            payment.LimitOfMembersPerPackage = Customer.Cbhi.Package.MaxNumberOfAdult;
            payment.Amount = payment.PackageFee +
                        (payment.AdditionalMembers * payment.AdditionalFeePerMember);

            var cbhi = _context.Cbhis.FirstOrDefault(c => c.Id == Customer.CbhiId);
             
            if (DateTime.Compare(DateTime.Now,cbhi.EndDate)<0)//if not expired
            {
                cbhi.StartDate = cbhi.EndDate;
                cbhi.EndDate = cbhi.StartDate.AddYears(1);
                cbhi.IsPaid = true;
            }
            else
            {
                cbhi.StartDate = DateTime.Now;
                cbhi.EndDate = DateTime.Now.AddYears(1);
                cbhi.IsPaid = true;
            }

            _context.Cbhis.Update(cbhi);
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
