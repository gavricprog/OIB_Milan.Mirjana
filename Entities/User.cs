using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Entities
{
    public class User
    {
        // Jedinstveni identifikator za svakog korisnika
        public Guid Id { get; set; } = Guid.NewGuid();

        // Korisničko ime i lozinka za autentifikaciju
        public string Username { get; set; }
        public string Password { get; set; }

        // Ime i prezime korisnika
        public string FullName { get; set; }

        // Uloga korisnika u sistemu (Manager ili Salesman)
        public Role UserRole { get; set; }

        // Konstruktor
        public User() { }

        public User(string username, string password, string fullName, Role role)
        {
            Username = username;
            Password = password;
            FullName = fullName;
            UserRole = role;
        }
    }
}
