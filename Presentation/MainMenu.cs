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
    public class MainMenu
    {
        private readonly IAuthService _authService;
        private readonly IPetService _petService;
        private readonly ISaleService _saleService;
        private readonly ILoggerService _logger;
        private readonly IReceiptService _receiptService;


        public MainMenu(IAuthService authService, IPetService petService, ISaleService saleService, IReceiptService receiptService, ILoggerService logger)
        {
            _authService = authService;
            _petService = petService;
            _saleService = saleService;
            _receiptService = receiptService;
            _logger = logger;
        }

        public void Run()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("       🐾  PET SHOP SYSTEM  🐾");
                Console.WriteLine("=====================================");
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                var user = _authService.Login(username, password);
                if (user == null)
                {
                    Console.WriteLine("\nInvalid credentials. Try again...\n");
                    continue;
                }

                if (user.UserRole == Role.Manager)
                {
                    var managerMenu = new ManagerMenu(_petService, _receiptService, _logger);
                    managerMenu.Run();
                }
                else if (user.UserRole == Role.Salesman)
                {
                    var salesmanMenu = new SalesmanMenu(_petService, _saleService, user, _logger);
                    salesmanMenu.Run();
                }

                Console.WriteLine("\nPress any key to return to login...");
                Console.ReadKey();
            }
        }
    }
}
