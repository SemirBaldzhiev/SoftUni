using System;
using System.Linq;

namespace _02._ArrayModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    Console.WriteLine(string.Join(", ", numbers));
                    break;
                }

                string[] commands = input.Split().ToArray();

                int firstIndex = 0;
                int secondIndex = 0;
                
                if (commands.Length == 3)
                {
                    firstIndex = int.Parse(commands[1]);
                    secondIndex = int.Parse(commands[2]);
                }

                switch (commands[0])
                {
                    case "swap":
                        int temp = numbers[firstIndex];
                        numbers[firstIndex] = numbers[secondIndex];
                        numbers[secondIndex] = temp;
                        break;
                    case "multiply":
                        int result = numbers[firstIndex] * numbers[secondIndex];
                        numbers[firstIndex] = result;
                        break;
                    case "decrease":
                        numbers = numbers.Select(x => x - 1).ToArray();
                        break;
                }


            }

        }
    }
}
