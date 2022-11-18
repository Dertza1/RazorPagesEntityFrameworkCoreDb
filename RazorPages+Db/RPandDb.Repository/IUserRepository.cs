using RPandDb.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPandDb.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        void PostNewUser(User newUser);
        User GetUserById(int? id);

        void UpdateUser(User editUser);  
        void DeleteUser(User deleteUser);  
    }
}
