using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxSum = int.MinValue;
            var size = Console.ReadLine()
                  .Split(", ")
                  .Select(int.Parse)
                  .ToArray();
            var matrix = new int[size[0], size[1]];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            int[,] minMatrix = new int[2, 2];
            int[,] searchedMatrix = new int[2, 2];

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int row0col0 = matrix[row, col];
                    int row0col1 = matrix[row, col + 1];
                    int row1col0 = matrix[row + 1, col];
                    int row1col1 = matrix[row + 1, col + 1];
                    minMatrix[0, 0] = row0col0;
                    minMatrix[0, 1] = row0col1;
                    minMatrix[1, 0] = row1col0;
                    minMatrix[1, 1] = row1col1;

                    int sum = 0;
                    foreach (var item in minMatrix)
                    {
                        sum += item;
                    }
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        //searchedMatrix = minMatrix;
                        searchedMatrix[0, 0] = row0col0;
                        searchedMatrix[0, 1] = row0col1;
                        searchedMatrix[1, 0] = row1col0;
                        searchedMatrix[1, 1] = row1col1;
                    }
                }
            }

            Console.WriteLine(searchedMatrix[0,0]+" "+searchedMatrix[0,1]);
            Console.WriteLine(searchedMatrix[1,0]+" "+searchedMatrix[1,1]);
            Console.WriteLine(maxSum);
        }
    }
}
