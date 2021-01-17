using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] clothesData = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> clothes = new Stack<int>(clothesData);
            int sumClothes = 0;
            int racksCount = 1;

            while (clothes.Count > 0)
            {
                sumClothes += clothes.Peek();

                if (sumClothes <= rackCapacity)
                {
                    clothes.Pop();
                }
                else
                {
                    sumClothes = 0;
                    racksCount++;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
