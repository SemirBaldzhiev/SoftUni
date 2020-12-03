using System;
using System.Linq;
using System.Text;

namespace _04._PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Done")
                {
                    break;
                }

                string[] commands = line
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (commands[0])
                {
                    case "TakeOdd":
                        for (int i = 0; i < password.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                sb.Append(password[i]);
                            }
                        }

                        password = sb.ToString();
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int index = int.Parse(commands[1]);
                        int length = int.Parse(commands[2]);

                        password = password.Remove(index, length);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        if (password.Contains(commands[1]))
                        {
                            password = password.Replace(commands[1], commands[2]);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}
