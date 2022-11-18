using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RPandDb.Model;
using RPandDb.Repository;
using System;

namespace RPandDb.Pages
{
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {

        private readonly IUserRepository _db;

        public CreateModel(IUserRepository db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.PostNewUser(User);

            return RedirectToPage("Index");
        }
    }
}
