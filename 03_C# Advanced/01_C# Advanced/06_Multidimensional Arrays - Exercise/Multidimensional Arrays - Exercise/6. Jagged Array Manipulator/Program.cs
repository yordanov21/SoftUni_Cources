using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                var elementsRow = Console
                    .ReadLine()
                    .Split()
                    .Select(double.Parse)
                    .ToArray();
                matrix[row] = elementsRow;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                var currentRow = matrix[row];
                var nextRow = matrix[row + 1];
                if (currentRow.Length == nextRow.Length)
                {
                    currentRow = currentRow.Select(x => x * 2).ToArray();
                    nextRow = nextRow.Select(x => x * 2).ToArray();
                    matrix[row] = currentRow;
                    matrix[row + 1] = nextRow;
                }
                else
                {
                    currentRow = currentRow.Select(x => x / 2).ToArray();
                    nextRow = nextRow.Select(x => x / 2).ToArray();
                    matrix[row] = currentRow;
                    matrix[row + 1] = nextRow;
                }
            }

            while (true)
            {
                var comand = Console.ReadLine().Split().ToArray();

                if (comand[0] == "End")
                {
                    break;
                }

                if (comand[0] == "Add")
                {
                    int row = int.Parse(comand[1]);
                    int col = int.Parse(comand[2]);
                    int element = int.Parse(comand[3]);
                    if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] += element;
                    }
                }
                else if (comand[0] == "Subtract")
                {
                    int row = int.Parse(comand[1]);
                    int col = int.Parse(comand[2]);
                    int element = int.Parse(comand[3]);
                    if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] -= element;
                    }
                }
            }

            foreach ( double[]row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
