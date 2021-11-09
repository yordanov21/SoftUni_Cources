using System;

namespace PrintCurcle
{
    class Program
    {
        static void Main(string[] args)
        {
            int radius = int.Parse(Console.ReadLine());
            char[,] matrix = new char[2*radius,radius*2];

            for (int row = 0; row <radius*2; row++)
            {
                for (int col = 0; col < radius*2; col++)
                {
                    if (row == radius || col == radius)
                    {
                        matrix[row, col] = '*';
                    }
                    else
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            for (int i = 0; i < radius*2; i++)
            {
                for (int j = 0; j < radius*2; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.WriteLine();
            }

        }
    }
}
