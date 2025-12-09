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
    public class ManagerMenu
    {
        private readonly IPetService _petService;
        private readonly IReceiptService _receiptService;

        private readonly ILoggerService _logger;

        public ManagerMenu(IPetService petService, IReceiptService receiptService, ILoggerService logger)
        {
            _petService = petService;
            _receiptService = receiptService;
            _logger = logger;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== MANAGER MENU =====");
                Console.WriteLine("1. Add new pet");
                Console.WriteLine("2. View all pets");
                Console.WriteLine("3. View all receipts");
                Console.WriteLine("0. Logout");
                Console.Write("Choose option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddPet();
                        break;
                    case "2":
                        ShowAllPets();
                        break;
                    case "3":
                        ShowAllReceipts();
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

        private void AddPet()
        {
            Console.Write("Pet name: ");
            string name = Console.ReadLine();

            Console.Write("Latin name: ");
            string latinName = Console.ReadLine();

            Console.WriteLine("Choose pet type: 0 - Mammal, 1 - Reptile, 2 - Rodent");
            if (!int.TryParse(Console.ReadLine(), out int typeInt) || typeInt < 0 || typeInt > 2)
            {
                Console.WriteLine("Invalid type!");
                return;
            }

            Console.Write("Price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price!");
                return;
            }

            var newPet = new Pet
            {
                Name = name,
                LatinName = latinName,
                Type = (PetType)typeInt,
                Price = price,
                Sold = false
            };

            if (_petService.AddPet(newPet))
                Console.WriteLine("Pet successfully added!");
            else
                Console.WriteLine("Store already has 10 pets, cannot add new one!");
        }

        private void ShowAllPets()
        {
            List<Pet> pets = _petService.GetAllPets();
            Console.WriteLine("\nAll pets in store:");
            foreach (var pet in pets)
                Console.WriteLine($"[{pet.Id}] {pet.Name} ({pet.LatinName}) - {pet.Type} - ${pet.Price} - Sold: {pet.Sold}");
        }

        private void ShowAllReceipts()
        {
            Console.Clear();
            Console.WriteLine("=== All Receipts ===");
            var receipts = _receiptService.GetAllReceipts();

            if (receipts.Count == 0)
            {
                Console.WriteLine("No receipts found.");
                return;
            }

            foreach (var r in receipts)
            {
                Console.WriteLine($"Date: {r.SaleDate}");
                Console.WriteLine($"Salesman: {r.SalesmanName}");
                Console.WriteLine($"Total: {r.TotalAmount:F2}$");
                Console.WriteLine("---------------------------");
            }

            _logger.Log("Manager viewed all receipts.", LogType.INFO);
        }
    }
}
