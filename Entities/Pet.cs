using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Entities
{
    public class Pet
    {
        // Jedinstveni identifikator
        public int Id { get; set; }

        // Latinski naziv vrste
        public string LatinName { get; set; }

        // Ime ljubimca
        public string Name { get; set; }

        // Tip ljubimca: sисар, гмизавац, глодар
        public PetType Type { get; set; }

        // Cena za prodaju
        public decimal Price { get; set; }

        // Da li je ljubimac već prodat
        public bool Sold { get; set; } = false;

        // Konstruktor
        public Pet() { }

        public Pet(string latinName, string name, PetType type, decimal price)
        {
            LatinName = latinName;
            Name = name;
            Type = type;
            Price = price;
            Sold = false;
        }
    }
}
