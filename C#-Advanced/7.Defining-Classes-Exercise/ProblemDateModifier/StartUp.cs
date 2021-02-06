using System;

namespace ProblemDateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();

            int days = DateModifier.GetDiffBetweenDatesInDays(dateOne, dateTwo);

            Console.WriteLine(days);
        }
    }
}
