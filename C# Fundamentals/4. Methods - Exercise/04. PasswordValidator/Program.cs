using System;

namespace _04._PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool between6And10 = BetweenSixAndTenCharacters(password);
            bool onlyLattersDigits = OnlyLettersAndDigits(password);
            bool twoDigits = HaveAtLeastTwoDigits(password);


            bool passwordIsValid = between6And10  && onlyLattersDigits && twoDigits;

            if (passwordIsValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool HaveAtLeastTwoDigits(string password)
        {
            int digitsCount = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 48 && password[i] <= 57)
                {
                    digitsCount++;
                }
            }

            if (digitsCount >= 2)
            {
                return true;
            }

            Console.WriteLine("Password must have at least 2 digits");
            return false;
        }

        private static bool OnlyLettersAndDigits(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] >= 48 && password[i] <= 57) || 
                    (password[i] >= 65 && password[i] <= 90) || 
                    (password[i] >= 97 && password[i] <= 122))
                {
                    return true;
                }
            }

            Console.WriteLine("Password must consist only of letters and digits");
            return false;
        }

        private static bool BetweenSixAndTenCharacters(string password)
        {
            bool isValid = true;

            if(password.Length < 6 || password.Length > 10)
            {
                isValid = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            return isValid;
        }
    }
}
