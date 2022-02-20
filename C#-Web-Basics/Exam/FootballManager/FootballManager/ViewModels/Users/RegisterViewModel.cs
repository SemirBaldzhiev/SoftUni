using System.ComponentModel.DataAnnotations;

using static FootballManager.Constants.DataConstants;

namespace FootballManager.ViewModels.Users
{
    public class RegisterViewModel
    {
        [StringLength(UsernameMaxLength, MinimumLength = UsernameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }

        [StringLength(EmailMaxLength, MinimumLength = EmailMinLength, ErrorMessage = "{0} must be between {2} and {1} characters")]
        [EmailAddress(ErrorMessage = "Email must be valid email")]
        public string Email { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Password and ConfirmPassword must be equal")]
        public string ConfirmPassword { get; set; }

    }
}
