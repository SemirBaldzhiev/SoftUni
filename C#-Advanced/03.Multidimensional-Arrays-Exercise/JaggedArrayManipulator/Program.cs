using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jaggedArr = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] inputData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                jaggedArr[row] = inputData;
            }

            for (int row = 0; row < n - 1; row++)
            {

                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    jaggedArr[row] = jaggedArr[row].Select(x => x * 2).ToArray();
                    jaggedArr[row + 1] = jaggedArr[row + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    jaggedArr[row] = jaggedArr[row].Select(x => x / 2).ToArray();
                    jaggedArr[row + 1] = jaggedArr[row + 1].Select(x => x / 2).ToArray();
                }
            }

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "End")
                {
                    break;
                }

                string[] commands = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                int rowIndex = int.Parse(commands[1]);
                int colIndex = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                bool isValidCordinates = IsValidCell(rowIndex, colIndex, jaggedArr);

                if (!isValidCordinates)
                {
                    continue;
                }

                if (commands[0] == "Add")
                {
                    jaggedArr[rowIndex][colIndex] += value;
                }
                else if (commands[0] == "Subtract")
                {
                    jaggedArr[rowIndex][colIndex] -= value;
                }
            }

            PrintMatrix(jaggedArr);
        }

        private static void PrintMatrix(double[][] jaggedArr)
        {
            for (int row = 0; row < jaggedArr.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArr[row].Length; col++)
                {
                    Console.Write($"{jaggedArr[row][col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValidCell(int row, int col, double[][] jaggedArr)
        {
            return row >= 0 && row < jaggedArr.GetLength(0) && col >= 0 && col < jaggedArr[row].Length;
        }
    }
}
