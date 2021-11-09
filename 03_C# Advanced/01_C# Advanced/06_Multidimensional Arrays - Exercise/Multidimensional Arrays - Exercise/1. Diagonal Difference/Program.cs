using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];
            for (int row = 0; row < size; row++)
            {
                var rowElements = Console
                    .ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowElements[col];
                }                                
            }

            int sumPrimeDiagonal = 0;
            int currentRowElement1 = 0;
            int currentColElement1 = 0;
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sumPrimeDiagonal += matrix[currentRowElement1, currentColElement1];
                currentRowElement1++;
                currentColElement1++;              
            }

            int sumPrimeDiagonal2 = 0;
            int currentRowElement2 = size-1;
            int currentColElement2 = 0;

            for (int i = size-1; i >=0; i--)
            {
                sumPrimeDiagonal2 += matrix[currentRowElement2, currentColElement2];
                currentRowElement2--;
                currentColElement2++;
            }

            int diffDiagonals = Math.Abs(sumPrimeDiagonal - sumPrimeDiagonal2);
            Console.WriteLine(diffDiagonals);      
        }
    }
}
