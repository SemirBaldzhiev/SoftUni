using System;
using System.Text;
using System.Linq;

namespace _05._MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine().TrimStart('0');
            int number = int.Parse(Console.ReadLine());
            int prevDigit = 0;

            if (number == 0 || bigNumber == string.Empty)
            {
                Console.WriteLine(0);
                return;
            }

            StringBuilder sb = new StringBuilder();


            foreach (var ch in bigNumber.Reverse())
            {
                int digit = int.Parse(ch.ToString());
                int multiplyDigit = digit * number + prevDigit;

                int restDigit = multiplyDigit % 10;
                prevDigit = multiplyDigit / 10;

                sb.Insert(0, restDigit);
            }
            if (prevDigit > 0)
            {
                sb.Insert(0, prevDigit);
            }
           
            Console.WriteLine(sb);
        }
    }
}
