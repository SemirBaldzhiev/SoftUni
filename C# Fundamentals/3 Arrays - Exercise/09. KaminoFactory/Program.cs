using System;
using System.Linq;

namespace _09._KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());
            int[] dna = new int[dnaLength];
            int bestSequenceIndex = 0;
            int bestSequenceCount = 0;
            int bestSum = 0;
            int[] bestDna = new int[dnaLength];
            int index = 0;
            int bestIndex = 0;


            while (true)
            {
                string line = Console.ReadLine();

                if (line == "Clone them!")
                {
                    Console.WriteLine($"Best DNA sample {bestIndex} with sum: {bestSum}.");
                    Console.WriteLine(string.Join(" ", bestDna));
                    break;
                }

                dna = line.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                index++;

                int sequenceIndex = 0;
                int sequenceCount = 1;
                int sum = dna.Sum();

                int maxSequenceCount = 0;

                
                for (int i = 0; i < dnaLength - 1; i++)
                {
                   
                    if (dna[i] == dna[i + 1] && dna[i] == 1)
                    {
                        sequenceCount++;
                    }
                    else
                    {
                        sequenceCount = 1;
                    }

                    if (sequenceCount > maxSequenceCount)
                    {
                        maxSequenceCount = sequenceCount;
                        sequenceIndex = i;
                    }
                    

                }

                if (maxSequenceCount > bestSequenceCount)
                {
                    bestSequenceCount = maxSequenceCount;
                    bestSequenceIndex = sequenceIndex;
                    bestDna = dna;
                    bestIndex = index;
                    bestSum = sum;
                }
                else if (maxSequenceCount == bestSequenceCount)
                {
                    if (sequenceIndex < bestSequenceIndex)
                    {
                        bestDna = dna;
                        bestIndex = index;
                        bestSum = sum;
                    }
                    else if (sequenceIndex == bestSequenceIndex)
                    {
                        if (sum > bestSum)
                        {
                            bestDna = dna;
                            bestIndex = index;
                            bestSum = sum;
                        }
                    }
                }


            }


        }
    }
}
