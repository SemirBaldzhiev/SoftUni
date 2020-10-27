using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondHand = Console.ReadLine().Split().Select(int.Parse).ToList();


            while (firstHand.Count != 0 && secondHand.Count != 0)
            {
                int firstHandCard = firstHand[0];
                int secondHandCard = secondHand[0];

                if (firstHandCard > secondHandCard)
                {
                    firstHand.Add(firstHandCard);
                    firstHand.RemoveAt(0);
                    firstHand.Add(secondHand[0]);
                    secondHand.RemoveAt(0);
                }
                else if (firstHandCard == secondHandCard)
                {
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
                else
                {
                    secondHand.Add(secondHandCard);
                    secondHand.RemoveAt(0);
                    secondHand.Add(firstHand[0]);
                    firstHand.RemoveAt(0);
                }

            }

            int sum = 0;

            if (firstHand.Count != 0)
            {
                sum = firstHand.Sum();
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                sum = secondHand.Sum();
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }

        }
    }
}
