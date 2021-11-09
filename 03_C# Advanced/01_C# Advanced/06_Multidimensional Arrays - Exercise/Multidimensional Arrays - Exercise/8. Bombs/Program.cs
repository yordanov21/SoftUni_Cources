using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] elemntsRow = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elemntsRow[col];
                }
            }

            var bombs = Console
                .ReadLine()
                .Split()
                .ToArray();
            for (int i = 0; i < bombs.Length; i++)
            {
                var bombCoordinates = bombs[i].Split(",").Select(int.Parse).ToArray();
                int bombRow = bombCoordinates[0];
                int bombCol = bombCoordinates[1];
                int bombpower = matrix[bombRow, bombCol];
                if (matrix[bombRow, bombCol] > 0)
                {
                    matrix[bombRow, bombCol] = 0;                   
                }
                else
                {
                    continue;
                }
                

                if (IsInside(matrix, bombRow - 1, bombCol - 1) && matrix[bombRow - 1, bombCol - 1] > 0)
                {
                    matrix[bombRow - 1, bombCol - 1] -= bombpower;
                }
                if (IsInside(matrix, bombRow - 1, bombCol) && matrix[bombRow - 1, bombCol] > 0)
                {
                    matrix[bombRow - 1, bombCol] -= bombpower;
                }
                if (IsInside(matrix, bombRow - 1, bombCol + 1) && matrix[bombRow - 1, bombCol + 1] > 0)
                {
                    matrix[bombRow - 1, bombCol + 1] -= bombpower;
                }
                if (IsInside(matrix, bombRow, bombCol - 1) && matrix[bombRow, bombCol - 1] > 0)
                {
                    matrix[bombRow, bombCol - 1] -= bombpower;
                }
                if (IsInside(matrix, bombRow, bombCol + 1) && matrix[bombRow, bombCol + 1] > 0)
                {
                    matrix[bombRow, bombCol + 1] -= bombpower;
                }
                if (IsInside(matrix, bombRow + 1, bombCol - 1) && matrix[bombRow + 1, bombCol - 1] > 0)
                {
                    matrix[bombRow + 1, bombCol - 1] -= bombpower;
                }
                if (IsInside(matrix, bombRow + 1, bombCol) && matrix[bombRow + 1, bombCol] > 0)
                {
                    matrix[bombRow + 1, bombCol] -= bombpower;
                }
                if (IsInside(matrix, bombRow + 1, bombCol + 1) && matrix[bombRow + 1, bombCol + 1] > 0)
                {
                    matrix[bombRow + 1, bombCol + 1] -= bombpower;
                }

              
            }
            int AliveCellsCount = 0;
            int sumAliveCells = 0;

            foreach (int item in matrix)
            {
                if (item > 0)
                {
                    AliveCellsCount++;
                    sumAliveCells += item;
                }
            }

            Console.WriteLine($"Alive cells: {AliveCellsCount}");
            Console.WriteLine($"Sum: {sumAliveCells}");
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (col == size - 1)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    else
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                   
                }
                Console.WriteLine();
            }
        }

        private static bool IsInside(int[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }

    }
}
