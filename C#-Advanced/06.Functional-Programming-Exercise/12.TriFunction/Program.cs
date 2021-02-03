using System;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split().ToArray();

            Func<string, int, bool> func = (name, num) =>
            {
                bool isLarger = false;

                int sum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    sum += (int)name[i];
                }

                if (sum >= num)
                {
                    isLarger = true;
                }

                return isLarger;
            };

            string largestSumName = FindLargestCharSum(names, n, func);

            Console.WriteLine(largestSumName);

        }

        public static string FindLargestCharSum(string[] names, int n, Func<string, int, bool> func)
        {
            string result = string.Empty;

            foreach (var name in names)
            {
                if (func(name, n))
                {
                    result = name;
                    break;
                }
            }

            return result;
        }
    }
}
