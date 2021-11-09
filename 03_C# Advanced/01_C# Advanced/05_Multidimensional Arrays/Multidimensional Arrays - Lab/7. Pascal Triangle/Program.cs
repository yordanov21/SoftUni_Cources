using System;
using System.Linq;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            if (rows > 0 && rows <= 60)
            {
                long[][] arrPascal = new long[rows][];
                arrPascal[0] = new long[1];
                arrPascal[0][0] = 1;

                for (int row = 0; row < rows; row++)
                {
                    arrPascal[row] = new long[row + 1];
                    arrPascal[row][0] = 1;
                    arrPascal[row][arrPascal[row].Length - 1] = 1;

                    for (int col = 1; col < arrPascal[row].Length - 1; col++)
                    {

                        arrPascal[row][col] += arrPascal[row - 1][col] + arrPascal[row - 1][col - 1];
                    }
                }

                foreach (long[] row in arrPascal)
                {
                    Console.WriteLine(string.Join(" ", row));
                }
            }          
        }
    }
}
