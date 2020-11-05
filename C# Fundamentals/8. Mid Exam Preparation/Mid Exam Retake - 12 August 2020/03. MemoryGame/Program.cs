using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MemoryGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            int moves = 0;
            bool isWon = false;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                int[] indexes = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                int firstIndex = indexes[0];
                int secondIndex = indexes[1];

                moves++;

                bool IsVaidFirstIndex = firstIndex >= 0 && firstIndex < elements.Count();
                bool IsVaidSecondIndex = secondIndex >= 0 && secondIndex < elements.Count();

                if (firstIndex == secondIndex || !IsVaidFirstIndex || !IsVaidSecondIndex)
                {
                    string elementToAdd = $"-{moves}a";

                    elements.Insert(elements.Count() / 2, elementToAdd);
                    elements.Insert(elements.Count() / 2, elementToAdd);

                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else
                {
                    if (elements[firstIndex] == elements[secondIndex])
                    {

                        Console.WriteLine($"Congrats! You have found matching elements - {elements[firstIndex]}!");

                        if (firstIndex > secondIndex)
                        {
                            elements.RemoveAt(firstIndex);
                            elements.RemoveAt(secondIndex);
                        }
                        else
                        {
                            elements.RemoveAt(secondIndex);
                            elements.RemoveAt(firstIndex);
                        }

                        if (elements.Count == 0)
                        {
                            isWon = true;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }

            }

            if (isWon)
            {
                Console.WriteLine($"You have won in {moves} turns!");
            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(' ', elements));
            }
        }
    }
}
