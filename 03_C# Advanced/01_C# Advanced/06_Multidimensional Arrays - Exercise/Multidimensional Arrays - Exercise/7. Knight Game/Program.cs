using System;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            
            int killerRow = 0;
            int killerCol = 0;
            int knightsCount = 0;
            for (int row = 0; row <size; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row,col] = line[col];
                }
            }
            while (true)
            {
                int maxAttacks = 0;
                for (int row = 0; row < size; row++)
                {

                    for (int col = 0; col < size; col++)
                    {
                        char symbol = matrix[row, col];
                        if (symbol == 'K')
                        {
                            int currentKnightAttacks = 0;
                            if (row - 2 >= 0 && row - 2 < matrix.GetLength(0) && col + 1 >= 0 && col + 1 < matrix.GetLength(1) && symbol == matrix[row - 2, col + 1])
                            {
                                currentKnightAttacks++;
                            }
                            if (row + 2 >= 0 && row + 2 < matrix.GetLength(0) && col + 1 >= 0 && col + 1 < matrix.GetLength(1) && symbol == matrix[row + 2, col + 1])
                            {
                                currentKnightAttacks++;
                            }
                            if (row - 2 >= 0 && row - 2 < matrix.GetLength(0) && col - 1 >= 0 && col - 1 < matrix.GetLength(1) && symbol == matrix[row - 2, col - 1])
                            {
                                currentKnightAttacks++;
                            }
                            if (row + 2 >= 0 && row + 2 < matrix.GetLength(0) && col - 1 >= 0 && col - 1 < matrix.GetLength(1) && symbol == matrix[row + 2, col - 1])
                            {
                                currentKnightAttacks++;
                            }

                            if (row - 1 >= 0 && row - 1 < matrix.GetLength(0) && col + 2 >= 0 && col + 2 < matrix.GetLength(1) && symbol == matrix[row - 1, col + 2])
                            {
                                currentKnightAttacks++;
                            }
                            if (row + 1 >= 0 && row + 1 < matrix.GetLength(0) && col + 2 >= 0 && col + 2 < matrix.GetLength(1) && symbol == matrix[row + 1, col + 2])
                            {
                                currentKnightAttacks++;
                            }
                            if (row - 1 >= 0 && row - 1 < matrix.GetLength(0) && col - 2 >= 0 && col - 2 < matrix.GetLength(1) && symbol == matrix[row - 1, col - 2])
                            {
                                currentKnightAttacks++;
                            }
                            if (row + 1 >= 0 && row + 1 < matrix.GetLength(0) && col - 2 >= 0 && col - 2 < matrix.GetLength(1) && symbol == matrix[row + 1, col - 2])
                            {
                                currentKnightAttacks++;
                            }

                            if (currentKnightAttacks > maxAttacks)
                            {
                                maxAttacks = currentKnightAttacks;
                                killerRow = row;
                                killerCol = col;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    matrix[killerRow, killerCol] = '0';
                    knightsCount++;
                }
                else
                {
                    Console.WriteLine(knightsCount);
                    break;
                }
            }           
        }
    }
}
