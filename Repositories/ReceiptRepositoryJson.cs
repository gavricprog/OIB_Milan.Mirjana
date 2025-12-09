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
    public class ReceiptRepositoryJson : IReceiptRepository
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "receipts.json");
        private List<Receipt> _receipts;

        public ReceiptRepositoryJson()
        {
            if (File.Exists(_filePath))
                _receipts = JsonConvert.DeserializeObject<List<Receipt>>(File.ReadAllText(_filePath)) ?? new List<Receipt>();
            else
                _receipts = new List<Receipt>();
        }

        public List<Receipt> GetAllReceipts() => _receipts;

        public void AddReceipt(Receipt receipt)
        {
            _receipts.Add(receipt);
        }

        public void SaveChanges()
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(_receipts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
