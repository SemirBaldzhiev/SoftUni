using SMS.Dtos.Products;
using SMS.Dtos.Users;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using static SMS.Constants.DataConstants;

namespace SMS.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateProduct(CreateProductFormModel product)
        {
            var errors = new List<string>();

            if (product.Name == null || product.Name.Length < ProductNameMinLength || product.Name.Length > DefaultMaxLength)
            {
                errors.Add($"Product '{product.Name}' must be between {ProductNameMinLength} and {DefaultMaxLength} characters long");
            }

            if (product.Price < ProductMinPrice || product.Price > ProductMaxPrice)
            {
                errors.Add($"Price must be in range ({ProductMinPrice} - {ProductMaxPrice})");
            }

            return errors;
        }

        public ICollection<string> ValidateUser(RegisterUserFormModel user)
        {
            var errors = new List<string>();

            if (user.Username == null || user.Username.Length < UsernameMinLength || user.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{user.Username}' must be between {UsernameMinLength} and {DefaultMaxLength} characters long");
            }

            if (user.Email == null || !Regex.IsMatch(user.Email, EmailRegularExpression))
            {
                errors.Add($"Email '{user.Email}' is not valid");
            }

            if (user.Password == null || user.Password.Length < PasswordMinLength || user.Password.Length > DefaultMaxLength)
            {
                errors.Add($"Password must be between {PasswordMinLength} and {DefaultMaxLength} characters long");
            }

            if (user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }

            return errors;
        }
    }
}
