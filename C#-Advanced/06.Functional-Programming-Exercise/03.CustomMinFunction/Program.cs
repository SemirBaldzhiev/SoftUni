using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minNum =
                nums =>
                {
                    int min = int.MaxValue;

                    for (int i = 0; i < nums.Length; i++)
                    {
                        if (nums[i] < min)
                        {
                            min = nums[i];
                        }
                    }

                    return min;
                };

            Console.WriteLine(minNum(numbers));
        }
    }
}
