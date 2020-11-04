using System;

namespace _01._BonusScoringSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int additionalBonus = int.Parse(Console.ReadLine());

            int maxAttendances = 0;

            if (countOfStudents == 0 || lecturesCount == 0)
            {
                Console.WriteLine($"Max Bonus: 0.");
                Console.WriteLine($"The student has attended 0 lectures.");
                return;
            }

            for (int i = 0; i < countOfStudents; i++)
            {
                int attendances = int.Parse(Console.ReadLine());

                if (attendances > maxAttendances)
                {
                    maxAttendances = attendances;
                }
            }

            double maxBonus = Math.Ceiling(maxAttendances / (double)lecturesCount * (5 + additionalBonus));

            Console.WriteLine($"Max Bonus: {maxBonus}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");
        }
    }
}
