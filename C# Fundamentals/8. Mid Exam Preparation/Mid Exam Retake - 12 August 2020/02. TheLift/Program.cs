using System;
using System.Linq;

namespace _02._TheLift
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int[] lift = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int length = lift.Length;

            for (int i = 0; i < length; i++)
            {
                int emptySpots = 0;

                if (people >= 4)
                {
                    emptySpots = 4 - (people - (people - lift[i]));
                }
                else
                {
                    emptySpots = people;
                }

                people -= emptySpots;

                lift[i] += emptySpots;

                if (people <= 0)
                {
                    break;
                }

            }

            bool haveEmptySpots = (((4 * length) - lift.Sum()) - people) > 0;

            if (people == 0 && haveEmptySpots)
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", lift));
            }
            else if (people > 0 && !haveEmptySpots)
            {
                Console.WriteLine($"There isn't enough space! {people} people in a queue!");
                Console.WriteLine(string.Join(" ", lift));
            }
            else if (people == 0 && !haveEmptySpots)
            {
                Console.WriteLine(string.Join(" ", lift));
            }

        }
    }
}
