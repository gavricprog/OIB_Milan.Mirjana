using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Entities;

namespace PetShop.Services
{
    public interface ISaleService
    {
        void SellPet(Pet pet, User seller);
    }
}
