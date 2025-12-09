using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Entities;
using PetShop.Services;
using PetShop.Logging;

namespace PetShop.Presentation
{
    public class SalesmanMenu
    {
        private readonly IPetService _petService;
        private readonly ISaleService _saleService;
        private readonly User _loggedUser;
        private readonly ILoggerService _logger;

        public SalesmanMenu(IPetService petService, ISaleService saleService, User loggedUser, ILoggerService logger)
        {
            _petService = petService;
            _saleService = saleService;
            _loggedUser = loggedUser;
            _logger = logger;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== SALESMAN MENU =====");
                Console.WriteLine($"Logged in as: {_loggedUser.FullName}");
                Console.WriteLine("1. View available pets");
                Console.WriteLine("2. Sell a pet");
                Console.WriteLine("0. Logout");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowAvailablePets();
                        break;
                    case "2":
                        SellPet();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private void ShowAvailablePets()
        {
            var pets = _petService.GetAvailablePets();
            Console.WriteLine("\nAvailable pets:");
            if (pets.Count == 0)
            {
                Console.WriteLine("No pets available.");
                return;
            }

            foreach (var pet in pets)
                Console.WriteLine($"[{pet.Id}] {pet.Name} ({pet.Type}) - ${pet.Price}");
        }

        private void SellPet()
        {
            var pets = _petService.GetAvailablePets();
            if (pets.Count == 0)
            {
                Console.WriteLine("No pets available for sale.");
                return;
            }

            ShowAvailablePets();
            Console.Write("\nEnter pet ID to sell: ");
            string idInput = Console.ReadLine();

            var pet = pets.FirstOrDefault(p => p.Id.ToString() == idInput);
            if (pet == null)
            {
                Console.WriteLine("Invalid pet ID.");
                return;
            }

            _saleService.SellPet(pet, _loggedUser);
            Console.WriteLine($"Pet {pet.Name} sold successfully!");
        }
    }
}
