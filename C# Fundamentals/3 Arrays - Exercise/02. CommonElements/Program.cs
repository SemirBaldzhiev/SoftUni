using System;
using System.Linq;

namespace _02._CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine().Split().ToArray();
            string[] secondArr = Console.ReadLine().Split().ToArray();

            int length = firstArr.Length;
            string result = string.Empty;

            for (int i = 0; i < length; i++)
            {
                if (secondArr.Contains(firstArr[i]))
                {
                    result += $"{firstArr[i]} ";
                }
            }

            Console.WriteLine(result.TrimEnd()); ;

        }
    }
}
