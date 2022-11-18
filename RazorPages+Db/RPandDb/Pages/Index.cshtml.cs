using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RPandDb.Model;
using RPandDb.Repository;

namespace RPandDb.Pages
{
    public class IndexModel : PageModel
    {
        private IUserRepository _db;

        public IEnumerable<User> AllUsers;

        public IndexModel(IUserRepository db)
        {
            _db = db;
        }
        public void OnGet()
        {
           AllUsers = _db.GetAllUsers();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var user = _db.GetUserById(id);

            if (user != null)
            {
                _db.DeleteUser(user);
            }

            return RedirectToPage("Index");
        }
    }
}
