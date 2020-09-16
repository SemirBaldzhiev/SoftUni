using System;
using System.Linq;

namespace _05._Login
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string username = Console.ReadLine();
            char[] arr = username.ToCharArray();
            Array.Reverse(arr);
            string correctPassword = new string(arr);
            int counter = 0;

            while (true)
            {
                counter++;

                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                string password = Console.ReadLine();

                if (password == correctPassword)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                
            }
        }
    }
}
