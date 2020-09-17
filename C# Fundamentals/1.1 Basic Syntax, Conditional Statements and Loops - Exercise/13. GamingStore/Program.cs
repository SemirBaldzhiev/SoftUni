using System;

namespace _13._GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());

            double price = 0;
            double totalSpent = 0;


            while (true)
            {
                string game = Console.ReadLine();

                switch (game)
                {
                    case "OutFall 4": price = 39.99; break;
                    case "CS: OG": price = 15.99; break;
                    case "Zplinter Zell": price = 19.99; break;
                    case "Honored 2": price = 59.99; break;
                    case "RoverWatch": price = 29.99; break;
                    case "RoverWatch Origins Edition": price = 39.99; break;
                    default: Console.WriteLine("Not Found"); break;
                }

                if (game == "Game Time")
                {
                    Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${balance:f2}");
                    break;
                }

                if (price > balance)
                {
                    Console.WriteLine("Too Expensive");
                }
                else
                {
                    balance -= price;
                    totalSpent += price;
                    Console.WriteLine($"Bought {game}");
                }


                if (balance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }



            }
        }
    }
}
