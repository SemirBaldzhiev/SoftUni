using System;

namespace _01._NationalCourt
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeePeople = int.Parse(Console.ReadLine());
            int secondEmployeePeople = int.Parse(Console.ReadLine());
            int thirdEmployeePeople = int.Parse(Console.ReadLine());
            int peopleCount = int.Parse(Console.ReadLine());

            int peopleForOneHour = firstEmployeePeople + secondEmployeePeople + thirdEmployeePeople;

            int hours = 0;

            while (peopleCount > 0)
            {
                peopleCount -= peopleForOneHour;
                hours++;

                if (hours % 4 == 0)
                {
                    hours++;
                }
                   
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
