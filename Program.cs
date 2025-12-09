using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShop.Repositories;
using PetShop.Logging;
using PetShop.Services;
using PetShop.Presentation;

namespace PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // === 1. Kreiramo logger koji beleži događaje u Data/log.txt ===
            ILoggerService logger = new FileLoggerService();
            logger.Log("Application started.", LogType.INFO);

            // === 2. Kreiramo repozitorijume koji čitaju podatke iz JSON fajlova ===
            IPetRepository petRepository = new PetRepositoryJson();
            IReceiptRepository receiptRepository = new ReceiptRepositoryJson();
            IUserRepository userRepository = new UserRepositoryJson();
            IReceiptService receiptService = new ReceiptService(receiptRepository, logger);


            // === 3. Kreiramo servise za poslovnu logiku ===
            IAuthService authService = new AuthService(userRepository, logger);
            IPetService petService = new PetService(petRepository, logger);

            // Odabir implementacije prodaje na osnovu vremena (smena)
            ISaleService saleService;
            int hour = DateTime.Now.Hour;

            if (hour >= 8 && hour < 16)
            {
                saleService = new DaySaleService(petRepository, receiptRepository, logger);
                logger.Log("Day sale service active (08–16h).", LogType.INFO);
            }
            else if (hour >= 16 && hour < 22)
            {
                saleService = new NightSaleService(petRepository, receiptRepository, logger);
                logger.Log("Night sale service active (16–22h).", LogType.INFO);
            }
            else
            {
                // Ako je van radnog vremena, koristi se noćna implementacija (ili zabrani prodaju)
                saleService = new NightSaleService(petRepository, receiptRepository, logger);
                logger.Log("Outside of working hours — using NightSaleService by default.", LogType.WARNING);
            }

            // === 4. Pokrećemo glavni meni (login + preusmeravanje) ===
            var mainMenu = new MainMenu(authService, petService, saleService, receiptService, logger);
            mainMenu.Run();

            // === 5. Na kraju, loguj kraj aplikacije ===
            logger.Log("Application closed.", LogType.INFO);
        }
    }
}
