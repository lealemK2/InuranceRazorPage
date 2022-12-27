using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace InuranceRazorPage.Pages.SystemAdmin.Accounts
{
    public class CreateModel : PageModel
    {
       



        private readonly InuranceRazorPage.Data.InuranceRazorPageContext _context;

        public CreateModel(InuranceRazorPage.Data.InuranceRazorPageContext context)
        {
            _context = context;
        }


        [BindProperty,Required]
        public AccountDto AccountDto { get; set; }

        public string[] GenderOptions = new[] { "Male", "Female"};

        //[DisplayName("Subjects")]
        [BindProperty]
        public List<Role> Roles { get; set; } = default!;
        public List<Subcity> Subcities { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Roles != null)
            {
                var role=await _context.Roles.ToListAsync();
                Roles = role.ToList();
            }
            else { 
                Roles = new List<Role>();
            }
            if (_context.Subcities != null)
            {
                Subcities = await _context.Subcities.ToListAsync();
            }
            else
            {
                Subcities = new List<Subcity>();
            }
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Roles != null)
            {
                var role = await _context.Roles.ToListAsync();
                Roles = role.ToList();
            }
            else
            {
                Roles = new List<Role>();
            }
            if (_context.Subcities != null)
            {
                Subcities = await _context.Subcities.ToListAsync();
            }
            else
            {
                Subcities = new List<Subcity>();
            }
            if (AccountDto.Gender == "") 
            {
                ModelState.AddModelError("AccountDto.Gender", "Gender field is required");
            }
            if (AccountDto.RoleId==0)
            {
                ModelState.AddModelError("AccountDto.RoleId", "Plese select a role");
            }
            if (String.IsNullOrEmpty(AccountDto.Subcity))
            {
                ModelState.AddModelError("AccountDto.Subcity", "Plese select a subcity");
            }

            if (UsernameExists(AccountDto.Username))
            {
                ModelState.AddModelError("AccountDto.Username", "Username is already taken!");
            }
            //string strRegex = @"(^[0-9]{4}[0-9]{6})";
            //Regex re = new Regex(strRegex);
            //if (!re.IsMatch(AccountDto.Phone))
            //{
            //    ModelState.AddModelError("AccountDto.Phone", "Wrong Phone pattern! use 09*** format");
            //}

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            CreatePasswordHash(AccountDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var account = new Account
            {
                Firstname = AccountDto.Firstname,
                Fathername = AccountDto.Fathername,
                Lastname = AccountDto.Lastname,
                Username = AccountDto.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Phone = AccountDto.Phone,
                Gender = AccountDto.Gender,
                Dob = AccountDto.Dob.Date,
                RoleId=AccountDto.RoleId,
                Createdon = DateTime.Now
            };
            _context.Accounts.Add(account);
            //subcity to address
            await _context.SaveChangesAsync();

            return RedirectToPage("../ManageAccounts");
         }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public bool UsernameExists(string Username)
        {
            if (_context.Accounts.Any(x => x.Username.Trim().ToUpper().Equals(Username.Trim().ToUpper())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public ActionResult GetWoreda(int subcityId)
        {
            Task<System.Collections.Generic.List<InuranceRazorPage.Models.WoredaRange>> Woredas=null;
            if (_context.WoredaRanges != null)
            {
                Woredas =_context.WoredaRanges.Where(item => item.SubcityId==subcityId).ToListAsync();
            }
            return Partial("_WoredaPartial", Woredas);
        }

    }
}
