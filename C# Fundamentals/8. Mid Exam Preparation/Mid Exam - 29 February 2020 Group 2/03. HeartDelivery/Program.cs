using System;
using System.Linq;

namespace _03._HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] neighborhood = Console.ReadLine().Split('@').Select(int.Parse).ToArray();
            int currentIndex = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Love!")
                {
                    int houseCount = neighborhood.Count(x => x != 0);

                    Console.WriteLine($"Cupid's last position was {currentIndex}.");
                    if (neighborhood.All(x => x == 0))
                    {
                        Console.WriteLine("Mission was successful.");
                    }
                    else
                    {
                        Console.WriteLine($"Cupid has failed {houseCount} places.");
                    }
                    break;
                }

                string[] commands = input.Split().ToArray();

                if (commands[0] == "Jump")
                {
                    int length = int.Parse(commands[1]);

                    currentIndex += length;

                    if (currentIndex >= neighborhood.Length)
                    {
                        currentIndex = 0;
                    }
                    
                    if (neighborhood[currentIndex] == 0)
                    {
                        Console.WriteLine($"Place {currentIndex} already had Valentine's day.");
                    }
                    else
                    {
                        neighborhood[currentIndex] -= 2;

                        if (neighborhood[currentIndex] == 0)
                        {
                            Console.WriteLine($"Place {currentIndex} has Valentine's day.");
                        }
                    }
                    
                }
            }
        }
    }
}
