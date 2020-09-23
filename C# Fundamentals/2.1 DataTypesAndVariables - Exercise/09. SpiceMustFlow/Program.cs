using System;

namespace _09._SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());
            int totalAmount = 0;
            int days = 0;


            if (startingYield >= 100)
            {
                while (startingYield >= 100)
                {
                    totalAmount += (startingYield - 26);

                    startingYield -= 10;
                    days++;
                }

                totalAmount -= 26;
            }
           
            Console.WriteLine(days);
            Console.WriteLine(totalAmount);
        }
    }
}
