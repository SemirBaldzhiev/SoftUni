using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels.Users;
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

        public string GetUsername(string userId)
        {
            return repo.All<User>()
                .FirstOrDefault(u => u.Id == userId)?.Username;
        }

        public string Login(LoginViewModel model)
        {
            var user = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == HashPassword(model.Password))
                .SingleOrDefault();

            return user?.Id;
        }

        public (bool registered, string error) Register(RegisterViewModel model)
        {
            bool registered = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }


            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = HashPassword(model.Password),
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
                error = "Could not save user in DB";
            }

            return (registered, error);
        }

        private string HashPassword(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }
    }
}
