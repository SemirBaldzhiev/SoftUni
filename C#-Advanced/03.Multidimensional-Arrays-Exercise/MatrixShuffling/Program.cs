using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = dimensions[0];
            int m = dimensions[1];

            string[,] matrix = new string[n, m];


            for (int row = 0; row < n; row++)
            {
                string[] inputData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = inputData[col];
                }
            }

            while (true)
            {

                string line = Console.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] command = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (command.Length != 5 || command[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int rowOne = int.Parse(command[1]);
                int colOne = int.Parse(command[2]);
                int rowTwo = int.Parse(command[3]);
                int colTwo = int.Parse(command[4]);

                bool isValidCordinates = IsValidCell(rowOne, colOne, n, m) && IsValidCell(rowTwo, colTwo, n, m);

                if (!isValidCordinates)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string temp = matrix[rowOne, colOne];
                matrix[rowOne, colOne] = matrix[rowTwo, colTwo];
                matrix[rowTwo, colTwo] = temp;

                PrintMatrix(matrix);
            }
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsValidCell(int row, int col, int n, int m)
        {
            return row >= 0 && row < n && col >= 0 && col < m;
        }
    }
}
