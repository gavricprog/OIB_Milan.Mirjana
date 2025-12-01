using Newtonsoft.Json;
using PetShop.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Repositories
{
    public class PetRepositoryJson : IPetRepository
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "pets.json");
        private List<Pet> _pets;

        public PetRepositoryJson()
        {
            if (File.Exists(_filePath))
                _pets = JsonConvert.DeserializeObject<List<Pet>>(File.ReadAllText(_filePath)) ?? new List<Pet>();
            else
                _pets = new List<Pet>();
        }

        public List<Pet> GetAllPets() => _pets;

        public void AddPet(Pet pet)
        {
            _pets.Add(pet);
        }

        public void SaveChanges()
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(_pets, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
