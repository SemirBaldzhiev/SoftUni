using SharedTrip.Dtos.Trips;
using SharedTrip.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using static SharedTrip.Constants.DataConstants;

namespace SharedTrip.Services
{
    public class Validator : IValidator
    {
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

            if(user.Password == null || user.Password.Length < PasswordMinLength || user.Password.Length > DefaultMaxLength)
            {
                errors.Add($"Password must be between {PasswordMinLength} and {DefaultMaxLength} characters long");
            }

            if(user.Password != user.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }

            return errors;
        }

        public ICollection<string> ValidateTrip(AddTripFormModel trip)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(trip.StartPoint))
            {
                errors.Add("Starting point connot be null or whitespace");
            }

            if (string.IsNullOrWhiteSpace(trip.EndPoint))
            {
                errors.Add("End point connot be null or whitespace");
            }

            if (trip.Seats < SeatsMinValue || trip.Seats > SeatsMaxValue)
            {
                errors.Add($"Seats must be between {SeatsMinValue} and {SeatsMaxValue}");
            }

            if (string.IsNullOrWhiteSpace(trip.Description) || trip.Description.Length > DescriptionMaxLength)
            {
                errors.Add($"Description must be less than or equal {DescriptionMaxLength} characters long");
            }

            if (!Uri.IsWellFormedUriString(trip.ImagePath, UriKind.Absolute))
            {
                errors.Add("Invalid image path");
            }

            if (trip.DepartureTime < DateTime.UtcNow)
            {
                errors.Add($"Inavlid Departure time");
            }

            return errors;
        }
    }
}
