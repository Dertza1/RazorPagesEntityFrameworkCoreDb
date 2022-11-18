using Microsoft.EntityFrameworkCore;
using RPandDb.Db;
using RPandDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPandDb.Repository
{
    public class MockUserPerository : IUserRepository
    {
        private readonly ApplicationContext _db;
        public MockUserPerository(ApplicationContext db)
        {
            _db = db;
        }

        public void DeleteUser(User deleteUser)
        {
            _db.Users.Remove(deleteUser);
            _db.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _db.Users.ToList();
        }

        public User GetUserById(int? id)
        {
            User user = _db.Users.SingleOrDefault(b=>b.Id == id);
            
            return user;
        }

        public void PostNewUser(User newUser)
        {
            _db.Users.Add(newUser);
            _db.SaveChanges();
        }

        public void UpdateUser(User editUser)
        {
            _db.Users.Update(editUser);
            _db.SaveChanges();
        }
    }
}
