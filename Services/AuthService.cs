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
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly ILoggerService _logger;

        public AuthService(IUserRepository userRepo, ILoggerService logger)
        {
            _userRepo = userRepo;
            _logger = logger;
        }

        public User Login(string username, string password)
        {
            var users = _userRepo.GetAllUsers();
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                _logger.Log($"User {username} logged in successfully.", LogType.INFO);
                return user;
            }

            _logger.Log($"Failed login attempt for {username}.", LogType.WARNING);
            return null;
        }
    }
}
