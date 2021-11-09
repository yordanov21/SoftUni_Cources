using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeMatrix = int.Parse(Console.ReadLine());

            char[,] matrix = new char[sizeMatrix, sizeMatrix];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowElements = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            char symbol = char.Parse(Console.ReadLine());
            bool symbolFind=false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentSymbol = matrix[row, col];
                    if (symbol == currentSymbol)
                    {
                        symbolFind = true;
                        int symbolRow = row;
                        int symbolCol = col;
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            if (symbolFind==false)
            {
                Console.WriteLine($"{symbol} does not occur in the matrix ");
            }       
        }
    }
}
