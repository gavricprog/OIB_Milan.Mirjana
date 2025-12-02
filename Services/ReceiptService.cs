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
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly ILoggerService _logger;

        public ReceiptService(IReceiptRepository receiptRepository, ILoggerService logger)
        {
            _receiptRepository = receiptRepository;
            _logger = logger;
        }

        public List<Receipt> GetAllReceipts()
        {
            var receipts = _receiptRepository.GetAllReceipts();
            _logger.Log($"All receipts retrieved. Count: {receipts.Count}", LogType.INFO);
            return receipts;
        }
    }
}
