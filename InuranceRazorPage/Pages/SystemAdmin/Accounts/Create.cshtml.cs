using InuranceRazorPage.Dto;
using InuranceRazorPage.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using  InuranceRazorPage.Data;

namespace InuranceRazorPage.Pages.SystemAdmin.Accounts
{
    [Authorize(Roles = "SystemAdmin")]
    public class CreateModel : PageModel
    {  
        private readonly InuranceRazorPageContext _context;

        public CreateModel(InuranceRazorPageContext context)
        {
            _context = context;
        }
        

        [BindProperty,Required]
        public AccountDto AccountDto { get; set; }

        public string[] GenderOptions = new[] { "Male", "Female"};

        [BindProperty]
        public List<Role> Roles { get; set; } = default!;
        [BindProperty]
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
            
            AccountDto = new AccountDto();
            AccountDto.Dob = DateTime.Now.AddYears(-18);
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

            
            if (AccountDto.Gender == null) 
            {
                ModelState.AddModelError("AccountDto.Gender", "The Gender field is required");
            }

            if (AccountDto.RoleId==0)
            {
                ModelState.AddModelError("AccountDto.RoleId", "Please select a Role");
            }
            if (AccountDto.SubcityId==0)
            {
                ModelState.AddModelError("AccountDto.SubcityId", "Please select a Subcity");
            }

            if (UsernameExists(AccountDto.Username))
            {
                ModelState.AddModelError("AccountDto.Username", "Username is already taken!");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            var location = await _context.Locations.Include(l=>l.Subcity).FirstOrDefaultAsync(l => AccountDto.SubcityId == l.SubcityId && l.woreda < AccountDto.Woreda);
            if (location != null)
            {
                ModelState.AddModelError("AccountDto.Woreda", location.Subcity.Name+" subcity has woreda range from 1 upto "+location.woreda);
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Address address = new Address() { 
                SubcityId = AccountDto.SubcityId,
                Woreda = AccountDto.Woreda,
                HouseNumber = AccountDto.HouseNumber,
            };
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
                Address = address,
                RoleId =AccountDto.RoleId,
                Createdon = DateTime.Now
            };
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ManageAccounts");
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

        

    }
}
