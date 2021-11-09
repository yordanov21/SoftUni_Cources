using System;
using System.Linq;

namespace _3._Maximal_Sum
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
            if (matrixRows > 2 && matrixCols > 2)
            {
                int[,] matrix = new int[matrixRows, matrixCols];

                for (int row = 0; row < matrixRows; row++)
                {
                    int[] rowElements = Console
                        .ReadLine()
                        .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    for (int col = 0; col < matrixCols; col++)
                    {
                        matrix[row, col] = rowElements[col];
                    }
                }

                int maxSum = int.MinValue;
                int[,] maxMatrix3X3 = new int[3, 3];
                int[,] matrix3X3 = new int[3, 3];


                for (int row = 0; row < matrix.GetLength(0) - 2; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                    {
                        int indexRow3X3 = row;
                        int indexCol3x3 = col;
                        for (int row3X3 = 0; row3X3 < 3; row3X3++)
                        {
                            for (int col3X3 = 0; col3X3 < 3; col3X3++)
                            {
                                matrix3X3[row3X3, col3X3] = matrix[indexRow3X3, indexCol3x3];
                                indexCol3x3++;
                            }

                            indexRow3X3++;
                            indexCol3x3 = col;
                        }

                        int sum = 0;
                        foreach (int item in matrix3X3)
                        {
                            sum += item;
                        }
                        if (sum > maxSum)
                        {
                            maxSum = sum;
                           // maxMatrix3X3 = matrix3X3; why maxmatrix3X3 take the last values of matrix3X3???
                            maxMatrix3X3[0, 0] = matrix3X3[0, 0];
                            maxMatrix3X3[0, 1] = matrix3X3[0, 1];
                            maxMatrix3X3[0, 2] = matrix3X3[0, 2];
                            maxMatrix3X3[1, 0] = matrix3X3[1, 0];
                            maxMatrix3X3[1, 1] = matrix3X3[1, 1];
                            maxMatrix3X3[1, 2] = matrix3X3[1, 2];
                            maxMatrix3X3[2, 0] = matrix3X3[2, 0];
                            maxMatrix3X3[2, 1] = matrix3X3[2, 1];
                            maxMatrix3X3[2, 2] = matrix3X3[2, 2];
                        }
                    }
                }

                Console.WriteLine("Sum = " + maxSum);
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        Console.Write(maxMatrix3X3[row, col] + " ");
                    }
                    Console.WriteLine();
                }

            }
        }
    }
}
