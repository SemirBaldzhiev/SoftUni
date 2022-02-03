using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Constants
{
    public static class DataConstants
    {
        public const int UsernameMinLength = 5;
        public const int DefaultMaxLength = 20;
        public const int PasswordMinLength = 6;
        public const int SeatsMinValue = 2;
        public const int SeatsMaxValue = 6;
        public const int DescriptionMaxLength = 80;
        public const string EmailRegularExpression = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    }
}
