using System;
using System.Linq;

namespace Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split().ToArray();

            string fullName = firstLine[0] + " " + firstLine[1];

            string city = string.Join(" ", firstLine.Skip(3));

            Threeuple<string, string, string> firstThreeuple =
                new Threeuple<string, string, string>(fullName, firstLine[2], city);

            string[] secondLine = Console.ReadLine().Split().ToArray();

            bool isDrunk = secondLine[2] == "drunk";

            Threeuple<string, int, bool> seconThreeuple =
                new Threeuple<string, int, bool>(secondLine[0], int.Parse(secondLine[1]), isDrunk);

            string[] thirdLine = Console.ReadLine().Split().ToArray();

            Threeuple<string, double, string> thirdThreeuple =
                new Threeuple<string, double, string>(thirdLine[0], double.Parse(thirdLine[1]), thirdLine[2]);

            Console.WriteLine($"{firstThreeuple.Item1} -> {firstThreeuple.Item2} -> {firstThreeuple.Item3}");
            Console.WriteLine($"{seconThreeuple.Item1} -> {seconThreeuple.Item2} -> {seconThreeuple.Item3}");
            Console.WriteLine($"{thirdThreeuple.Item1} -> {thirdThreeuple.Item2} -> {thirdThreeuple.Item3}");
        }
    }
}
