using PetShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Repositories
{
    public interface IReceiptRepository
    {
        List<Receipt> GetAllReceipts();
        void AddReceipt(Receipt receipt);
        void SaveChanges();
    }
}
