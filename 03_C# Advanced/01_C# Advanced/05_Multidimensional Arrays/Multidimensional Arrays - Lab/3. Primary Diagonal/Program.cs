using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            int[,] matrix = new int[sizeMatrix, sizeMatrix];
            for (int row = 0; row <matrix.GetLength(0) ; row++)
            {
                var rowElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            int sum = 0;
            int currentRow = 0;
            int currentCol = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int currentElement = matrix[currentRow, currentCol];
                sum += currentElement;
                currentRow++;
                currentCol++;
            }

            Console.WriteLine(sum);
        }
    }
}
