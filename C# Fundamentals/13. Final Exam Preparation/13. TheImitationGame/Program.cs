using System;
using System.Linq;

namespace _13._TheImitationGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Decode")
                {
                    break;
                }

                string[] commands = input
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (commands[0])
                {

                    case "Move":
                        int numberOfLetters = int.Parse(commands[1]);
                        string substring = new string(message.Take(numberOfLetters).ToArray());
                        message = message.Remove(0, numberOfLetters);
                        message = message.Insert(message.Length, substring);
                        break;
                    case "Insert":
                        int index = int.Parse(commands[1]);
                        message = message.Insert(index, commands[2]);
                        break;
                    case "ChangeAll":
                        message = message.Replace(commands[1], commands[2]);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}
