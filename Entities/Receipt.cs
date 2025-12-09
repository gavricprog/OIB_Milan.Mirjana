using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Entities
{
    public class Receipt
    {
        // Jedinstveni identifikator računa
        public Guid Id { get; set; } = Guid.NewGuid();

        // Ime prodavca (Salesman) koji je izvršio prodaju
        public string SalesmanName { get; set; }

        // Datum i vreme prodaje
        public DateTime SaleDate { get; set; } = DateTime.Now;

        // Ukupan iznos računa
        public decimal TotalAmount { get; set; }

        // Konstruktor
        public Receipt() { }

        public Receipt(string salesmanName, decimal totalAmount)
        {
            SalesmanName = salesmanName;
            TotalAmount = totalAmount;
            SaleDate = DateTime.Now;
        }
    }
}
