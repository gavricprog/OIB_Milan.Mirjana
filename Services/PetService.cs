using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Entities;
using PetShop.Repositories;
using PetShop.Logging;

namespace PetShop.Services
{
    public class PetService : IPetService

    {
        private readonly IPetRepository _petRepo;
        private readonly ILoggerService _logger;

        public PetService(IPetRepository petRepo, ILoggerService logger)
        {
            _petRepo = petRepo;
            _logger = logger;
        }

        public List<Pet> GetAllPets() => _petRepo.GetAllPets();

        public List<Pet> GetAvailablePets() =>
            _petRepo.GetAllPets().Where(p => !p.Sold).ToList();

        public bool AddPet(Pet newPet)
        {
            var pets = _petRepo.GetAllPets();

            if (pets.Count(p => !p.Sold) >= 10)
            {
                _logger.Log("Store is full (max 10 pets).", LogType.WARNING);
                return false;
            }

            _petRepo.AddPet(newPet);
            _petRepo.SaveChanges();
            _logger.Log($"Pet {newPet.Name} added successfully.", LogType.INFO);
            return true;
        }
    }
}
