using PetShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Repositories
{
    public interface IPetRepository
    {
        List<Pet> GetAllPets();
        void AddPet(Pet pet);
        void SaveChanges();
    }
}
