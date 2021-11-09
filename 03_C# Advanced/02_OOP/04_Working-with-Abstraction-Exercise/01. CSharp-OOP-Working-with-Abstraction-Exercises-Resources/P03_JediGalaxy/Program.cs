namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            int[] matrixSizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = matrixSizes[0];
            int cols = matrixSizes[1];
            int[,] matrix = new int[rows, cols];

            MatrixFilling(rows, cols, matrix);

            string command = Console.ReadLine();
            long sumOfCollectedElements = 0;

            while (command != "Let the Force be with you")
            {
                int[] ivoPosition = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                int[] evilPosition = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                DestroyStarsByEvil(matrix, evilPosition);
                sumOfCollectedElements = CollectStars(matrix, sumOfCollectedElements, ivoPosition);

                command = Console.ReadLine();
            }

            Print(sumOfCollectedElements);
        }

        private static void Print(long sumOfCollectedElements)
        {
            Console.WriteLine(sumOfCollectedElements);
        }

        private static long CollectStars(int[,] matrix, long sumOfCollectedElements, int[] ivoPosition)
        {
            int rowIvo = ivoPosition[0];
            int colIvo = ivoPosition[1];

            while (rowIvo >= 0 && colIvo < matrix.GetLength(1))
            {
                if (rowIvo >= 0 && rowIvo < matrix.GetLength(0) && colIvo >= 0 && colIvo < matrix.GetLength(1))
                {
                    sumOfCollectedElements += matrix[rowIvo, colIvo];
                }

                colIvo++;
                rowIvo--;
            }

            return sumOfCollectedElements;
        }

        private static void DestroyStarsByEvil(int[,] matrix, int[] evilPosition)
        {
            int rowEvil = evilPosition[0];
            int colEvil = evilPosition[1];

            while (rowEvil >= 0 && colEvil >= 0)
            {
                if (rowEvil >= 0 && rowEvil < matrix.GetLength(0) && colEvil >= 0 && colEvil < matrix.GetLength(1))
                {
                    matrix[rowEvil, colEvil] = 0;
                }
                rowEvil--;
                colEvil--;
            }
        }

        private static void MatrixFilling(int rows, int cols, int[,] matrix)
        {
            int value = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }
    }
}
