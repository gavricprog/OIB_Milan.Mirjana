using PetShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Entities;

namespace PetShop.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        void AddUser(User user);
        void SaveChanges();
    }

}
