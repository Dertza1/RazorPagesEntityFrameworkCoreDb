using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RPandDb.Db;
using RPandDb.Model;
using RPandDb.Repository;
using System;

namespace RPandDb.Pages
{
    public class EditModel : PageModel
    {

        private readonly IUserRepository _db;

        [BindProperty]
        public User User { get; set; }

        public EditModel(IUserRepository db)
        {
            _db = db;
        }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = _db.GetUserById(id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _db.UpdateUser(User);
            }
            catch (DbUpdateConcurrencyException)
            {

                if (_db.GetUserById(User.Id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("Index");
        }
    }
}
