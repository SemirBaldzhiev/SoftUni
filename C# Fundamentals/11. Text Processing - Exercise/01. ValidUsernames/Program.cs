using System;
using System.Linq;

namespace _01._ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            bool isValid = false;


            foreach (var name in usernames)
            {

                char[] nameToChar;

               

                if (name.Length >= 3 && name.Length <= 16)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    continue;
                }

                nameToChar = name.ToCharArray();

                foreach (var ch in nameToChar)
                {
                    if (char.IsLetterOrDigit(ch))
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        break;
                    }
                }

                if (name.Contains('-') || name.Contains('_'))
                {
                    isValid = true;
                }

                if (isValid)
                {
                    Console.WriteLine(name);
                }
            }

        }
    }
}
