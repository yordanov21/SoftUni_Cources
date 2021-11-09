using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = Console
                 .ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            int matrixRows = size[0];
            int matrixCols = size[1];
            string[,] matrix = new string[matrixRows, matrixCols];

            for (int row = 0; row <matrixRows; row++)
            {
                var rowElements = Console
                    .ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < matrixCols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            while (true)
            {
                var comand = Console
                    .ReadLine()
                    .Split()
                    .ToArray();

                if (comand[0] == "END")
                {
                    return;
                }

                if (comand[0] == "swap")
                {
                    if (comand.Length != 5)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        int row1 = int.Parse(comand[1]);
                        int col1 = int.Parse(comand[2]);
                        int row2 = int.Parse(comand[3]);
                        int col2 = int.Parse(comand[4]);

                        if (row1 < 0 || row1 > matrix.GetLength(0)
                            || col1 < 0 || col1 > matrix.GetLength(1)
                            || row2 < 0 || row2 > matrix.GetLength(0)
                            || col2 < 0 || col2 > matrix.GetLength(1))
                        {
                            Console.WriteLine("Invalid input!");
                        }
                        else
                        {
                            var element1 = matrix[row1, col1];
                            var element2 = matrix[row2, col2];
                            matrix[row1, col1] = element2;
                            matrix[row2, col2] = element1;

                            for (int row = 0; row < matrix.GetLength(0); row++)
                            {
                                for (int col = 0; col < matrix.GetLength(1); col++)
                                {
                                    Console.Write(matrix[row, col] + " ");
                                }

                                Console.WriteLine();
                            }
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
               
            }               
        }
    }
}
