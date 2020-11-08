using System;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerDayPerWorker = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int biscuitsForMonth = int.Parse(Console.ReadLine());

            int biscuitsForDay = biscuitsPerDayPerWorker * workers;
            double biscuitsForEachThidDay = 10 * (biscuitsForDay - Math.Floor((biscuitsForDay * 0.75)));

            double totalBiscuits = 30 * biscuitsForDay - biscuitsForEachThidDay;

            double percentage = (Math.Abs(totalBiscuits - biscuitsForMonth)) / (double)biscuitsForMonth * 100;
           
            Console.WriteLine($"You have produced {totalBiscuits} biscuits for the past month.");

            if (totalBiscuits > biscuitsForMonth)
            {
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }


            
        }
    }
}
