using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int count = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    Console.WriteLine($"Shot targets: {count} -> {string.Join(' ', targets)}");
                    break;
                }

                int index = int.Parse(input);

                if ((index < 0 || index >= targets.Length) || targets[index] == -1)
                {
                    continue;
                }

                int targetValue = targets[index];
                targets[index] = -1;
                count++;

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] != -1)
                    {
                        if (targets[i] > targetValue)
                        {
                            targets[i] -= targetValue;
                        }
                        else if (targets[i] <= targetValue)
                        {
                            targets[i] += targetValue;
                        }
                    }
                }
             }
        }
    }
}
