using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Constants
{
    public class DataConstants
    {
        public const int DefaultMaxLength = 20;
        public const int UsernameMinLength = 5;
        public const int PasswordMinLength = 6;
        public const int ProductNameMinLength = 4;
        public const decimal ProductMinPrice = 0.05m;
        public const decimal ProductMaxPrice = 1000m;

        public const string EmailRegularExpression = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
    }
}
