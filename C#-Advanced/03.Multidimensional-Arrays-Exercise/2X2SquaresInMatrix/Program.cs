using System;
using System.Linq;

namespace _2X2SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = dimensions[0];
            int m = dimensions[1];

            if (n < 2 || m < 2)
            {
                Console.WriteLine(0);
                return;
            }

            string[,] matrix = new string[n, m];

            for (int row = 0; row < n; row++)
            {
                string[] inputData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < m; col++)
                {
                    matrix[row, col] = inputData[col];
                }
            }

            int counter = 0;

            for (int row = 0; row < n - 1; row++)
            {
                for (int col = 0; col < m - 1; col++)
                {
                    bool isEqualChars = matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1];

                    if (isEqualChars)
                    {
                        counter++;
                    }
                }
            }

            Console.WriteLine(counter);

        }
    }
}
