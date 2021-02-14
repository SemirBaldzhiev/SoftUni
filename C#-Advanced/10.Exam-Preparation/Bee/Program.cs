using System;

namespace Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int beeRow = -1;
            int beeCol = -1;

            for (int row = 0; row < n; row++)
            {
                string currentRow = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = currentRow[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }

            }


            int flowers = 0;
            string command = Console.ReadLine();
            while (command != "End")
            {
                matrix[beeRow, beeCol] = '.';

                beeRow = MoveRow(beeRow, command);
                beeCol = MoveCol(beeCol, command);

                if (!IsPositionValid(beeRow, beeCol, n , n))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    flowers++;
                }
                else if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    beeRow = MoveRow(beeRow, command);
                    beeCol = MoveCol(beeCol, command);

                    if (!IsPositionValid(beeRow, beeCol, n, n))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        flowers++;
                    }

                }

                matrix[beeRow, beeCol] = 'B';
                command = Console.ReadLine();
            }

            if (flowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }

            Print(matrix, n);

        }
        public static void Print(char[,] matrix, int n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static bool IsPositionValid(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }

            return true;
        }

        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "right")
            {
                return col + 1;
            }
            if (movement == "left")
            {
                return col - 1;
            }

            return col;
        }

    }
}
