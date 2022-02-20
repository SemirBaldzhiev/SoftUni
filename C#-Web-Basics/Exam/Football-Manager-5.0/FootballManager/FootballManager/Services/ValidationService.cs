using FootballManager.Contracts;
using FootballManager.ViewModels.Players;
using FootballManager.ViewModels.Users;
using System.Collections.Generic;

using static FootballManager.Constants.DataConstants;

namespace FootballManager.Services
{
    public class ValidationService : IValidationService
    {
        public ICollection<string> ValidateUser(RegisterViewModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UsernameMinLength || user.Username.Length > UsernameMaxLength)
            {
                errors.Add($"Username '{user.Username}' must be between {UsernameMinLength} and {UsernameMaxLength} characters long");
            }

            if (user.Email == null)
            {
                errors.Add($"Email '{user.Email}' is not valid");
            }

            if (user.Password == null || user.Password.Length < PasswordMinLength || user.Password.Length > PasswordMaxLength)
            {
                errors.Add($"Password must be between {PasswordMinLength} and {PasswordMaxLength} characters long");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }

            return errors;
        }

        public ICollection<string> ValidatePlayer(AddPlayerViewModel player)
        {
            var errors = new List<string>();

            if (player.FullName == null || player.FullName.Length < FullNameMinLength || player.FullName.Length > FullNameMaxLength)
            {
                errors.Add($"FullName '{player.FullName}' must be between {FullNameMinLength} and {FullNameMaxLength} characters long");
            }

            if (player.ImageUrl == null)
            {
                errors.Add($"Url '{player.ImageUrl}' is not valid");
            }

            if (player.Position == null || player.Position.Length < PositionMinLength || player.Position.Length > PositionMaxLength)
            {
                errors.Add($"Position must be between {PasswordMinLength} and {PasswordMaxLength} characters long");
            }

            if (player.Speed < SpeedMinValue || player.Speed > SpeedMaxValue)
            {
                errors.Add($"Speed must be in range ({SpeedMinValue}-{SpeedMaxValue})");
            }

            if (player.Endurance < EnduranceMinValue || player.Endurance > EnduranceMaxValue)
            {
                errors.Add($"Endurance must be in range ({EnduranceMinValue}-{EnduranceMaxValue})");
            }

            if (player.Description == null || player.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description cannot be greater than {DescriptionMaxLength}");
            }

            return errors;
        }
    }
}
