using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowsColsMatrix = Console
                  .ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToArray();

            int matrixRows = rowsColsMatrix[0];
            int matrixCols = rowsColsMatrix[1];
            string[,] matrix = new string[matrixRows, matrixCols];

            for (int row = 0; row < matrixRows; row++)
            {

                string[] rowElements = Console.ReadLine().Split().ToArray();
                for (int col = 0; col < matrixCols; col++)
                {
                    matrix[row, col] = rowElements[col];
                }
            }

            int coutMatrix2X2 = 0;

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    string[,] matrix2X2 = new string[2, 2];
                    matrix2X2[0, 0] = matrix[row, col];
                    matrix2X2[0, 1] = matrix[row, col+1];
                    matrix2X2[1, 0] = matrix[row+1, col];
                    matrix2X2[1, 1] = matrix[row+1, col+1];

                    if (matrix2X2[0, 0] == matrix2X2[0, 1]
                        && matrix2X2[0, 1]== matrix2X2[1, 0] 
                        && matrix2X2[1, 0] == matrix2X2[1, 1]
                        && matrix2X2[0, 0]== matrix2X2[1, 1])
                    {
                        coutMatrix2X2++;
                    }

                }   
            }

            Console.WriteLine(coutMatrix2X2);
        }           
    }
}
