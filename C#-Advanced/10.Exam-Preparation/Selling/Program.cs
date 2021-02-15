using System;

namespace Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int sellerRow = -1;
            int sellerCol = -1;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == 'S')
                    {
                        sellerRow = row;
                        sellerCol = col;
                    }

                    if (matrix[row, col] == 'O')
                    {

                    }
                }
            }


        }
    }
}
