using System;
using System.Linq;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split().ToArray();

            string fullName = firstLine[0] + " " + firstLine[1];

            Tuple<string, string> firstTuple = new Tuple<string, string>(fullName, firstLine[2]);


            string[] secondLine = Console.ReadLine().Split().ToArray();

            Tuple<string, int> secondTuple = new Tuple<string, int>(secondLine[0], int.Parse(secondLine[1]));

            string[] thirdLine = Console.ReadLine().Split().ToArray();

            Tuple<int, double> thirdTuple = new Tuple<int, double>(int.Parse(thirdLine[0]), double.Parse(thirdLine[1]));

            Console.WriteLine($"{firstTuple.Item1} -> {firstTuple.Item2}");
            Console.WriteLine($"{secondTuple.Item1} -> {secondTuple.Item2}");
            Console.WriteLine($"{thirdTuple.Item1} -> {thirdTuple.Item2}");
        }
    }
}
