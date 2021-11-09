using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace _2._Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sBilderLine = new StringBuilder();
            string stringLine = Console.ReadLine();
            sBilderLine.Append(stringLine);

            int matrixSize = int.Parse(Console.ReadLine());
            char[,] matrix = new char[matrixSize, matrixSize];

            int playerRow = 0;
            int playerCol = 0;
            for (int row = 0; row < matrixSize; row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < matrixSize; col++)
                {
                    char currentSymbol = currentRow[col];
                    matrix[row, col] = currentSymbol;
                    if (currentSymbol == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

              //Move commands will be: "up", "down", "left", "right"
              // Each turn you will be given commands for the player’s movement.
             //If he moves to a letter, he consumes it, concatеnates it to the initial string and the letter disappears from the field.
             //If he tries to move outside of the field, he is punished - he loses the last letter in the string, 
             //if there are any, and the player’s position is not changed.
                if (command == "up")
                {
                    if (playerRow == 0)
                    {
                        if (sBilderLine.Length > 0)
                        {
                            sBilderLine.Remove(sBilderLine.Length - 1, 1);
                        }
                      
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow--;
                        ColectCharacters(sBilderLine, matrix, playerRow, playerCol);
                    }
                }
                else if (command == "down")
                {
                    if (playerRow == matrixSize-1)
                    {
                        if (sBilderLine.Length > 0)
                        {
                            sBilderLine.Remove(sBilderLine.Length - 1, 1);                          
                        }
                        
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerRow++;
                        ColectCharacters(sBilderLine, matrix, playerRow, playerCol);
                    }
                }
                else if (command == "left")
                {
                    if (playerCol == 0)
                    {
                        if (sBilderLine.Length > 0)
                        {
                            sBilderLine.Remove(sBilderLine.Length - 1, 1);
                        }
                       
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol--;
                        ColectCharacters(sBilderLine, matrix, playerRow, playerCol);
                    }
                }
                else if (command == "right")
                {
                    if (playerCol == matrixSize - 1)
                    {
                        if (sBilderLine.Length > 0)
                        {
                            sBilderLine.Remove(sBilderLine.Length - 1, 1);
                        }
                      
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = '-';
                        playerCol++;
                        ColectCharacters(sBilderLine, matrix, playerRow, playerCol);
                    }
                }
            }

            matrix[playerRow, playerCol] = 'P';

            Console.WriteLine(sBilderLine.ToString());

            for (int row = 0; row < matrixSize; row++)
            {
                for (int col = 0; col < matrixSize; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static void ColectCharacters(StringBuilder sBilderLine, char[,] matrix, int playerRow, int playerCol)
        {
            char symbol = matrix[playerRow, playerCol];
            if (symbol != '-')
            {
                sBilderLine.Append(symbol);
            }
        }
    }
}
