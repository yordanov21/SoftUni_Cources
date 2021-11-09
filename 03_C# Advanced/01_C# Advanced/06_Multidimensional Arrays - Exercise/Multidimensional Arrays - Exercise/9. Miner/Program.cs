using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string[] moves = Console
                .ReadLine()
                .Split()
                .ToArray();

            char[,] matrix = new char[size, size];
            for (int row = 0; row < size; row++)
            {
                var line = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            int countCoal = 0;
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < size; row++)
            {              
                for (int col = 0; col < size; col++)
                {
                    char startSymbol = matrix[row, col];
                    if (startSymbol == 's')
                    {
                         startRow = row;
                         startCol = col;
                    }                  
                }
            }

            int allCoal = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    char startSymbol = matrix[row, col];
                    if (startSymbol == 'c')
                    {
                        allCoal++;
                    }
                }
            }

            int curentRow = startRow;
            int curentCol = startCol;
            for (int i = 0; i < moves.Length; i++)
            {

                if (moves[i] == "left")
                {
                    if (curentCol - 1 >= 0)
                    {
                        curentCol--;
                    }

                }
                else if(moves[i] == "right")
                {
                    if (curentCol + 1 < size)
                    {
                        curentCol++;
                    }
                }
                else if (moves[i] == "up")
                {
                    if (curentRow - 1 >= 0)
                    {
                        curentRow--;
                    }
                }
                else if (moves[i] == "down")
                {
                    if (curentRow + 1 < size)
                    {
                        curentRow++;
                    }
                }

                if (matrix[curentRow, curentCol] == 'c')
                {
                    countCoal++;
                    matrix[curentRow, curentCol] = '*';
                    if (allCoal == countCoal)
                    {
                        Console.WriteLine($"You collected all coals! ({curentRow}, {curentCol})");
                        return;
                    }                 
                }

                if (matrix[curentRow, curentCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({curentRow}, {curentCol})");
                    return;
                }

               
            }
            int remainingCoals = allCoal - countCoal;
            Console.WriteLine($"{remainingCoals} coals left. ({curentRow}, {curentCol})");
        }      
    }
}
