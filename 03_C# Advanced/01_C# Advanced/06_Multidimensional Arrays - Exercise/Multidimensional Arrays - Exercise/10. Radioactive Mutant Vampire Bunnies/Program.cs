using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main()
        {
            var size = Console
                 .ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();
            int rows = size[0];
            int cols = size[1];
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var elementsRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elementsRow[col];
                }
            }

            var moves = Console.ReadLine().ToCharArray();
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char startSymbol = matrix[row, col];
                    if (startSymbol == 'P')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            int curentRow = startRow;
            int curentCol = startCol;
            bool dead = false;

            for (int i = 0; i < moves.Length; i++)
            {
                if (moves[i] == 'L')
                {
                    if (curentCol - 1 >= 0)
                    {
                        curentCol--;
                    }
                    else
                    {
                        GetlastBunys(matrix, rows, cols);
                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                if (matrix[row, col] == 'P')
                                {
                                    matrix[row, col] = '.';
                                }
                                Console.Write(matrix[row, col]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine($"won: {curentRow} {curentCol}");
                        return;

                    }
                }
                else if (moves[i] == 'R')
                {
                    if (curentCol + 1 < cols)
                    {
                        curentCol++;
                    }
                    else
                    {
                        GetlastBunys(matrix, rows, cols);
                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                if (matrix[row, col] == 'P')
                                {
                                    matrix[row, col] = '.';
                                }
                                Console.Write(matrix[row, col]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine($"won: {curentRow} {curentCol}");
                        return;

                    }
                }
                else if (moves[i] == 'U')
                {
                    if (curentRow - 1 >= 0)
                    {
                        curentRow--;
                    }
                    else
                    {
                        GetlastBunys(matrix, rows, cols);
                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                if (matrix[row, col] == 'P')
                                {
                                    matrix[row, col] = '.';
                                }
                                Console.Write(matrix[row, col]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine($"won: {curentRow} {curentCol}");
                        return;

                    }
                }
                else if (moves[i] == 'D')
                {
                    if (curentRow + 1 < rows)
                    {
                        curentRow++;
                    }
                    else
                    {
                        GetlastBunys(matrix, rows, cols);
                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                if (matrix[row, col] == 'P')
                                {
                                    matrix[row, col] = '.';
                                }
                                Console.Write(matrix[row, col]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine($"won: {curentRow} {curentCol}");
                        return;

                    }
                }

                matrix[startRow, startCol] = '.';
                startRow = curentRow;
                startCol = curentCol;

                if (matrix[curentRow, curentCol] == '.')
                {
                    matrix[curentRow, curentCol] = 'P';
                }
                else if (matrix[curentRow, curentCol] == 'B')
                {
                    GetlastBunys(matrix, rows, cols);
                    for (int row2 = 0; row2 < rows; row2++)
                    {
                        for (int col2 = 0; col2 < cols; col2++)
                        {
                            Console.Write(matrix[row2, col2]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"dead: {curentRow} {curentCol}");
                    return;

                }

                List<int[]> rabits = new List<int[]>();
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            int bombRow = row;
                            int bombCol = col;
                            int[] rabitsCoordinat = { bombRow, bombCol };
                            rabits.Add(rabitsCoordinat);
                        }
                    }
                }

                for (int index = 0; index < rabits.Count; index++)
                {
                    int[] item = rabits[index];
                    int bombRow = item[0];
                    int bombCol = item[1];

                    if (IsInside(matrix, bombRow - 1, bombCol) && matrix[bombRow - 1, bombCol] == '.')
                    {
                        matrix[bombRow - 1, bombCol] = 'B';
                    }
                    if (IsInside(matrix, bombRow, bombCol - 1) && matrix[bombRow, bombCol - 1] == '.')
                    {
                        matrix[bombRow, bombCol - 1] = 'B';
                    }
                    if (IsInside(matrix, bombRow, bombCol + 1) && matrix[bombRow, bombCol + 1] == '.')
                    {
                        matrix[bombRow, bombCol + 1] = 'B';
                    }
                    if (IsInside(matrix, bombRow + 1, bombCol) && matrix[bombRow + 1, bombCol] == '.')
                    {
                        matrix[bombRow + 1, bombCol] = 'B';
                    }

                    if (IsInside(matrix, bombRow - 1, bombCol) && matrix[bombRow - 1, bombCol] == 'P')
                    {
                        matrix[bombRow - 1, bombCol] = 'B';
                        dead = true;
                    }
                    if (IsInside(matrix, bombRow, bombCol - 1) && matrix[bombRow, bombCol - 1] == 'P')
                    {
                        matrix[bombRow, bombCol - 1] = 'B';
                        dead = true;
                    }
                    if (IsInside(matrix, bombRow, bombCol + 1) && matrix[bombRow, bombCol + 1] == 'P')
                    {
                        matrix[bombRow, bombCol + 1] = 'B';
                        dead = true;
                    }
                    if (IsInside(matrix, bombRow + 1, bombCol) && matrix[bombRow + 1, bombCol] == 'P')
                    {
                        matrix[bombRow + 1, bombCol] = 'B';
                        dead = true;
                    }

                    if (dead == true)
                    {
                        for (int row2 = 0; row2 < rows; row2++)
                        {
                            for (int col2 = 0; col2 < cols; col2++)
                            {
                                Console.Write(matrix[row2, col2]);
                            }
                            Console.WriteLine();
                        }
                        Console.WriteLine($"dead: {curentRow} {curentCol}");
                        return;

                    }

                    continue;
                }
            }
        }

        private static bool IsInside(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) &&
                col >= 0 && col < matrix.GetLength(1);
        }

        private static void GetlastBunys(char[,] matrix, int rows, int cols)
        {
            List<int[]> rabits = new List<int[]>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        int bombRow = row;
                        int bombCol = col;
                        int[] rabitsCoordinat = { bombRow, bombCol };
                        rabits.Add(rabitsCoordinat);
                    }
                }
            }

            for (int index = 0; index < rabits.Count; index++)
            {
                int[] item = rabits[index];
                int bombRow = item[0];
                int bombCol = item[1];

                if (IsInside(matrix, bombRow - 1, bombCol) && matrix[bombRow - 1, bombCol] == '.')
                {
                    matrix[bombRow - 1, bombCol] = 'B';
                }
                if (IsInside(matrix, bombRow, bombCol - 1) && matrix[bombRow, bombCol - 1] == '.')
                {
                    matrix[bombRow, bombCol - 1] = 'B';
                }
                if (IsInside(matrix, bombRow, bombCol + 1) && matrix[bombRow, bombCol + 1] == '.')
                {
                    matrix[bombRow, bombCol + 1] = 'B';
                }
                if (IsInside(matrix, bombRow + 1, bombCol) && matrix[bombRow + 1, bombCol] == '.')
                {
                    matrix[bombRow + 1, bombCol] = 'B';
                }

                if (IsInside(matrix, bombRow - 1, bombCol) && matrix[bombRow - 1, bombCol] == 'P')
                {
                    matrix[bombRow - 1, bombCol] = 'B';
                }
                if (IsInside(matrix, bombRow, bombCol - 1) && matrix[bombRow, bombCol - 1] == 'P')
                {
                    matrix[bombRow, bombCol - 1] = 'B';
                }
                if (IsInside(matrix, bombRow, bombCol + 1) && matrix[bombRow, bombCol + 1] == 'P')
                {
                    matrix[bombRow, bombCol + 1] = 'B';
                }
                if (IsInside(matrix, bombRow + 1, bombCol) && matrix[bombRow + 1, bombCol] == 'P')
                {
                    matrix[bombRow + 1, bombCol] = 'B';
                }

                continue;
            }
        }
    }
}
