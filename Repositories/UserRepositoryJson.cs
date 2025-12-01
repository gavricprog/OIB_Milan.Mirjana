using PetShop.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace PetShop.Repositories
{
    public class UserRepositoryJson : IUserRepository
    {
        private readonly string _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "users.json");
        private List<User> _users;

        public UserRepositoryJson()
        {
            if (File.Exists(_filePath))
                _users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(_filePath)) ?? new List<User>();
            else
                _users = new List<User>();
        }

        public List<User> GetAllUsers() => _users;

        public void AddUser(User user) => _users.Add(user);

        public void SaveChanges()
        {
            File.WriteAllText(_filePath, JsonConvert.SerializeObject(_users, Newtonsoft.Json.Formatting.Indented)
);
        }
    }
}
