using System.ComponentModel.DataAnnotations;

using static FootballManager.Constants.DataConstants;

namespace FootballManager.ViewModels.Users
{
    public class RegisterViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
