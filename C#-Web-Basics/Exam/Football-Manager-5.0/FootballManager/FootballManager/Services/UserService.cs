using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public UserService(
            IRepository repo,
            IValidationService validationService
            )
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public string Login(LoginViewModel model)
        {
            var userId = repo.All<User>()
                .Where(u => u.Username == model.Username && u.Password == PasswordHasher(model.Password))
                .Select(u => u.Id)
                .FirstOrDefault();

            return userId;
        }

        public List<string> Register(RegisterViewModel model)
        {
            var modelErrors = validationService.ValidateUser(model);

            if (!modelErrors.Any())
            {
                var user = new User
                {
                    Username = model.Username,
                    Email = model.Email,
                    Password = PasswordHasher(model.Password),
                };

                repo.Add(user);

                repo.SaveChanges();
            }
            
            return modelErrors.ToList();
        }

        private string PasswordHasher(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }
    }
}
