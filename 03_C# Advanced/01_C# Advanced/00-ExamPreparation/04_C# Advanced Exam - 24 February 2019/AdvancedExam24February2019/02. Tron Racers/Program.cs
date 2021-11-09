using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());
            char[][] matrix = new char[matrixSize][];

            int fRow = 0;
            int fCol = 0;

            int sRow = 0;
            int sCol = 0;

            for (int row = 0; row < matrixSize; row++)
            {
                string input = Console.ReadLine();
                matrix[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row][col] = input[col];
                    if (input[col] == 'f')
                    {
                        fRow = row;
                        fCol = col;
                    }
                    if (input[col] == 's')
                    {
                        sRow = row;
                        sCol = col;
                    }
                }
            }

            while (true)
            {
                var commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstPlayerCommand = commands[0];
                string secondPlayerCommand = commands[1];

                if (firstPlayerCommand == "up")
                {
                    fRow--;
                    if (fRow < 0)
                    {
                        fRow = matrixSize - 1;
                    }
                    if (matrix[fRow][fCol] == 's')
                    {
                        matrix[fRow][fCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[fRow][fCol] = 'f';
                    }

                }
                else if (firstPlayerCommand == "down")
                {
                    fRow++;
                    if (fRow > matrixSize - 1)
                    {
                        fRow = 0;
                    }
                    if (matrix[fRow][fCol] == 's')
                    {
                        matrix[fRow][fCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[fRow][fCol] = 'f';
                    }
                }
                else if (firstPlayerCommand == "left")
                {
                    fCol--;
                    if (fCol < 0)
                    {
                       fCol = matrix[fRow].Length-1;
                    }
                    if (matrix[fRow][fCol] == 's')
                    {
                        matrix[fRow][fCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[fRow][fCol] = 'f';
                    }
                }
                else if (firstPlayerCommand == "right")
                {
                    fCol++;
                    if (fCol > matrix[fRow].Length - 1)
                    {
                        fCol =0;
                    }
                    if (matrix[fRow][fCol] == 's')
                    {
                        matrix[fRow][fCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[fRow][fCol] = 'f';
                    }
                }

                if (secondPlayerCommand == "up")
                {
                    sRow--;
                    if (sRow < 0)
                    {
                        sRow = matrixSize - 1;
                    }
                    if (matrix[sRow][sCol] == 'f')
                    {
                        matrix[sRow][sCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[sRow][sCol] = 's';
                    }

                }
                else if (secondPlayerCommand == "down")
                {
                    sRow++;
                    if (sRow > matrixSize - 1)
                    {
                       sRow = 0;
                    }
                    if (matrix[sRow][sCol] == 'f')
                    {
                        matrix[sRow][sCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[sRow][sCol] = 's';
                    }
                }
                else if (secondPlayerCommand == "left")
                {
                    sCol--;
                    if (sCol < 0)
                    {
                        sCol = matrix[sRow].Length - 1;
                    }
                    if (matrix[sRow][sCol] == 'f')
                    {
                        matrix[sRow][sCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[sRow][sCol] = 's';
                    }
                }
                else if (secondPlayerCommand == "right")
                {
                    sCol++;
                    if (sCol > matrix[sRow].Length - 1)
                    {
                        sCol = 0;
                    }
                    if (matrix[sRow][sCol] == 'f')
                    {
                        matrix[sRow][sCol] = 'x';
                        break;
                    }
                    else
                    {
                        matrix[sRow][sCol] = 's';
                    }
                }
            }

            foreach (char[] row in matrix)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
    }
}
