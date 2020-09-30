using System;
using System.Linq;

namespace _06._EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rightSum = numbers.Sum();
            int leftSum = 0;
            int index = 0;

            bool equalSum = false;

            for (int i = 0; i < numbers.Length; i++)  //1 2 3 3
            {
                if (i == 0)
                {
                    rightSum = rightSum - numbers[i];
                    leftSum = 0;
                }
                else
                {
                    rightSum -= numbers[i];
                    leftSum += numbers[i - 1];
                }

                if (leftSum == rightSum)
                {
                    index = i;
                    equalSum = true;
                    break;
                }

            }
            if (equalSum)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
