using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<string> pumpsData = new Queue<string>();
            

            for (int i = 0; i < n; i++)
            {
                string pumpInput = Console.ReadLine();
                pumpsData.Enqueue(pumpInput);
            }

            for (int i = 0; i < n; i++)
            {
                int currentPetrolAmount = 0;
                bool isSuccessful = true;
                for (int j = 0; j < n; j++)
                {
                    string pumpDataStr = pumpsData.Dequeue();
                    int[] pumpData = pumpDataStr.Split().Select(int.Parse).ToArray();
                    pumpsData.Enqueue(pumpDataStr);

                    currentPetrolAmount += pumpData[0];
                    currentPetrolAmount -= pumpData[1];

                    if (currentPetrolAmount < 0)
                    {
                        isSuccessful = false;
                    }

                }

                if (isSuccessful)
                {
                    Console.WriteLine(i);
                    break;
                }

                string tempData = pumpsData.Dequeue();
                pumpsData.Enqueue(tempData);
            }


        }
    }
}
