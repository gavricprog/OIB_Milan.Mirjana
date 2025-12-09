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
    public class NightSaleService : ISaleService
    {
        private readonly IPetRepository _petRepo;
        private readonly IReceiptRepository _receiptRepo;
        private readonly ILoggerService _logger;

        public NightSaleService(IPetRepository petRepo, IReceiptRepository receiptRepo, ILoggerService logger)
        {
            _petRepo = petRepo;
            _receiptRepo = receiptRepo;
            _logger = logger;
        }

        public void SellPet(Pet pet, User seller)
        {
            decimal finalPrice = pet.Price * 1.10m; // +10% porez
            pet.Sold = true;

            var receipt = new Receipt
            {
                SalesmanName = seller.FullName,
                SaleDate = DateTime.Now,
                TotalAmount = finalPrice
            };

            _receiptRepo.AddReceipt(receipt);
            _receiptRepo.SaveChanges();
            _petRepo.SaveChanges();

            _logger.Log($"[NIGHT SALE] {seller.FullName} sold {pet.Name} for {finalPrice}$.", LogType.INFO);
        }

    }
}
