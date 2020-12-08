using System;
using System.Linq;

namespace _07._SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Reveal")
                {
                    break;
                }

                string[] commands = input
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string substring = string.Empty;


                switch (commands[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(commands[1]);

                        message = message.Insert(index, " ");
                        break;
                    case "Reverse":
                        substring = commands[1];

                        if (message.Contains(substring))
                        {
                            int startIndex = message.IndexOf(substring);

                            message = message.Remove(startIndex, substring.Length);
                            substring = new string(substring.ToCharArray().Reverse().ToArray());

                            message = message.Insert(message.Length, substring);
                        }
                        else
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        break;
                    case "ChangeAll":
                        substring = commands[1];

                        message = message.Replace(substring, commands[2]);
                        break;
                   
                }

                Console.WriteLine(message);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
