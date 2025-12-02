using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Entities;

namespace PetShop.Services
{
    public interface IAuthService
    {
        User Login(string username, string password);
    }
}
