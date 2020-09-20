using System;

namespace _04._BackIn30Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hour = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            seconds += 30;

            if (seconds >= 60)
            {
                hour++;
                seconds -= 60;
            }

            if (hour == 24)
            {
                hour = 0;
            }

            Console.WriteLine($"{hour}:{seconds:D2}");
        }
    }
}
